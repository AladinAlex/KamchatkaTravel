 <template>
    <a v-for="(t, index) in tours" :key="index" :href="t.route" class="tour-card">
        <div class="tour-card__block-image">
            <img :src="[t.imgLink ? t.imgLink : require('@/assets/images/kamchatka-2.jpg')]" :class="'tour-card__image'" alt="">
        </div>
        <div class="tour-card__wrap-info">
            <span class="tour-card__title">{{ t.name }}</span>
            <span class="tour-card__desc">{{ (t.dayCount ?? 0) + ' ' + getDayFormat(t.dayCount) + " | " + getNigthType(t.nigthType) }}</span>
            <div class="tour-card__block-price">
                <span class="tour-card__price">{{ getPrice(t.price) }} р</span>
                <button type="button" class="btn btn--size--md btn--theme--tertiary">
                    <span class="btn__text">Хочу поехать</span>
                </button>
            </div>
        </div>
    </a>
</template>
  
  <script>
  

  export default {
    components: {
    },
    // emits: ["emits"],
    props: {

        tours: {
            type: Array,
            required: true,
        }
    },
    setup(props, { emit }) { 
      
        const getDayFormat = (count) => {
            return 'день'
        }
        
        const getNigthType = (nigthType) => {
            return 'без ночевки'
        }
        const getPrice = (price) => {
            return price
        }
      return {
        getDayFormat,
        getNigthType,
        getPrice
      };
    }
  };
  </script>
  
<style lang="scss">
        @import '@/assets/style/parts/components/tour-card.scss'
</style>