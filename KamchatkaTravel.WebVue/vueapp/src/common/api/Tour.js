import ApiService from "@/common/api/index";
const apiUrl = 'Tour';

export default {
    TourById: function (tourId) {
        return ApiService.get(`${apiUrl}/Tour/${tourId}`)
    },
    TourByName: function (tourName) {
        return ApiService.get(`${apiUrl}/Tour/${tourName}`)
    }
}
