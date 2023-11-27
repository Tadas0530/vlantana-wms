<template>
  <div class="bg-light border-right" id="sidebar-wrapper">
    <div class="sidebar-heading">Sandėlio valdymo informacinė sistema</div>
    <div class="list-group list-group-flush">
      <router-link to="/app/dashboard" class="list-group-item list-group-item-action">Apžvalga</router-link>
      <router-link v-if="[1, 3, 4].includes(this.userRole)" to="/app/inventory"
        class="list-group-item list-group-item-action">Inventorius</router-link>
      <router-link v-if="[1, 3, 4].includes(this.userRole)" to="/app/orders"
        class="list-group-item list-group-item-action">Užsakymai</router-link>
      <router-link v-if="[1, 2, 4].includes(this.userRole)" to="/app/assigned-orders" class="list-group-item list-group-item-action">Užsakymų
        surinkimai</router-link>
      <router-link to="/app/scan" class="list-group-item list-group-item-action">Skenavimas</router-link>
      <v-select v-if="isDropdownAvailable" v-model="selectedCompany" label="Įmonė" :items="companyData"
        item-title="company_name" item-value="id" class="sidebar-select"></v-select>
    </div>
    <v-col cols="auto" style="position: fixed; bottom: 0;">
        <v-btn @click="logout" icon="mdi-account" size="x-small"></v-btn>
      </v-col>
  </div>
</template>
  

<script>
import apiClient from '@/utils/api-client';
import { mapGetters } from 'vuex';

export default {
  data() {
    return {
      userRole: null,
      companyData: [],
      selectedCompany: null,
      mounted: false,
    }
  },
  methods: {
    fetchCompanies() {
      const user = JSON.parse(localStorage.getItem('user'));

      apiClient.get('/companies', { withCredentials: true })
        .then(response => {
          this.companyData = response.data;

          this.autoChooseCompany(user.user.company_id)
        })
        .catch(error => {
          console.error('Error fetching companies data:', error);
        });
    },
    autoChooseCompany(id) {
      // if client mode choose by company id
      const user = JSON.parse(localStorage.getItem('user'))

      console.log('client mode: ' + this.getIsClientMode)
      if (this.getIsClientMode) {
        const selectedCompany = this.companyData.find(c => { return user.user.company_id === c.id });
        this.$store.commit('setSelectedCompany', selectedCompany)
        localStorage.setItem('lastChosenCompany', JSON.stringify(selectedCompany))
        this.selectedCompany = selectedCompany.id;
        return;
      }

      // if not client mode choose by last chosen if that does not exist choose the first one 

      const lastChosenCompany = JSON.parse(localStorage.getItem('lastChosenCompany'))
      if (lastChosenCompany) {
        this.$store.commit('setSelectedCompany', lastChosenCompany)
        this.selectedCompany = lastChosenCompany.id
      } else {
        const companyToSet = this.companyData[0];
        this.$store.commit('setSelectedCompany', companyToSet);
        localStorage.setItem('lastChosenCompany', JSON.stringify(companyToSet));
        this.selectedCompany = companyToSet.id;
      }

    },
    configClientMode() {
      const user = JSON.parse(localStorage.getItem('user'));

      // config is client account
      user.user.company_id === 4 ? this.$store.commit('setIsClientMode', false) : this.$store.commit('setIsClientMode', true)
    },
    logout() {
      apiClient.post('/logout', _, { withCredentials: true }).then(response => {
        localStorage.clear('user')
        this.$router.push('/authentication')
      })
    }
  },
  watch: {
    selectedCompany: {
      handler(oldVal, newVal) {
        if (this.getSelectedCompany) {
          const chosenCompany = this.companyData.find(c => { return oldVal === c.id });
          this.$store.commit('setSelectedCompany', chosenCompany);
          localStorage.setItem('lastChosenCompany', JSON.stringify(chosenCompany))
        }
      },
      immediate: false
    },
  },
  computed: {
    isDropdownAvailable() {
      return !this.$store.getters.getIsClientMode && this.userRole !== 4
    },
    ...mapGetters([
      'getSelectedCompany',
      'getIsClientMode'
    ])
  },
  beforeMount() {
    const user = JSON.parse(localStorage.getItem('user'));
    this.userRole = user?.user?.role?.id;

    this.configClientMode();
  },
  mounted() {
    if (this.companyData.length === 0) this.fetchCompanies();
    document.title = "Sandėlio valdymo informacinė sistema";
  }
}
</script>

<style>
#sidebar-wrapper {
  min-height: 100vh;
  width: 250px;
  z-index: 1000;
  overflow-y: auto;
  position: fixed;
  background-color: #343a40 !important;
  /* Dark background for modern look */
  color: #fff;
  /* Light text for contrast */
}

.sidebar-heading {
  padding: 10px 15px;
  text-align: center;
  background-color: #343a40;
  /* Match the sidebar color */
  color: white;
  font-size: 1.2em;
  border-bottom: 1px solid #495057;
  /* Slightly lighter color for subtle separation */
}

.list-group-item {
  border: none;
  padding: 15px 20px;
  color: #fff;
  background-color: #343a40;
  /* Consistent with sidebar color */
  transition: background-color 0.3s;
  /* Smooth transition for hover effect */
}

.list-group-item-action.active {
  background-color: #007bff;
  color: white;
}

.sidebar-select {
  border: none;
  margin: 10px;
  color: #fff;
  /* Updated to white for visibility */
  background-color: #343a40;
  /* Match the sidebar color */
}

/* Additional styles for the select dropdown to match the sidebar theme */
.sidebar-select .v-select {
  background-color: #343a40;
  color: #fff;
}

/* Ensure that the border of the dropdown matches */
.v-select .vs__dropdown-toggle {
  border-color: #495057;
}

/* Style for the selected item in the dropdown */
.v-select .vs__selected {
  background-color: #495057;
  color: #fff;
}

/* Style for dropdown items on hover */
.v-select .vs__dropdown-menu li:hover {
  background-color: #495057;
  color: #fff !important;
}

/* Style for the active link */
.router-link-exact-active,
.router-link-exact-active:focus,
.router-link-exact-active:hover {
  background-color: #fbfbfc;
  /* Blue color for active state */
  color: black;
}
</style>
