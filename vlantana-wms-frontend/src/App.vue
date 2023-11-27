<template>
  <router-view />
</template>

<script>
import { useRouter } from 'vue-router';
import { setupInterceptors } from './utils/api-client';

export default {
  beforeCreate() {
    const router = useRouter();
    setupInterceptors(router);
  }
}
</script>
