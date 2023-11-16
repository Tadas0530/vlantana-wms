<template>
    <div class="container-fluid p-0">
        <base-sidebar></base-sidebar>
        <main-screen></main-screen>
    </div>
</template>
  
<script>
import BaseSidebar from '@/components/BaseSidebar.vue';
import MainScreen from '@/components/MainScreen.vue';

export default {
    components: {
        BaseSidebar,
        MainScreen
    }
}
</script>
  
<style>
.container {
    display: grid;
    grid-template-columns: 1fr 3fr;
    /* Adjust the ratio as needed */
    grid-gap: 20px;
}
</style>