<template>
    <div v-for="(r, index) in reviews" :key="index" class="swiper-slide">
        <div class="review-card">
            <div class="review-card__block-image">
                <img :src="[r.imgUrl ? r.imgUrl : require('@/assets/images/Default_review_logo.jpg')]" class="review-card__image" alt="">
            </div>
            <span class="review-card__name">{{ r.fi }}</span>
            <span class="review-card__date">{{ r.date }}г</span>
            <div class="review-card__text">
                <p>{{ r.text }}</p>
            </div>
        </div>
    </div>
</template>
    
<script>


export default {
    components: {

    },

    props: {
        reviews: {
            type: Array,
            required: true,
        }
    },

    setup(props, {emit}) {

        return {
            
        };
    },
};

</script>
    
<style lang="scss">
    @import '@/assets/style/parts/components/review-card.scss'
</style>