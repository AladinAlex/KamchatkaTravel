<template>
    <section class="feedback-form section" data-smooth-scrolling="feedback-form">
    <div class="main-container max-width">
        <div class="feedback-form__head">
            <h2 class="title title--h2 title-reset">Оставьте контакты и мы свяжемся с вами</h2>
            <span v-if="price && tour_name" class="feedback-form__subtitle">{{ tour_name + ' ' + price}} ₽</span>
        </div>
        <Form />
    </div>
</section>
</template>

<script>
import Form from "@/assets/components/form.vue";

export default {
    props: {
        price: {
            type: Number,
            required: true,
        },
        tour_name: {
            type: String,
            required: true,
        }
    },
    components: {
        Form
    },

    setup() {

        return {

        };
    },
};

</script>

<style lang="scss">
    @import '@/assets/style/parts/components/feedback-form.scss'
</style>