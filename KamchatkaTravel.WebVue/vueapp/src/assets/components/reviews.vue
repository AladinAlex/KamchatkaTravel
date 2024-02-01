<template>
<section class="reviews section" data-reviews="main" data-smooth-scrolling="reviews">
    <div class="main-container max-width">
        <div class="section__head">
            <h2 class="title title--h2 title-reset">Отзывы путешественников</h2>
            <div class="box-arrows">
                <button type="button" class="arrow" data-reviews="btn-prev">
                    <InlineSvg :src="require('@/assets/icons/arrow-left.svg')" :class="'arrow__icon'"></InlineSvg>
                </button>
                <button type="button" class="arrow" data-reviews="btn-next">
                    <InlineSvg :src="require('@/assets/icons/arrow-right.svg')" :class="'arrow__icon'"></InlineSvg>
                </button>
            </div>
        </div>
        <div class="swiper program__slider" data-reviews="slider">
            <div class="swiper-wrapper">
                    <ReviewCard v-for="(r, index) in reviewList" :key="index" :review="r"/>
            </div>
        </div>
    </div>
</section>
</template>
    
<script>
import InlineSvg from "vue-inline-svg";
import ReviewCard from "@/assets/components/review-card.vue";

export default {
    components: {
        InlineSvg,
        ReviewCard
    },

    props: {
        reviewList: {
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
    @import '@/assets/style/parts/components/reviews.scss'
</style>