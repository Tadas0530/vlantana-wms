<template>
    <div class="container-fluid p-0" style="width: max-content;">
        <Teleport to="body">
            <display-one ref="displayOneDialog"></display-one>
            <fullscreen-loader ref="loader"></fullscreen-loader>
        </Teleport>
        <base-sidebar></base-sidebar>
        <div class="take-up-space">
            <router-view @displayItem="displayItem"></router-view>
        </div>
    </div>
</template>
  
<script>
import BaseSidebar from '@/layouts/default/BaseSidebar.vue';
import MainScreen from '@/pages/screens/MainScreen.vue';
import DisplayOne from '@/components/DisplayOne.vue';
import FullscreenLoader from '@/components/FullscreenLoader.vue';
import { EventBus } from '@/eventbus/event-bus';

export default {
    data() {
        return {
            itemToDisplay: null,
        }
    },
    components: {
        BaseSidebar,
        MainScreen,
        DisplayOne,
        FullscreenLoader
    },
    methods: {
        displayItem(data) {
            this.$refs.displayOneDialog.displayOne(data);
        }
    },
    beforeUnmount() {
        EventBus.all.clear()
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