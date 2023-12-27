<template>
    <div class="wrapper-page">
        <Header />
        <router-view />
        <Footer />

        <msuccess/>
    </div>
</template>
  
  <script>
  import Header from "@/assets/components/Header-dark.vue";
  import Footer from "@/assets/components/Footer.vue";
  import msuccess from "@/modal-windows/m-success.vue";

  
  export default {
    name: "layout-default",
    components: {
        Header,
        Footer,
        msuccess
    },
    setup(props, { emit }) { 
      

      return {
      };
    }
  };
  </script>
  
<style lang="scss">
    @import '@/assets/style/parts/layouts/default.scss';
    // @import '@/assets/style/main.scss';
</style>