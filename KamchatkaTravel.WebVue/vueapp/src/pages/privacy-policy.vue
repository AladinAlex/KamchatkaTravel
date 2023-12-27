<template>
            <main class="page" data-page="main">
                <div class="privacy-policy-page" data-page="wrapper-content">
                    <PrivacyPolicy/>
                </div>
            </main>
</template>

<script>

import PrivacyPolicy from "@/assets/components/privacy-policy.vue";

export default {
    components: {
        PrivacyPolicy
    },

    setup() {

        return {

        };
    },
};

</script>

<style lang="scss">
    @import '@/assets/style/parts/pages/privacy-policy-page.scss'
</style>