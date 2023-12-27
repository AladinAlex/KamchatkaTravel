<template>
<header class="header" data-header="main">
    <a href="##" class="logo">
        <img :src="require('@/assets/images/logo-3.png')" class="logo__image" alt="">
    </a>
    <div class="header__burger" data-header="btn-menu">
        <span></span>
        <span></span>
        <span></span>
    </div>
    <div class="header__menu" data-header="menu">
        <nav class="header__nav">
            <ul class="header__nav-ul list-reset" data-header="nav-ul">
                <li class="header__nav-li">
                    <a class="header__nav-link" data-smooth-scrolling="#about" name="about">О нас</a>
                </li>
                <li class="header__nav-li">
                    <a class="header__nav-link" data-smooth-scrolling="#tours" name="tours">Туры</a>
                </li>
                <li class="header__nav-li">
                    <a class="header__nav-link" data-smooth-scrolling="#reviews" name="reviews">Отзывы</a>
                </li>
            </ul>
        </nav>
        <SocialNetwork />
        <div class="header__block-links">
            <a href="tel:79182349445" class="btn btn--size--md btn--theme--primary">
                <span class="btn__text">+7 (918) 234-94-45</span>
            </a>
        </div>
    </div>
</header>
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
    @import '@/assets/style/parts/components/header.scss'
</style>