<template>
    <section class="faq section" data-faq="main" data-smooth-scrolling="faq">
        <div class="main-container max-width">
            <h2 class="title title--h2 title-reset">Частые вопросы о туре</h2>
            <div class="faq__wrap-cards">

                <Faq v-for="(f, index) in faqs?.sort((a, b) => a.ord - b.ord)" :key="index" :faq="f" />

            </div>
        </div>
    </section>
</template>

<script>
  import Faq from "@/assets/components/Faq.vue";

export default {
    components: {
        Faq
    },
    props: {
      faqs: {
          type: Array,
          required: true,
      }
    },

    setup() {

        return {
            
        };
    },
};

</script>

<style lang="scss">
    @import '@/assets/style/parts/components/faqs.scss'
</style>