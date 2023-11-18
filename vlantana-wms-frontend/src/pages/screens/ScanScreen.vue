<template>
  <div class="" style="width: max-content;">
    <h1 class="mt-4">Skenuokite barkodą</h1>
    <p>Barkodo skenavimas</p>
    <v-text-field label="Barkodas" v-model="barcode">

    </v-text-field>
  </div>
</template>

<script>
export default {
    data() {
        return {
            barcode: ''
        }
    }
}
</script>

<style>

</style>