<template>
    <form action="" class="form">
    <div class="input">
        <input type="text" class="input__field" placeholder="Ваше имя *" required>
    </div>
    <div class="input">
        <input type="email" class="input__field" placeholder="Ваш email *" required>
    </div>
    <div class="input">
        <input type="phone" class="input__field" placeholder="Ваш телефон *" data-phone-mask required>
    </div>
    <button type="submit" class="btn btn--size--bg btn--theme--secondary">
        <span class="btn__text">Отправить</span>
    </button>
    <span class="form__privacy-policy">Нажимая кнопку, вы соглашаетесь с <a href="/privacy-policy.html" class="link-reset">Политикой конфиденциальности</a></span>
</form>
</template>

<script>

export default {
    components: {

    },

    setup() {

        return {

        };
    },
};

</script>

<style lang="scss">
    @import '@/assets/style/parts/components/form.scss'
</style>