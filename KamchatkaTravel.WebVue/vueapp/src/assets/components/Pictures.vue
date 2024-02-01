<template>
<section class="pictures" data-modal-picture="main">

    <template v-if="images && images.length">
        <Picture v-for="(i, index) in images" :key="index" :image="i" />
    </template>
    <template v-else>
        <Picture v-for="(i, index) in imagesDefault" :key="index" :image="i" />
    </template>

</section>
</template>

<script>
import Picture from "@/assets/components/Picture.vue";


export default {
    props: {
        images: {
            type: Array,
            required: true,
        }
    },

    components: {
        Picture
    },

    setup(props) {

        console.log('props.images')
        console.log(props.images)
        return {
            imagesDefault: [
                {
                    imageUrl:  require('@/assets/images/MainPicturesSeparate/kamchatka-5.jpg')
                },
                {
                    imageUrl: require('@/assets/images/MainPicturesSeparate/kamchatka-6.jpg')
                },
                {
                    imageUrl: require('@/assets/images/MainPicturesSeparate/kamchatka-7.jpg')
                },
                {
                    imageUrl: require('@/assets/images/MainPicturesSeparate/kamchatka-8.jpg')
                },
                {
                    imageUrl: require('@/assets/images/MainPicturesSeparate/kamchatka-9.jpg')
                },
                {
                    imageUrl: require('@/assets/images/MainPicturesSeparate/kamchatka-10.jpg')
                },
                {
                    imageUrl: require('@/assets/images/MainPicturesSeparate/kamchatka-11.jpg')
                },
                {
                    imageUrl: require('@/assets/images/MainPicturesSeparate/kamchatka-12.jpg')
                },
            ]
        };
    },
};

</script>

<style lang="scss">
        @import '@/assets/style/parts/components/pictures.scss'
</style>