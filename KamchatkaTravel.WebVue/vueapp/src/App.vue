<template>
  <component :is="layout" />
</template>

<script>
import { defineAsyncComponent, markRaw } from "vue";

export default {
  data() {
    return {
      layout: null,
    };
  },
  watch: {
    $route(to, from) {
      document.title = to.meta.title || "Land in the ocean";
      // this.$store.dispatch("pageTitle/back");
      if (this.layout === null || to.meta?.layout !== from.meta?.layout) {
        this.layout = markRaw(
          defineAsyncComponent(() =>
            import(`@/layouts/${to.meta?.layout || "default"}.vue`)
            // import(`@/pages/Index.vue`)
          )
        );
      }
    },
  },
};
</script>

<style>

</style>
