<template>
    <div class="swiper-slide">
        <div class="program__card">
            <span class="program__card-title">{{'День ' +  day.number + ': ' + day.name}}</span>
            <div class="program__card-wrap-info">
                <div class="program__card-block-image">
                    <img :src="day.imageUrl" class="program__card-image" alt="">
                </div>
                <div class="program__card-block-text text">
                    <p>
                        {{ day.description }}
                    </p>
                </div>
            </div>
        </div>
    </div>
</template>
    
<script>


export default {
    components: {

    },

    props: {
        day: {
            type: Object,
            required: true,
        }
    },

    setup(props, {emit}) {

        return {
            
        };
    },
};

</script>
    
<style lang="scss">
    @import '@/assets/style/parts/components/program.scss'
</style>