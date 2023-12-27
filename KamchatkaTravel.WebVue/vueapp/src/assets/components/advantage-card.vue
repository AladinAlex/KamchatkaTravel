<template>
    <div v-for="(adv, index) in advantages" class="info-card">
        <div class="info-card__block-image">
            <img :src="adv.imgLink" class="info-card__image" alt="">
        </div>
        <div class="info-card__block-info">
            <span class="info-card__title">{{ adv.title }}</span>
            <span class="info-card__desc">{{ adv.description }}</span>
        </div>
    </div>
</template>
      
<script>


export default {
    props: {
        advantages: {
            type: Array,
            required: true,
        }
    },
    components: {

    },
    setup(props, { emit }) { 
        
        return {
        };
    }
};

</script>

<style lang="scss">
    @import '@/assets/style/parts/components/advantages.scss'
</style>