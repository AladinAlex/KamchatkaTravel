<template>
    <div class="block-sorting">
    <div class="sorting" data-sorting="main">
        <div class="sorting__block-head" data-sorting="block-head">
            <span class="sorting__title-head">Вид тура - однодневный</span>
        </div>
        <div class="sorting__block-body">
            <div class="radio">
                <label data-role="" class="radio__label">
                    <input type="radio" class="radio__input" name="view-sorting" value="" checked>
                    <span class="radio__text">Однодневный</span>
                    <span class="radio__decore"></span>
                </label>
            </div>
            <div class="radio">
                <label data-role="" class="radio__label">
                    <input type="radio" class="radio__input" name="view-sorting" value="">
                    <span class="radio__text">Многодневный</span>
                    <span class="radio__decore"></span>
                </label>
            </div>
        </div>
    </div>
    <div class="sorting" data-sorting="main">
        <div class="sorting__block-head" data-sorting="block-head">
            <span class="sorting__title-head">Cезон - Зима</span>
        </div>
        <div class="sorting__block-body">
            <div class="radio">
                <label data-role="" class="radio__label">
                    <input type="radio" class="radio__input" name="season-sorting" value="" checked>
                    <span class="radio__text">Зима</span>
                    <span class="radio__decore"></span>
                </label>
            </div>
            <div class="radio">
                <label data-role="" class="radio__label">
                    <input type="radio" class="radio__input" name="season-sorting" value="">
                    <span class="radio__text">Весна</span>
                    <span class="radio__decore"></span>
                </label>
            </div>
            <div class="radio">
                <label data-role="" class="radio__label">
                    <input type="radio" class="radio__input" name="season-sorting" value="">
                    <span class="radio__text">Лето</span>
                    <span class="radio__decore"></span>
                </label>
            </div>
            <div class="radio">
                <label data-role="" class="radio__label">
                    <input type="radio" class="radio__input" name="season-sorting" value="">
                    <span class="radio__text">Осень</span>
                    <span class="radio__decore"></span>
                </label>
            </div>
        </div>
    </div>
    <div class="sorting" data-sorting="main">
        <div class="sorting__block-head" data-sorting="block-head">
            <span class="sorting__title-head">По цене - возрастание</span>
        </div>
        <div class="sorting__block-body">
            <div class="radio">
                <label data-role="" class="radio__label">
                    <input type="radio" class="radio__input" name="price-sorting" value="" checked>
                    <span class="radio__text">Возрастание</span>
                    <span class="radio__decore"></span>
                </label>
            </div>
            <div class="radio">
                <label data-role="" class="radio__label">
                    <input type="radio" class="radio__input" name="price-sorting" value="">
                    <span class="radio__text">Убывание</span>
                    <span class="radio__decore"></span>
                </label>
            </div>
        </div>
    </div>
</div>
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
        @import '@/assets/style/parts/ui/sorting.scss'
</style>