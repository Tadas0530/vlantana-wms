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
            <v-alert style="height: 80px; align-self: center; margin-left: 30px" v-if="error" closable
                @click:close="warningOnClose"
                :text="`${lastSelectedItem.barcode} ${lastSelectedItem.name} jau priklauso užsakymui! Sudarius užsakymą paletė nebepriklausys senąjam užsakymui.`"
                type="warning"></v-alert>
            <v-btn @click="openDialog" v-if="selected.length !== 0 && !error" class="align-self-center"
                prepend-icon="mdi-check-circle">
                <template v-slot:prepend>
                    <v-icon color="success"></v-icon>
                </template>
                Sukurti užsakymą
            </v-btn>
        </div>
        <v-data-table @click:row="displayOne" hover v-model="selected" :headers="headers" :loading="isLoading"
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
    emits: [
        'displayItem'
    ],
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
        },
        displayOne(event, item) {
            const itemToFormat = item.item;
            const reformatedItem = {
                    item: {
                        barcode: { name: 'Barkodas', value: itemToFormat.barcode },
                        date_arrived: { name: 'Paletė atvyko', value: itemToFormat.date_arrived },
                        date_exported: { name: 'Paletė išvyko', value: itemToFormat.date_exported },
                        is_defective: { name: 'Ar brokas', value: itemToFormat.is_defective },
                        location: { name: 'Vieta', value: itemToFormat.location },
                        name: { name: 'Pavadinimas', value: itemToFormat.name },
                        status: { name: 'Būsena', value: itemToFormat.status },
                        quantity: { name: 'Prekių kiekis ant paletės', value: itemToFormat.quantity },
                    },
                    type: 'pallet',
                    ids: { id: itemToFormat.id, company_id: itemToFormat.company_id, order_id: itemToFormat.order_id }
                }
            this.$emit('displayItem', reformatedItem)
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
                const lastItem = oldSelection[oldSelection.length - 1]
                if (lastItem.order_id) {
                    console.log('has order id ' + lastItem.order_id)
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

<styles>
</styles>