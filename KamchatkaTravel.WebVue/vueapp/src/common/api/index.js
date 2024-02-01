import axios from 'axios'

const ApiService = {
    query(resource, params) {
        return axios.get(resource, params)
    },

    get(resource, config) {
        return axios.get(`${resource}`, config)
    },

    post(resource, params, config) {
        return axios.post(`${resource}`, params, config)
    },

    update(resource, slug, params) {
        return axios.put(`${resource}/${slug}`, params)
    },

    put(resource, params) {
        return axios.put(`${resource}`, params)
    },

    patch(resource, params) {
        return axios.patch(`${resource}`, params)
    },

    delete(resource) {
        return axios.delete(resource)
    }
};

export default ApiService;
