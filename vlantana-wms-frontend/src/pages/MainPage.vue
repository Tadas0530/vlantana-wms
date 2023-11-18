<template>
    <div class="container-fluid p-0">
        <base-sidebar></base-sidebar>
        <router-view class="take-up-space"></router-view>
    </div>
</template>
  
<script>
import BaseSidebar from '@/layouts/default/BaseSidebar.vue';
import MainScreen from '@/pages/screens/MainScreen.vue';

export default {
    components: {
        BaseSidebar,
        MainScreen
    }
}
</script>
  
<style>
.container-fluid {
    display: grid;
    grid-template-columns: 1fr 6fr;
    /* Adjust the ratio as needed */
    grid-gap: 20px;
}

.take-up-space {
    margin-left: 300px;
}
</style>