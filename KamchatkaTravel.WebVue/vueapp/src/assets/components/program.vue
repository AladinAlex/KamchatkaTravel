<template>
    <section class="program section" data-program="main">
        <div class="main-container max-width">
            <div class="section__head">
                <h2 class="title title--h2 title-reset">Наша программа</h2>
                <div class="box-arrows">
                    <button type="button" class="arrow" data-program="btn-prev">
                        <InlineSvg :src="require('@/assets/icons/arrow-left.svg')" :class="'arrow__icon'"></InlineSvg>
                    </button>
                    <button type="button" class="arrow" data-program="btn-next">
                        <InlineSvg :src="require('@/assets/icons/arrow-right.svg')" :class="'arrow__icon'"></InlineSvg>
                    </button>
                </div>
            </div>
            <div class="swiper program__slider" data-program="slider">
                <div class="swiper-wrapper">
                    <ProgramCard :days="days"/>
                </div>
            </div>
        </div>
    </section>
</template>
    
<script>

import ProgramCard from "@/assets/components/program-card.vue";
import InlineSvg from "vue-inline-svg";

export default {
    components: {
        ProgramCard,
        InlineSvg
    },

    props: {

    },

    setup(props, {emit}) {

        return {
            days: [
                {
                    name: 'Горный массив Вачкажец',
                    number: 1,
                    description: 'Пройдя по горным тропам, вы увидите водопад, который берет свое начало с гор и образует древнее озеро Тахколоч, ставший настоящей жемчужиной данной долины. Затем ваш путь приведет к древнему кратеру вулкана с загадочным именем "Ледниковый цирк". Название ему дано благодаря своей классической форме, напоминающей ледниковую кромку. Это уникальное место представляет собой один из самых древних вулканов Камчатки, активно участвовавший в формировании этого полуострова. Маршрут протяженностью 12-14 км (без крутых подъемов) обещает захватывающий опыт. Пешее путешествие займет 5-6 часов, после чего вы вернетесь к месту стоянки автомобиля, где вас ждет возможность отдохнуть и насладиться обедом.',
                    imgLink: null,
                },
                {
                    name: 'Горный массив Вачкажец',
                    number: 2,
                    description: 'Пройдя по горным тропам, вы увидите водопад, который берет свое начало с гор и образует древнее озеро Тахколоч, ставший настоящей жемчужиной данной долины. Затем ваш путь приведет к древнему кратеру вулкана с загадочным именем "Ледниковый цирк". Название ему дано благодаря своей классической форме, напоминающей ледниковую кромку. Это уникальное место представляет собой один из самых древних вулканов Камчатки, активно участвовавший в формировании этого полуострова. Маршрут протяженностью 12-14 км (без крутых подъемов) обещает захватывающий опыт. Пешее путешествие займет 5-6 часов, после чего вы вернетесь к месту стоянки автомобиля, где вас ждет возможность отдохнуть и насладиться обедом.',
                    imgLink: null,
                },
            ]
        };
    },
};

</script>
    
<style lang="scss">
    @import '@/assets/style/parts/components/program.scss'
</style>