<template>
    <div class="social-network">
    <router-link :to="'#'" :class="'social-network__link link-reset'" title="Написать в Телеграм">
                <InlineSvg :src="require('@/assets/icons/telegram.svg')" :class="'social-network__icon'"></InlineSvg>
    </router-link>
    <router-link :to="'#'" :class="'social-network__link link-reset'" title="Написать в WhatsApp">
                <InlineSvg :src="require('@/assets/icons/whatsapp.svg')" :class="'social-network__icon'"></InlineSvg>
    </router-link>
    <router-link :to="'#'" :class="'social-network__link link-reset'" title="Написать в Instagram">
                <InlineSvg :src="require('@/assets/icons/instagram.svg')" :class="'social-network__icon'"></InlineSvg>
    </router-link>
</div>
</template>

<script>
import InlineSvg from "vue-inline-svg";

export default {

    components: {
        InlineSvg
    },
    setup() {
    }
}
</script>

<style lang="scss">
    @import '@/assets/style/parts/ui/social-network.scss'
</style>