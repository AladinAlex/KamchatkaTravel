<template>
                <main class="page">
                <div class="tour-page">
                    <Presentation :imgUrl="tour.logoImageUrl"
                        :title="tour.name"
                        :desc="tour.tagline"
                        :button_text="'Хочу поехать'"
                        :day_count = tour.days?.length
                        :price = tour.price
                        :nigth_type = tour.nightType
                    />
                    <TourDesc   :imgLink="tour.descriptionImageUrl"
                                :desc="tour.description"
                    />
                    <Sights :sights="tour.views"/>
                    <Pictures :images="tour.images"/>
                    <Program :days="tour.days"/>
                    <Price :price = tour.price :imgLink="tour.logoImageUrl" :includes="tour.includes"/>
                    <Faqs :faqs="tour.questions"/>
                    <FeedbackForm />
                </div>
            </main>
</template>

<script>
import Presentation from "@/assets/components/presentation.vue";
import TourDesc from "@/assets/components/tour-desc.vue";
import Sights from "@/assets/components/sights.vue";
import Pictures from "@/assets/components/Pictures.vue";
import Program from "@/assets/components/program.vue";
import Price from "@/assets/components/price.vue";
import Faqs from "@/assets/components/Faqs.vue";
import Review from "@/assets/components/reviews.vue";
import FeedbackForm from "@/assets/components/feedback-form.vue";
import { ref, onMounted, watch, reactive } from 'vue';
import ApiTour from "@/common/api/Tour";

export default {
    components: {
        Presentation,
        TourDesc,
        Sights,
        Pictures,
        Program,
        Price,
        Faqs,
        Review,
        FeedbackForm
    },

    props: {
        name: {
            type: String,
            required: true,
        }
    },

    setup(props, {emit}) {

        let tour = ref({
            // name: null,
            // tagline: null,
            // logoImageUrl: null
        });

        const getTour = async() => {
            await ApiTour.TourByName(props.name).then((r) => {
                if(r.status == 200) {
                    
                    tour.value = r.data.tour
                    console.log('tour')
                    console.log(tour)
                    // document.title = 'Land in the Ocean - ' + tour.value.name
                    document.title = tour.value.name
                }
            })
            .catch((err) => console.log("getTour: " + err))
        }

        getTour();
        return {
            tour
        };
    },
};

</script>

<style lang="scss">
        // @import '@/assets/style/parts/_components.scss'
        @import '@/assets/style/parts/_components.scss'
</style>