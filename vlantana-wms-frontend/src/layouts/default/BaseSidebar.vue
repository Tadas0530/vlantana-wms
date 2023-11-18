<template>
  <div class="bg-light border-right" id="sidebar-wrapper">
    <div class="sidebar-heading">Inventoriaus valdymo sistema</div>
    <div class="list-group list-group-flush">
      <router-link to="/app/dashboard" class="list-group-item list-group-item-action bg-light">Apžvalga</router-link>
      <router-link to="/app/inventory" class="list-group-item list-group-item-action bg-light">Inventorius</router-link>
      <router-link to="/app/orders" class="list-group-item list-group-item-action bg-light">Užsakymai</router-link>
      <router-link to="/app/assigned-orders" class="list-group-item list-group-item-action bg-light">Užsakymų
        surinkimai</router-link>
        <router-link to="/app/scan" class="list-group-item list-group-item-action bg-light">Skenuoti prekę</router-link>
    </div>
  </div>
</template>
  

<script>
export default {

}
</script>

<style>
#sidebar-wrapper {
  min-height: 100vh;
  width: 250px;
  z-index: 1000;
  overflow-y: auto;
  position: fixed;
}
</style>