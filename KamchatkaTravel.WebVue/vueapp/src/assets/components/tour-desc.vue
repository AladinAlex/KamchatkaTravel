<template>
<section class="tour-desc section">
    <div class="main-container max-width">
        <h2 class="title title--h2 title-reset">Описание тура</h2>
        <div class="tour-desc__wrap-content">
            <div class="tour-desc__block-image">
                <img :src="[imgLink ? imgLink : require('@/assets/images/kamchatka-2.jpg')]" class="tour-desc__image" alt="">
            </div>
            <div class="tour-desc__block-text text">
                <span class="get-type-description" v-html="desc"></span>
            </div>
        </div>
    </div>
</section>
</template>

<script>

export default {
    props: {
        imgLink: {
            type:   String,
            required: true,
        },
        desc: {
            type:   String,
            required: true,
        }
    },
    components: {

    },

    setup() {

        return {

        };
    },
};
</script>

<style lang="scss">
    @import '@/assets/style/parts/components/tour-desc.scss'
</style>