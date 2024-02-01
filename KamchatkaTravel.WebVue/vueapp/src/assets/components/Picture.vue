<template>

    <a  :href="image.imageUrl"
        :data-img="image.imageUrl"
        :data-thumb="image.imageUrl"
        data-alt="Example"
        data-height="2500"
        data-width="1667"
        data-modal-picture="link"
        class="pictures__link"
    >
        <img :src="image.imageUrl" class="pictures__image" alt="">
    </a>
    <!-- <a v-else v-for="(i, index) in imagesDefault" :key="index+10"
        :href="require(`@/assets/images/${i.imgLink}`)"
        :data-img="require(`@/assets/images/${i.imgLink}`)"
        :data-thumb="require(`@/assets/images/${i.imgLink}`)"
        data-alt="Example"
        data-height="2500"
        data-width="1667"
        data-modal-picture="link"
        class="pictures__link"
    >
        <img :src="require(`@/assets/images/${i.imgLink}`)" class="pictures__image" alt="">
    </a> -->
</template>

<script>

export default {
    props:{
        image: {
            type: Object,
            required: true,
        },
    },

    components: {

    },

    setup(props, {emit}) {
        
        return {
            imagesDefault: [
                {
                    imgLink: "MainPicturesSeparate/kamchatka-5.jpg"
                },
                {
                    imgLink: "MainPicturesSeparate/kamchatka-6.jpg"
                },
                {
                    imgLink: "MainPicturesSeparate/kamchatka-7.jpg"
                },
                {
                    imgLink: "MainPicturesSeparate/kamchatka-8.jpg"
                },
                {
                    imgLink: "MainPicturesSeparate/kamchatka-9.jpg"
                },
                {
                    imgLink: "MainPicturesSeparate/kamchatka-10.jpg"
                },
                {
                    imgLink: "MainPicturesSeparate/kamchatka-11.jpg"
                },
                {
                    imgLink: "MainPicturesSeparate/kamchatka-12.jpg"
                },
            ]
        };
    },
};

</script>

<style lang="scss">
    @import '@/assets/style/parts/components/picture.scss'
</style>