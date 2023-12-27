<template>
            <main class="page">
                <div class="tour-page">
                    <Presentation :imgUrl="require('@/assets/images/kamchatka-1.jpg')"
                        :title="'Камчатка: три вулкана и океан'"
                        :desc="'Программа по чек-листу «Что нужно сделать на Камчатке». Возраст 12+'"
                        :button_text="'Хочу поехать'"
                        :day_count = 1
                        :price = 78000
                        :day-nigth_type = 1
                    />
                    <TourDesc   :imgLink="'@/assets/images/kamchatka-2.jpg'"
                                :desc="'<p> Камчатка – край вулканов, медведей и необузданной природы! Этот маршрут – лидирует по впечатлениям уже несколько лет благодаря попаданию 100 из 100! </p> <p>     А всё потому, что в рамках тура мы выполняем чек лист «Что обязательно должен сделать каждый турист на Камчатке»: </p> <ul>     <li>подняться на кратер действующего вулкана;</li>     <li>узнать, как пахнут фумаролы;</li>     <li>покормить суслика с ладошки;</li>     <li>увидеть медведя;</li>     <li>отдохнуть в диком горячем источнике;</li>     <li>искупаться в Тихом океане;</li>     <li>попробовать камчатские морепродукты.</li> </ul> <p>Активный маршрут без тяжелых рюкзаков с релаксом в горячих источниках!!!</p>'"
                    />
                    <Sights/>
                    <Pictures/>
                    <Program/>
                    <Price :price = 78000 :imgLink="null" :includes="[]"/>
                    <Faqs/>
                    <Review/>
                    <FeedbackForm/>
                </div>
            </main>
</template>

<script>
import Presentation from "@/assets/components/presentation.vue";
import TourDesc from "@/assets/components/tour-desc.vue";
import Sights from "@/assets/components/sights.vue";
import Pictures from "@/assets/components/Pictures.vue";
import Program from "@/assets/components/program.vue";
import Price from "@/assets/components/price.vue";
import Faqs from "@/assets/components/Faqs.vue";
import Review from "@/assets/components/reviews.vue";
import FeedbackForm from "@/assets/components/feedback-form.vue";


export default {
    components: {
        Presentation,
        TourDesc,
        Sights,
        Pictures,
        Program,
        Price,
        Faqs,
        Review,
        FeedbackForm
    },

    setup() {

        return {

        };
    },
};

</script>

<style lang="scss">
        // @import '@/assets/style/parts/_components.scss'
        @import '@/assets/style/parts/_components.scss'
</style>