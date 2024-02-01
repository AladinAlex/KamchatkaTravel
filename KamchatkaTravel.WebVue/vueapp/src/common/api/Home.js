import ApiService from "@/common/api/index";
const apiUrl = 'Home';

export default {
    // ShipmentPosition: function (data) {
    //     data.BaseRequest.RequestId = uuidv4();
    //     return ApiService.post(`${apiUrl}/ShipmentPosition`, data)
    // },

    Index: function () {
        return ApiService.get(`${apiUrl}/Index`)
    }
}