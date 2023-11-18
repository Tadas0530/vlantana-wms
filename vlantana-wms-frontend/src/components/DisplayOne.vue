<template>
    <div class="text-center">
      <v-dialog
        v-model="dialog"
        width="auto"
      >
        <v-card>
            <v-container style="width: 80vh;">
                <v-row>
                    <v-col v-for="(entry, index) in Object.entries(displayItem)" cols="12" sm="12" md="6">
                        <v-text-field :model-value="entry[1]" style="min-width: 150px; min-height: 100px;" :label="entry[0]">
                        </v-text-field>
                    </v-col>
                </v-row>
            </v-container>
          <v-card-actions>
            <v-btn color="primary" block @click="dialog = false">Close Dialog</v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
    </div>
</template>

<script>
export default {
    data() {
        return {
            dialog: true,
            displayItem: { name: "Algis", age: 22 },
            // viable types order, pallet, product
            itemType: null,
        }
    },
    methods: {
        displayOne(item, type) {
            this.itemType = type;
            this.displayItem = item;
        }
    }
}
</script>