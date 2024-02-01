<template>
    <!-- <div v-for="(r, index) in reviews" :key="index" class="swiper-slide"> -->
    <div class="swiper-slide">
        <div class="review-card">
            <div class="review-card__block-image">
                <img :src="[review.logoImageUrl ? review.logoImageUrl : require('@/assets/images/Default_review_logo.jpg')]" class="review-card__image" alt="">
            </div>
            <span class="review-card__name">{{ getName(review.firstName, review.lastName) }}</span>
            <span class="review-card__date">{{ review.date }}г</span>
            <div class="review-card__text">
                <p>{{ review.text }}</p>
            </div>
        </div>
    </div>
</template>
    
<script>


export default {
    components: {

    },

    props: {
        review: {
            type: Object,
            required: true,
        }
    },

    setup(props, {emit}) {

        const getName = (firstName, lastName) => {
            return firstName + ' ' + Array.from(lastName)[0] + '.'
        }

        return {
            getName
        };
    },
};

</script>
    
<style lang="scss">
    @import '@/assets/style/parts/components/review-card.scss'
</style>