<template>
    <div class="text-center">
        <v-dialog @click:outside="closeDialog" @keydown.esc="closeDialog" v-model="dialog" width="auto">
            <v-card>
                <v-card-title>
                    <span class="text-h5">{{ itemName }}</span>
                </v-card-title>
                <v-container style="width: 80vh;">
                    <v-row>
                        <v-col v-for="item in items" cols="12" sm="12" md="6">
                            <v-text-field :autofocus="item.name === 'Barkodas'" v-model="item.value" style="min-width: 150px; min-height: 100px;"
                                :label="item.name">
                            </v-text-field>
                        </v-col>
                    </v-row>
                </v-container>
                <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn @click="closeDialog" color="red-darken-1" variant="text">
                        Ištrinti
                    </v-btn>
                    <v-btn @click="closeDialog" color="yellow-darken-1" variant="text">
                        Uždaryti
                    </v-btn>
                    <v-btn color="green-darken-1" :disabled="!hasDataChanged" variant="text" @click="handleUpdate">
                        Atnaujinti
                    </v-btn>
                </v-card-actions>
            </v-card>
        </v-dialog>
    </div>
</template>

<script>
import objectUtils from '@/utils/object-utils';

export default {
    data() {
        return {
            dialog: false,
            displayItem: { name: "Algis", age: 22 },
            // viable types order, pallet, product
            itemType: null,
            items: [],
            neededIds: null,
            initialItemsState: null,
            itemName: ''
        }
    },
    computed: {
        itemName() {
            switch (this.itemType) {
                case 'pallet':
                    return "Paletė"
                case 'order':
                    return "Užsakymas"
                case 'product':
                    return "Produktas"
            }
        },
        hasDataChanged() {
        return !objectUtils.deepEqual(this.items, this.initialItemsState);
    }
    },
    methods: {
        displayOne(data) {
            this.neededIds = data.ids;
            this.itemType = data.type;
            Object.entries(data.item).forEach(entry => this.items.push(entry[1]));
            this.initialItemsState = JSON.parse(JSON.stringify(this.items))
            this.dialog = true;
        },
        closeDialog() {
            console.log('closed')
            this.dialog = false;
            this.itemType = null,
            this.items = [],
            this.neededIds = null
        },
        handleUpdate() {
            console.log('not implemented')
        }
    },
}
</script>