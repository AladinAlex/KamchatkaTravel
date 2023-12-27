<template>
    <a v-for="(i, index) in images" :key="index"
        :href="i.imgLink"
        :data-img="i.imgLink"
        :data-thumb="i.imgLink"
        data-alt="Example"
        data-height="2500"
        data-width="1667"
        data-modal-picture="link"
        class="pictures__link"
    >
        <!-- <img :src="i.imgLink" class="pictures__image" alt=""> -->
        <img :src="i.imgLink" class="pictures__image" alt="">
    </a>
</template>

<script>

export default {
    props:{
        images: {
            type: Array,
            required: true,
        },
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
    @import '@/assets/style/parts/components/picture.scss'
</style>