<template>
    <div class="text-center">
        <v-dialog @click:outside="closeDialog" v-model="dialog" width="auto">
            <v-card>
                <v-card-title>
                    <span class="text-h5">{{ itemName }}</span>
                </v-card-title>
                <v-container style="width: 80vh;">
                    <v-row>
                        <v-col v-for="item in items" cols="12" sm="12" md="6">
                            <v-text-field :model-value="item.value" style="min-width: 150px; min-height: 100px;"
                                :label="item.name">
                            </v-text-field>
                        </v-col>
                    </v-row>
                </v-container>
                <v-card-actions>
                    <v-btn color="primary" block @click="closeDialog">Uždaryti</v-btn>
                </v-card-actions>
            </v-card>
        </v-dialog>
    </div>
</template>

<script>
export default {
    data() {
        return {
            dialog: false,
            displayItem: { name: "Algis", age: 22 },
            // viable types order, pallet, product
            itemType: null,
            items: [],
            neededIds: null,
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
        }
    },
    methods: {
        displayOne(data) {
            this.neededIds = data.ids;
            this.itemType = data.type;
            Object.entries(data.item).forEach(entry => this.items.push(entry[1]));
            console.log('items' + JSON.stringify(this.items))
            this.dialog = true;
        },
        closeDialog() {
            this.dialog = false;
            this.itemType = null,
            this.items = [],
            this.neededIds = null
        }
    }
}
</script>