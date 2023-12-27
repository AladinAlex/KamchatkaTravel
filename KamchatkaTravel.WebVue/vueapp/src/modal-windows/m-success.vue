<template>
<div class="hystmodal modal m-success" id="m-success" aria-hidden="true">
    <div class="hystmodal__wrap">
        <div class="hystmodal__window" role="dialog" aria-modal="true">
            <button data-hystclose class="hystmodal__close">
                <InlineSvg :class="'modal__close-icon'" :src="require('@/assets/icons/cross-dark.svg')"></InlineSvg>
            </button>
            <h2 class="title title--h2 title-reset">Заявка отправлена!</h2>
            <span class="modal__subtitle">Мы свяжемся с вами в ближайшее время.</span>
        </div>
    </div>
</div>
</template>
  
<script>
  import Header from "@/assets/components/Header.vue";
  import Footer from "@/assets/components/Footer.vue";

  
  export default {
    name: "layout-default",
    components: {
        Header,
        Footer,
    },
    setup(props, { emit }) {
      
      return {
      };
    }
  };
</script>
  
<style lang="scss">
    @import '@/assets/style/parts/modal-windows/m-success.scss';
</style>