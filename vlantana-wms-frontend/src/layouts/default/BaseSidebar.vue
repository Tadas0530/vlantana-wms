<template>
  <div class="bg-light border-right" id="sidebar-wrapper">
    <div class="sidebar-heading">Inventoriaus valdymo sistema</div>
    <div class="list-group list-group-flush">
      <router-link to="/app/dashboard" class="list-group-item list-group-item-action bg-light">Apžvalga</router-link>
      <router-link v-if="[1, 3, 4].includes(this.userRole)" to="/app/inventory"
        class="list-group-item list-group-item-action bg-light">Inventorius</router-link>
      <router-link v-if="[1, 3, 4].includes(this.userRole)" to="/app/orders"
        class="list-group-item list-group-item-action bg-light">Užsakymai</router-link>
      <router-link to="/app/assigned-orders" class="list-group-item list-group-item-action bg-light">Užsakymų
        surinkimai</router-link>
      <router-link to="/app/scan" class="list-group-item list-group-item-action bg-light">Skenavimas</router-link>
      <v-select v-if="isDropdownAvailable" v-model="selectedCompany" label="Įmonė" :items="companyData"
        item-title="company_name" item-value="id"></v-select>
    </div>
  </div>
</template>
  

<script>
import apiClient from '@/utils/api-client';

export default {
  data() {
    return {
      userRole: null,
      companyData: [],
      selectedCompany: null,
    }
  },
  methods: {
    fetchCompanies() {
      const user = JSON.parse(localStorage.getItem('user'));

      apiClient.get('/companies', { withCredentials: true })
        .then(response => {
          this.companyData = response.data;

          const selectedCompany = this.companyData.find(c => { return user.user.company_id === c.id });
          this.$store.commit('setSelectedCompany', selectedCompany)
          this.selectedCompany = selectedCompany;
        })
        .catch(error => {
          console.error('Error fetching companies data:', error);
        });
    },
    configClientMode() {
      const user = JSON.parse(localStorage.getItem('user'));

      // config is client account
      user.user.company_id === 4 ? this.$store.commit('setIsClientMode', false) : this.$store.commit('setIsClientMode', true)
    }
  },
  watch: {
    selectedCompany: {
      handler(oldVal, newVal) {
        this.$store.commit('setSelectedCompany', this.companyData.find(c => { return oldVal === c.id }));
      }
    }
  },
  computed: {
    isDropdownAvailable() {
      return !this.$store.getters.getIsClientMode && this.userRole !== 4 
    }
  },
  beforeMount() {
    const user = JSON.parse(localStorage.getItem('user'));
    this.userRole = user?.user?.role?.id;

    this.configClientMode();
  },
  mounted() {
    if (this.companyData.length === 0) this.fetchCompanies();
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
}
</style>