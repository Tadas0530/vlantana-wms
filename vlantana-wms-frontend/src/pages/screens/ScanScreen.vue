<template>
    <div class="" style="width: max-content;">
        <h1 class="mt-4">Skenuokite barkodą</h1>
        <p>Barkodo skenavimas - paletė susideda is 15 simbolių, produktas iš 20.</p>
        <v-text-field ref="barcodeInput" label="Barkodas" v-model="barcode">
        </v-text-field>
        <v-btn @click="getRecord" v-if="barcode.length === 15 || barcode.length === 20" class="align-self-center"
            prepend-icon="mdi-check-circle">
            <template v-slot:prepend>
                <v-icon color="success"></v-icon>
            </template>
            Ieškoti
        </v-btn>
        <span v-if="error" style="color: red;" class="ms-3">Barkodas nerastas.</span>
    </div>
</template>

<script>
import apiClient from '@/utils/api-client';
import { EventBus } from '@/eventbus/event-bus';

export default {
    data() {
        return {
            barcode: '',
            fetchedItem: null,
            itemType: null,
            error: false
        }
    },
    methods: {
        getRecord() {
            EventBus.emit('open-loader');
            this.itemType = this.barcode.length == 15 ? 'pallet' : 'product'
            this.fetchedItem = null;
            this.error = false;

            apiClient.post(`/${this.itemType}/barcode`, { barcode: this.barcode }, { withCredentials: true })
                .then(response => {
                    EventBus.emit('close-loader');
                    this.fetchedItem = response.data;
                    if (Object.keys(this.fetchedItem).length === 0) {
                        this.error = true;
                    } else {
                        this.displayOne();
                    }
                })
                .catch(error => {
                    EventBus.emit('close-loader');
                    this.error = true;
                    console.error('Error fetching scanned data:', error);
                });
        },
        displayOne() {
            // pallet
            let reformatedItem = null;
            if (this.itemType === 'pallet') {
                reformatedItem = {
                    item: {
                        barcode: { name: 'Barkodas', value: this.fetchedItem.barcode },
                        date_arrived: { name: 'Paletė atvyko', value: this.fetchedItem.date_arrived },
                        date_exported: { name: 'Paletė išvyko', value: this.fetchedItem.date_exported },
                        is_defective: { name: 'Ar brokas', value: this.fetchedItem.is_defective ? 'Taip' : 'Ne' },
                        location: { name: 'Vieta', value: this.fetchedItem.location },
                        name: { name: 'Pavadinimas', value: this.fetchedItem.name },
                        status: { name: 'Būsena', value: this.fetchedItem.status },
                        quantity: { name: 'Prekių kiekis ant paletės', value: this.fetchedItem.quantity },
                    },
                    type: 'pallet',
                    action: 'display',
                    ids: { id: this.fetchedItem.id, company_id: this.fetchedItem.company_id, order_id: this.fetchedItem.order_id }
                }
            } else {
                reformatedItem = {
                    item: {
                        barcode: { name: 'Barkodas', value: this.fetchedItem.barcode },
                        expiry_date: { name: 'Galiojimo data', value: this.fetchedItem.expiry_date },
                        production_date: { name: 'Pagaminimo data', value: this.fetchedItem.production_date },
                        name: { name: 'Pavadinimas', value: this.fetchedItem.name },
                        status: { name: 'Būsena', value: this.fetchedItem.status },
                        description: { name: 'Aprašymas', value: this.fetchedItem.description },
                    },
                    type: 'product',
                    action: 'display',
                    ids: { id: this.fetchedItem.id, company_id: this.fetchedItem.company_id, order_id: this.fetchedItem.order_id }
                }
            }
            this.$emit('displayItem', reformatedItem)
        },
    },
    mounted() {
        this.$refs.barcodeInput.focus();
    }
}
</script>

<style></style>