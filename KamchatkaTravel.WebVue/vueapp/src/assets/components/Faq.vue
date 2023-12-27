<template>
    <div v-for="(f, index) in faqs" :key="index" class="faq__block" data-faq="block">
        <div class="faq__block-head" data-faq="head">
            <span class="faq__block-title">{{ f.ask }}</span>
            <InlineSvg :src="require('@/assets/icons/plus.svg')" :class="'faq__block-icon'"></InlineSvg>
        </div>
        <div class="faq__block-body text" data-faq="body">
            <p>
                {{ f.question }}
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
    @import '@/assets/style/parts/components/faq.scss'
</style>