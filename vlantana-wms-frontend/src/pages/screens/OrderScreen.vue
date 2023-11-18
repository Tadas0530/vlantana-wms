<template>
  <div class="" style="width: max-content;">
    <h1 class="mt-4">Pateikti užsakymai</h1>
    <p>Sudarytų užsakymų duomenų bazė</p>
  </div>
  <v-data-table hover v-model="selected" :headers="headers" :loading="isLoading"
    loading-text="Kraunami užsakymų duomenys..." :items="orderData" v-model:items-per-page="limit" item-value="order_code"
    return-object show-select></v-data-table>
</template>

<script>
import { VDataTable } from 'vuetify/lib/labs/components.mjs';
import apiClient from '@/utils/api-client';
import urlProvider from '@/utils/url-provider';

export default {
  data() {
    return {
      isLoading: false,
      orderData: [],
      selected: [],
      limit: 25,
      page: 1,
      headers: [
        {
          title: 'Užsakymas',
          align: 'start',
          key: 'order_code',
        },
        { title: 'Aprašymas', align: 'end', key: 'description' },
        { title: 'Būsena', align: 'end', key: 'status' },
        { title: 'Sukūrimo data', align: 'end', key: 'created_at' },
        { title: 'Paskutini kartą atnaujinta', align: 'end', key: 'updated_at' },
      ],
    }
  },
  components: {
    VDataTable
  },
  methods: {
    fetchOrders() {
      this.isLoading = true;
      apiClient.get(`${urlProvider.getServerEndpoint()}/orders`, { withCredentials: true })
        .then(response => {
          this.orderData = response.data.map(o => { return { ...o, created_at: new Date(o.created_at).toLocaleString(), updated_at: new Date(o.updated_at).toLocaleString() } });
          this.isLoading = false;
        })
        .catch(error => {
          console.error('Error fetching pallet data:', error);
          this.isLoading = false;
        });
    },
  },
  watch: {
    limit: {
      handler() {
        this.$router.push({ query: { "limit": this.limit, "page": this.page } }).catch(err => { });
        this.fetchPallets();
      },
    },
  },
  mounted() {
    if (this.orderData.length === 0) this.fetchOrders();
  },
  created() {
    this.$router.push({ query: { "limit": this.limit, "page": this.page } }).catch(err => { });
  },

}
</script>