import Vue from 'vue'
import App from './App.vue'

import VueFilterDateFormat from 'vue-filter-date-format';
Vue.use(VueFilterDateFormat);

import VueResourse from 'vue-resource';
Vue.use(VueResourse);
Vue.http.options.root = 'https://localhost:5003';

new Vue({
  el: '#app',
  render: h => h(App)
})
