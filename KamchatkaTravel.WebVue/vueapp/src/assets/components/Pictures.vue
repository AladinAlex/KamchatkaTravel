<template>
<section class="pictures" data-modal-picture="main">

    <Picture :images="images ?? imagesDefault" />
    
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

    setup() {

        return {
            imagesDefault: [
                {
                    imgLink: "img/kamchatka-5.963ea4a4.jpg"
                },
                {
                    imgLink: "img/kamchatka-5.963ea4a4.jpg"
                },
                {
                    imgLink: "img/kamchatka-5.963ea4a4.jpg"
                },
                {
                    imgLink: "img/kamchatka-5.963ea4a4.jpg"
                },
                {
                    imgLink: "img/kamchatka-5.963ea4a4.jpg"
                },
                {
                    imgLink: "img/kamchatka-5.963ea4a4.jpg"
                },
                {
                    imgLink: "img/kamchatka-5.963ea4a4.jpg"
                },
                {
                    imgLink: "img/kamchatka-5.963ea4a4.jpg"
                },
            ]
        };
    },
};

</script>

<style lang="scss">
        @import '@/assets/style/parts/components/pictures.scss'
</style>