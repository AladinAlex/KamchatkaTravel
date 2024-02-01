<template>
    <section class="tours section">
      <div class="main-container max-width">
          <div class="section__head">
              <h2 class="title title--h2 title-reset">Туры</h2>
              <Sorting/>
          </div>
          <div class="tours__wrap-cards">
              <TourCard v-for="(t, index) in tours" :key="index" :tour="t"/>
          </div>
      </div>
  </section>
</template>
  
  <script>
  import Sorting from "@/assets/components/sorting.vue";
  import TourCard from "@/assets/components/tour-card.vue";

  export default {
    components: {
        Sorting,
        TourCard
    },
    props: {
      tours: {
          type: Array,
          required: true,
      }
    },
    setup(props, { emit }) { 

      return {
        
      };
    }
  };
  </script>
  
<style lang="scss">
        @import '@/assets/style/parts/components/tours.scss'
</style>