<template>
    <!-- <div v-for="(f, index) in faqs" :key="index" class="faq__block" data-faq="block"> -->
    <div class="faq__block" data-faq="block">
        <div class="faq__block-head" data-faq="head">
            <span class="faq__block-title">{{ faq.name }}</span>
            <InlineSvg :src="require('@/assets/icons/plus.svg')" :class="'faq__block-icon'"></InlineSvg>
        </div>
        <div class="faq__block-body text" data-faq="body">
            <p>
                {{ faq.answer }}
            </p>
        </div>
    </div>
</template>

<script>
import InlineSvg from "vue-inline-svg";

export default {
    components: {
        InlineSvg
    },

    props: {
        faq: {
            type: Object,
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
    @import '@/assets/style/parts/components/faq.scss'
</style>