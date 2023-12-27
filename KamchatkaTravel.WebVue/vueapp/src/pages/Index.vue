<template>
    <main class="page">
        <div class="main-page">
            <Presentation :imgUrl="require('@/assets/images/kamchatka-1.jpg')"
                :title="'Камчатка'"
                :desc="'Чтобы выбрать лучшее приключение, поговорите с нашим гидом'"
                :button_text="'Поговорить с гидом'"
                />
            <Aboutus/>
            <Tours/>
            <Pictures/>
            <Faqs/>
            <Review/>
            <section class="feedback-form section" data-smooth-scrolling="feedback-form">
                <div class="main-container max-width">
                    <div class="feedback-form__head">
                        <h2 class="title title--h2 title-reset">Оставьте контакты и мы свяжемся с вами</h2>
                        <!-- <span class="feedback-form__subtitle">Камчатка: три вулкана и океан 78 000 ₽</span> -->
                    </div>
                    <!-- @include('./include/components/form.html') -->
                </div>
            </section>
        </div>
    </main>
    <!-- @include('./include/layouts/scripts.html') -->
</template>

<script>
import Presentation from "@/assets/components/presentation.vue";
import Aboutus from "@/assets/components/about-us.vue";
import Tours from "@/assets/components/Tours.vue";
import Pictures from "@/assets/components/Pictures.vue";
import Faqs from "@/assets/components/Faqs.vue";
import Review from "@/assets/components/reviews.vue";


export default {
    components: {
        Presentation,
        Aboutus,
        Tours,
        Pictures,
        Faqs,
        Review
    },

    setup() {

        return {

        };
    },
};

</script>

<style lang="scss">
        @import '@/assets/style/parts/_components.scss'
</style>