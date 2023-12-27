<template>
    <section class="tours section">
      <div class="main-container max-width">
          <div class="section__head">
              <h2 class="title title--h2 title-reset">Туры</h2>
              <Sorting/>
          </div>
          <div class="tours__wrap-cards">
              <TourCard :tours="tours" />
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
    setup(props, { emit }) { 
      

      return {
        tours: [
            {
                route: 'trivulkana',
                imgLink: null,
                name: 'Камчатка: три вулкана и океан. 12+',
                dayCount: 1,
                nigthType: 1,
                price: 78000,

            },
            {
                route: 'lavoviepolya',
                imgLink: null,
                name: 'Камчатка: лавовые поля и активные вулканы. 12+',
                dayCount: 1,
                nigthType: 1,
                price: 95000,
            }
        ]
      };
    }
  };
  </script>
  
<style lang="scss">
        @import '@/assets/style/parts/components/tours.scss'
</style>