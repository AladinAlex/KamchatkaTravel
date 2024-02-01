import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import axios from 'axios'
import VueAxios from 'vue-axios'
import config from './common/config'

import '@/assets/scripts/main.js'


const app = createApp(App)

app.use(VueAxios, axios)
    .use(router)

app.mount('#app')

axios.defaults.baseURL = config.API_URL
axios.defaults.withCredentials = false //true - надо включить cookie на сервер и тогда ставить true