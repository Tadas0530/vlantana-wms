<template>
  <router-view />
</template>

<script>
import urlProvider from "@/utils/url-provider.js"

export default {
  // beforeCreate() {
  //   this.$axios.get(`${urlProvider.getServerEndpoint()}/auth/check`, { withCredentials: true })
  //   .then(response => {
  //       if (response.data.isAuthenticated) this.$router.push(localStorage.getItem('lastRoute'))
  //   })
  // }
}
</script>
