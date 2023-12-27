<template>
    <div v-for="(sight, index) in sights" :key="index" class="sight-card">
        <div class="sight-card__block-image">
            <img :src="sight.imgLink" class="sight-card__image" alt="">
        </div>
        <div class="sight-card__block-info">
            <span class="sight-card__title">{{ sight.title }}</span>
            <span class="sight-card__subtitle">{{ sight.subtitle }}</span>
        </div>
    </div>
</template>

<script>




export default {
    props: {
        sights: {
            type: Array,
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
    @import '@/assets/style/parts/components/sight-card.scss'
</style>