<template>
    <div class="">
        <div class="d-flex justify-content-between">
            <Teleport to="body">
                <order-dialog @onModalClose="handleModalClose" ref="orderDialog"></order-dialog>
            </Teleport>
            <div>
                <h1 class="mt-4">Įmonei priklausantis inventorius</h1>
                <p>Pasirinkite prekes norint pradėti užsakymą</p>
            </div>
            <v-alert style="height: 80px; align-self: center; margin-left: 30px"  v-if="error" closable @click:close="warningOnClose" :text="`${lastSelectedItem.barcode} ${lastSelectedItem.name} jau priklauso užsakymui! Sudarius užsakymą paletė nebepriklausys senąjam užsakymui.`" type="warning"></v-alert>
            <v-btn @click="openDialog" v-if="selected.length !== 0 && !error" class="align-self-center"
                prepend-icon="mdi-check-circle">
                <template v-slot:prepend>
                    <v-icon color="success"></v-icon>
                </template>
                Sukurti užsakymą
            </v-btn>
        </div>
        <v-data-table hover v-model="selected" :headers="headers" :loading="isLoading"
            loading-text="Kraunami duomenys..." :items="palletData" v-model:items-per-page="limit" item-value="name"
            return-object show-select style="width: max-content;"></v-data-table>
    </div>
</template>

<script>
import urlProvider from '@/utils/url-provider';
import { VDataTable } from 'vuetify/labs/VDataTable'
import OrderDialog from '@/components/OrderDialog.vue';
import { Teleport } from 'vue';
import apiClient from '@/utils/api-client';

export default {
    components: {
        VDataTable,
        OrderDialog,
        Teleport
    },
    data() {
        return {
            headers: [
                {
                    title: 'Pavadinimas',
                    align: 'start',
                    key: 'name',
                },
                { title: 'Barkodas', align: 'end', key: 'barcode' },
                { title: 'Prekių kiekis ant paletės', align: 'end', key: 'quantity' },
                { title: 'Ar brokas', align: 'end', key: 'is_defective' },
                { title: 'Vieta', align: 'end', key: 'location' },
                { title: 'Būsena', align: 'end', key: 'status' },
                { title: 'Paletė atvyko', align: 'end', key: 'date_arrived' },
                { title: 'Paletė išvyko', align: 'end', key: 'date_exported' },
            ],
            palletData: [],
            selected: [],
            limit: 25,
            page: 1,
            isLoading: true,
            error: false,
            lastSelectedItem: {}
        }
    },
    methods: {
        fetchPallets() {
            this.isLoading = true;
            apiClient.get(`${urlProvider.getServerEndpoint()}/pallets`, { withCredentials: true })
                .then(response => {
                    this.palletData = response.data.map(p => { return { ...p, is_defective: p.is_defective ? 'Taip' : 'Ne' } });
                    this.isLoading = false;
                })
                .catch(error => {
                    console.error('Error fetching pallet data:', error);
                    this.isLoading = false;
                });
        },
        openDialog() {
            this.$refs.orderDialog.toggleDialog(this.selected);
        },
        warningOnClose(item) {
            console.log(item)
            this.error = false;
        },
        handleModalClose() {
            this.fetchPallets();
        }
    },
    created() {
        this.$router.push({ query: { "limit": this.limit, "page": this.page } }).catch(err => { });
    },
    watch: {
        limit: {
            handler() {
                this.$router.push({ query: { "limit": this.limit, "page": this.page } }).catch(err => { });
                this.fetchPallets();
            },
        },
        selected: {
            handler(oldSelection) {
                const lastItem = oldSelection[oldSelection.length-1]
                if (lastItem.order_id) {
                    console.log('has order id ' +  lastItem.order_id)
                    this.error = true;
                    this.lastSelectedItem = lastItem;
                }
            },
            deep: true
        }
    },
mounted() {
    if (this.palletData.length === 0) this.fetchPallets();
}
}
</script>