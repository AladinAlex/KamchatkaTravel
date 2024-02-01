<template>
    <div class="sight-card">
        <div class="sight-card__block-image">
            <img :src="sight.imageUrl" class="sight-card__image" alt="  ">
        </div>
        <div class="sight-card__block-info">
            <span class="sight-card__title">{{ sight.name }}</span>
            <span class="sight-card__subtitle">{{ sight.description }}</span>
        </div>
    </div>
</template>

<script>




export default {
    props: {
        sight: {
            type: Object,
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