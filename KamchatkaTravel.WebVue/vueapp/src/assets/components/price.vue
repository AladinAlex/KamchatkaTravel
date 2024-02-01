<template>
    <section class="price section">
    <div class="price__wrap-image">
        <img :src="imgLink" class="price__image" data-scroll-parallax alt="">
    </div>
    <div class="main-container max-width">
        <div class="price__wrap-info">
            <h2 class="title title--h2 title-reset">Стоимость {{ price }} ₽/чел</h2>
            <div class="price__wrap-blocks">
                <div class="price__block-info">
                    <span class="price__block-title">Входит в стоимость:</span>
                    <ul v-if="includes?.filter(x => x.isInclude).length > 0" class="price__list">
                        <li v-for="(include, index) in includes?.filter(x => x.isInclude).sort((a, b) => a.number - b.number)" :key="index" class="price__li">{{ include.text }}</li>
                    </ul>
                </div>
                <div class="price__block-info">
                    <span class="price__block-title">Не входит в стоимость:</span>
                    <ul v-if="includes?.filter(x => !x.isInclude).length > 0" class="price__list">
                        <li v-for="(include, index) in includes?.filter(x => !x.isInclude).sort((a, b) => a.number - b.number)" :key="index" class="price__li">{{ include.text }}</li>
                    </ul>
                </div>
            </div>
            <a v-if="false" href="" type="download" class="price__link link-reset">Скачать список снаряжения</a>
        </div>
    </div>
</section>
</template>

<script>

export default {
    props: {
        imgLink: {
            type: String,
            required: true,
        },
        price: {
            type: Number,
            required: true,
        },
        includes: {
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
    @import '@/assets/style/parts/components/price.scss'
</style>