import Vue from 'vue'
import App from './App.vue'
import router from './router'
import './plugins/element.js'

import axios from 'axios'
import VueAxios from 'vue-axios'
Vue.use(VueAxios, axios)


Vue.config.productionTip = false
Vue.prototype.ApiUrl = "https://localhost:5001/api/"

new Vue({
  router,
  render: h => h(App)
}).$mount('#app')
