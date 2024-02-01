 <template>
    <!-- <a v-for="(t, index) in refTours2" :key="index" :href="t.route" class="tour-card"> -->
    <!-- <a :href="tour.id" class="tour-card"> -->
    <router-link :to="'/tour/' + tour.routeName" class="tour-card">
        <div class="tour-card__block-image">
            <img :src="[tour.logoImageUrl ? tour.logoImageUrl : require('@/assets/images/kamchatka-2.jpg')]" :class="'tour-card__image'" alt="">
        </div>
        <div class="tour-card__wrap-info">
            <span class="tour-card__title">{{ tour.name }}</span>
            <span class="tour-card__desc">{{ (tour.dayCount ?? 0) + ' ' + getDayFormat(tour.dayCount) + " | " + getNightType(tour.nightType) }}</span>
            <div class="tour-card__block-price">
                <span class="tour-card__price">{{ getPrice(tour.price) }} р</span>
                <button type="button" class="btn btn--size--md btn--theme--tertiary">
                    <span class="btn__text">Хочу поехать</span>
                </button>
            </div>
        </div>
    </router-link>
</template>
  
  <script>
  import { ref, reactive, watch } from "vue";
  import { useRouter } from 'vue-router';

  export default {
    components: {
    },
    // emits: ["emits"],
    props: {

        tour: {
            type: Object,
            required: true,
        }
    },
    setup(props, { emit }) { 
      
        const getDayFormat = (count) => {
            return 'день'
        }
        
        const getNightType = (nightType) => {
            return 'без ночевки'
        }
        const getPrice = (price) => {
            return price
        }

      return {
        getDayFormat,
        getNightType,
        getPrice
      };
    }
  };
  </script>
  
<style lang="scss">
        @import '@/assets/style/parts/components/tour-card.scss'
</style>