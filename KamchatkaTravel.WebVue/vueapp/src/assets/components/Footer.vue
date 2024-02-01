<template>
<footer class="footer">
    <div class="main-container max-width footer__main-container-nav">
        <div class="footer__wrap-logo">
            <a href="##" class="logo">
                <img :src="require('@/assets/images/logo-3.png')" class="logo__image" alt="">
            </a>
            <div class="footer__contacts">
                <router-link :to="'tel:'" :class="'footer__link'">+7 (918) 234-94-45</router-link>
                <!-- <a href="#" class="footer__link">+7 (918) 234-94-45</a> -->
                <SocialNetwork />
            </div>
        </div>
        <div class="footer__wrap-nav">
            <div class="footer__nav">
                <span class="footer__title">туры</span>
                <ul class="footer__nav-list list-reset">
                    <li class="footer__nav-li">
                        <a href="/home.html" class="footer__link">Все туры</a>
                    </li>
                </ul>
            </div>
            <div class="footer__nav">
                <span class="footer__title">команда</span>
                <ul class="footer__nav-list list-reset">
                    <li class="footer__nav-li">
                        <a href="#" class="footer__link">О нас</a>
                    </li>
                    <li class="footer__nav-li">
                        <a href="#" class="footer__link" data-smooth-scrolling="#reviews">Отзывы</a>
                    </li>
                </ul>
            </div>
            <div class="footer__nav">
                <span class="footer__title">Полезное</span>
                <ul class="footer__nav-list list-reset">
                    <li class="footer__nav-li">
                        <a href="/Privacy" class="footer__link">Политика конфиденциальности</a>
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <div class="main-container max-width">
        <div class="footer__wrap-copy">
            <span class="footer__copyright">&copy; Land in the ocean</span>
            <a href="https://andreyfront.github.io/presentation/dist/index.html" class="footer__dev link-reset" target="_blank">Сделано Andrey FD</a>
        </div>
    </div>
</footer>
</template>
    
<script>
import SocialNetwork from "@/ui/social-network.vue"

    export default {
      components: {
        SocialNetwork
      },
      setup() {
    
      }
    
    }
</script>
    
<style lang="scss">
    @import '@/assets/style/parts/components/footer.scss'
</style>