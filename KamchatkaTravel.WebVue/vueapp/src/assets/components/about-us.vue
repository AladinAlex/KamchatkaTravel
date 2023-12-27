<template>
    <section class="about-us section" data-smooth-scrolling="about">
    <div class="main-container max-width">
        <div class="about-us__wrap-info">
            <h2 class="title title--h2 title-reset">О нас</h2>
            <div class="text">
                <p>
                    "Land in the Ocean" – Ваш надежный партнер для незабываемых туров на прекрасном полуострове Камчатка.
                </p>

                <p>
                    Наши гиды – настоящие профессионалы, обладающие глубокими знаниями о местных достопримечательностях, уникальной флоре и фауне,
                    а также о безопасности во время путешевствий.
                </p>

                <p>
                    У нас высокий уровень сервиса и комфорта, мы тщательно разработали туры, так чтобы они соответствовали вашим предпочтениям.
                </p>

                <p>
                    Мы с нетерпением ждем возможности сопровождать Вас в Вашем удивительном путешествии по Камчатке!
                </p>
            </div>
        </div>
        <div class="about-us__wrap-image">
            <img :src="require('@/assets/images/ocean.jpg')" :class="'about-us__image'" alt="">
        </div>
    </div>
</section>
</template>
  
  <script>

  
  export default {
    components: {
    },
    setup(props, { emit }) { 
      

      return {
      };
    }
  };
  </script>
  
<style lang="scss">
        @import '@/assets/style/parts/components/about-us.scss'
</style>