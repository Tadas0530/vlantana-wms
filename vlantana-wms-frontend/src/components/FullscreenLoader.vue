<template>
    <div class="text-center">
      <v-dialog
        v-model="dialog"
        :scrim="false"
        persistent
        width="auto"
      >
        <v-card
          color="primary"
        >
          <v-card-text>
            Kraunama...
            <v-progress-linear
              indeterminate
              color="white"
              class="mb-0"
            ></v-progress-linear>
          </v-card-text>
        </v-card>
      </v-dialog>
    </div>
  </template>

  <script>
import { EventBus } from '@/eventbus/event-bus';

    export default {
      data () {
        return {
          dialog: false,
        }
      },
      methods: {
        openLoader() {
            this.dialog = true;
        },
        closeLoader() {
            this.dialog = false;
        }
      },
      mounted() {
        EventBus.on('open-loader', this.openLoader)
        EventBus.on('close-loader', this.closeLoader)
      },
      beforeUnmount() {
        EventBus.off('open-loader')
        EventBus.off('close-loader')
      }
    }
  </script>