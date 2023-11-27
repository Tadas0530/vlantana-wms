<template>
    <v-row justify="center">
        <v-dialog v-model="dialog" persistent width="1024">
            <v-card>
                <v-card-title>
                    <span class="text-h5">Užsakymo sukūrimas</span>
                </v-card-title>
                <v-card-text>
                    <v-container>
                        <v-row>
                            <v-col cols="12" sm="12" md="12">
                                <v-textarea label="Aprašymas*" v-model="formData.description" required></v-textarea>
                            </v-col>
                            <v-col cols="12" sm="6">
                                <v-select :items="['Skubus', 'Įprastas']" v-model="formData.status" label="Būsena*"
                                    required></v-select>
                            </v-col>
                            <v-col cols="12" sm="6">
                                <div class="d-flex justify-content-between">
                                    <span>Užsakymo peržiūra</span>
                                    <span>Palečių kiekis: {{ items.length }}</span>
                                </div>
                                <v-list max-height="250px" overflow-y lines="one">
                                    <v-list-item v-for="item in items" :key="item.barcode"
                                        :title="item.barcode + ' ' + item.name"
                                        :subtitle="`Atvykimo data: ${item.date_arrived} | Brokas: ${item.is_defective}`"></v-list-item>
                                </v-list>
                            </v-col>
                        </v-row>
                    </v-container>
                    <small>*privalomi laukai</small>
                </v-card-text>
                <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn @click="onClose" color="red-darken-1" variant="text">
                        Uždaryti
                    </v-btn>
                    <v-btn color="green-darken-1" variant="text" @click="handleOrderCreation">
                        Sukurti užsakymą
                    </v-btn>
                </v-card-actions>
            </v-card>
        </v-dialog>
    </v-row>
</template>

<script>
import urlProvider from '@/utils/url-provider';
import apiClient from '@/utils/api-client';
import { mapGetters } from 'vuex';

export default {
    emits: ['onModalClose'],
    data() {
        return {
            dialog: false,
            items: [],
            formData: {
                description: '',
                status: ''
            },
            requestWasMade: false
        }
    },
    computed: {
        ...mapGetters([
            'getSelectedCompany',
            'getIsClientMode'
        ])
    },
    methods: {
        toggleDialog(order_items) {
            this.dialog = !this.dialog;
            this.items = order_items
        },
        handleOrderCreation() {
            if (this.getIsClientMode) {
                apiClient.post(`${urlProvider.getServerEndpoint()}/orders`, { pallet_ids: this.items.map(i => { return i.id }), ...this.formData }, { withCredentials: true })
                    .then(response => {
                        console.log(response.data)
                        this.requestWasMade = true;
                        this.dialog = false;
                    })
                    .catch(error => {
                        console.error('Error fetching pallet data:', error);
                    });
            } else {
                apiClient.post(`${urlProvider.getServerEndpoint()}/orders`, { companyId: this.getSelectedCompany.id, pallet_ids: this.items.map(i => { return i.id }), ...this.formData }, { withCredentials: true })
                    .then(response => {
                        console.log(response.data)
                        this.requestWasMade = true;
                        this.dialog = false;
                    })
                    .catch(error => {
                        console.error('Error fetching pallet data:', error);
                    });
            }
        },
        onClose() {
            this.dialog = false;
            if (this.requestWasMade) {
                this.$emit('onModalClose');
                this.requestWasMade = false;
            }
        }
    }
}
</script>