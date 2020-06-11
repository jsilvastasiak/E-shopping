import Vue from 'vue'
import App from './App.vue'
import Router from './router'
import VueResource from 'vue-resource'

Vue.config.productionTip = false
Vue.use(VueResource);

new Vue({
  provide:{
    api: {
      baseUrl: "https://localhost:44372/api",
      diretorioImagens: "https://cs2496c7b05ef5fx4459xb88.file.core.windows.net/eshopping",
      sas: "sv=2019-10-10&ss=f&srt=so&sp=r&se=2030-12-08T01:55:22Z&st=2020-06-07T17:55:20Z&spr=https&sig=2wXkaOVYZuupXS3H65kp8kg9bWFyRxTQFbghEXsgSGk%3D",
      token: "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Ik1hcmxlaSIsInByb3BpZXRhcmlvIjoiMyIsImxvamEiOiIxIiwibmJmIjoxNTkxNzQ5OTM2LCJleHAiOjE1OTIzNTQ3MzYsImlhdCI6MTU5MTc0OTkzNn0.2eFznxp15I5aOslYl8p-LBohUyybPxmHQZKI3BhEptY"
    },
    cart: {
      items: []
    }
  },
  router: Router,
  render: h => h(App),
}).$mount('#app');
