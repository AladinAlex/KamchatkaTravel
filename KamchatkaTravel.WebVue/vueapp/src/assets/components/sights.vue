<template>
    <section class="sights section section--theme--primary">
    <div class="main-container max-width">
        <h2 class="title title--h2 title-reset">Что увидим?</h2>
        <div class="sights__wrap-cards">
            <SightCard :sights="sights"/>
        </div>
    </div>
</section>
</template>

<script>

import SightCard from "@/assets/components/sight-card.vue";

export default {
    components: {
        SightCard
    },

    setup() {

        return {
            sights: [
                {
                    imgLink: null,
                    title: 'Три вулкана',
                    subtitle: 'Горелый, Мутновский и Авачинский'
                },
                {
                    imgLink: null,
                    title: 'Малая долина гейзеров',
                    subtitle: 'Малая долина гейзеров'
                },
                {
                    imgLink: null,
                    title: 'Горячие источники',
                    subtitle: '4 дня релакса'
                },
                {
                    imgLink: null,
                    title: 'Водопады',
                    subtitle: 'Фотопрогулка на Опасный и Южный'
                },
                {
                    imgLink: null,
                    title: 'Животный мир',
                    subtitle: 'суслики, сурки, медведи (издалека), лисы'
                },
                {
                    imgLink: null,
                    title: 'Океан',
                    subtitle: 'Отдых на берегу и уха по-камчатски'
                },
            ]
        };
    },
};

</script>

<style lang="scss">
    @import '@/assets/style/parts/components/sights.scss'
</style>