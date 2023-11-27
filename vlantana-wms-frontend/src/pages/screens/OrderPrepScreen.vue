<template>
  <div v-if="getIsClientMode || getSelectedCompany">
    <h1 class="mt-4">Užsakymų surinkimai</h1>
    <p>Reikiamų užsakymų atrinkimui prekių sąrašas</p>
    <v-expansion-panels style="width: 75%;">
      <v-expansion-panel v-for="order in orderData" :key="order.id">
        <v-expansion-panel-title>
          <template v-slot:default="{ expanded }">
            <v-row no-gutters>
              <v-col cols="4" class="d-flex justify-start">
                {{ order.order_code }}
              </v-col>
              <v-col cols="8" class="text-grey">
                <v-fade-transition leave-absolute>
                  <span v-if="expanded" key="0">
                    {{ order.description }}
                  </span>
                  <span v-else key="1" class="text-truncate">
                    {{ order.status }}
                  </span>
                </v-fade-transition>
              </v-col>
            </v-row>
          </template>
        </v-expansion-panel-title>
        <v-expansion-panel-text>
          <v-row style="border-bottom: 1px solid black;">
            <v-col cols="12" md="3" lg="3" v-for="header in headers">
              {{ header }}
            </v-col>
          </v-row>
          <v-row :style="[pallet !== order.pallets[order.pallets.length - 1] ? 'border-bottom: 1px solid black' : '']"
            v-for="(pallet, index) in order.pallets" :key="pallet.id">
            <v-col :style="[pallet.status === orderNumber(order.order_code) ? 'background-color: green; color: white' : '']" cols="12" md="3" lg="3" :key="index">
              {{ index + 1}}
            </v-col>
            <v-col :style="[pallet.status === orderNumber(order.order_code) ? 'background-color: green; color: white' : '']" cols="12" md="3" lg="3" v-for="(value, key) in mapPalletNeededData(pallet)" :key="key">
              {{ value }}
            </v-col>
          </v-row>
        </v-expansion-panel-text>
      </v-expansion-panel>
    </v-expansion-panels>
  </div>
</template>
<script>
import orderService from '@/services/order-service';
import { EventBus } from '@/eventbus/event-bus';
import { mapGetters } from 'vuex';

export default {
  data() {
    return {
      orderData: [],
      headers: [
        'Eilės nr.',
        'Vieta',
        'Kiekis',
        'Pavadinimas'
      ]
    }
  },
  computed: {
    ...mapGetters([
      'getSelectedCompany',
      'getIsClientMode'
    ])
  },
  mounted() {
    EventBus.emit('open-loader');
    orderService.getOrdersWithPallets()
      .then(data => {
        this.orderData = data;
        EventBus.emit('close-loader');
      })
      .catch(error => {
        console.error('Error in component:', error);
        EventBus.emit('close-loader');
      });
  },
  methods: {
    mapPalletNeededData(pallet) {
      return {
        vieta: pallet.location,
        kiekis: pallet.quantity,
        pavadinimas: pallet.name,
      }
    },
    orderNumber(order_code) {
      console.log(order_code.split('-')[1])
      return order_code.split('-')[1];
    }
  }
}
</script>