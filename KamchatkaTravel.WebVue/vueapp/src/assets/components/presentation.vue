<template>
    <section class="presentation" data-presentation="main">
        <div class="presentation__block-bg" data-presentation="block-parallax">
            <img :src="[imgUrl ? imgUrl : require('@/assets/images/kamchatka-1.jpg')]" :class="'presentation__bg'" data-depth="0.2" alt="">
        </div>
        <div class="main-container max-width">
            <div class="presentation__wrap-content">
                <div class="presentation__block-info">
                    <h1 class="title title--h1 title-reset">{{ title }}</h1>
                    <span class="presentation__desc">{{ desc }}</span>
                    <button type="button" class="btn btn--size--bg btn--theme--secondary presentation__btn" data-smooth-scrolling="#feedback-form">
                        <span class="btn__text">{{ button_text }}</span>
                    </button>
                </div>
            </div>
            <div v-if="day_count && price && nigth_type" class="presentation__wrap-conditions">
                <div class="presentation__block-conditions">
                    <img :src="require('@/assets/images/day-night.png')" class="presentation__icon-conditions" alt="">
                    <span class="presentation__text-conditions">{{ day_count + ' ' + getDayFormat(day_count) + " | " + getNigthType(nigth_type) }}</span>
                </div>
                <div class="presentation__block-conditions">
                    <img :src="require('@/assets/images/ruble.png')" class="presentation__icon-conditions" alt="">
                    <span class="presentation__text-conditions">{{ getPrice(price) }} | чел</span>
                </div>
            </div>
        </div>
    </section>
</template>

<script>
export default {
    props: {
        imgUrl: {
            type: String,
            required: true,
        },
        title:
        {
            type: String,
            required: true,
        },
        desc:
        {
            type: String,
            required: true,
        },
        button_text:
        {
            type: String,
            required: true,
        },
        day_count: {
            type: Number,
            required: false,
        },
        price: {
            type: Number,
            required: false,
        },
        nigth_type:{
            type: Number,
            required: false,
        }
    },
    components: {

    },

    setup() {
        const getDayFormat = (count) => {
            return 'День'
        }
        
        const getNigthType = (nigthType) => {
            return 'без ночевки'
        }
        const getPrice = (price) => {
            return price
        }
        return {
            getDayFormat,
            getNigthType,
            getPrice
        };
    },
};

</script>

<style lang="scss">
    @import '@/assets/style/parts/components/presentation.scss'
</style>