import Vue from 'vue'
import App from './App.vue'

import VueFilterDateFormat from 'vue-filter-date-format';
Vue.use(VueFilterDateFormat);

import VueResourse from 'vue-resource';
Vue.use(VueResourse);
Vue.http.options.root = 'https://localhost:5003';

import VueRouter from 'vue-router';
Vue.use(VueRouter);

import { routes } from './routes';
const router = new VueRouter({
  routes: routes
})



import './directives/Sexo';

new Vue({
  el: '#app',
  router: router,
  render: h => h(App)
})
