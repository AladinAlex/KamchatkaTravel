<template>
<section class="advantages section">
    <div class="main-container max-width">
        <h2 class="title title--h2 title-reset">Давайте путешествовать вместе!</h2>
        <div class="advantages__wrap-cards">
            <AdvantageCard :advantages="null"/>
        </div>
    </div>
</section>
</template>
  
  <script>

import AdvantageCard from "@/assets/components/advantage-card.vue";

  
  export default {
    components: {
      AdvantageCard
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