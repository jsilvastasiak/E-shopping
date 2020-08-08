import Vue from 'vue'
import App from './App.vue'
import Router from './router'
import VueResource from 'vue-resource'

Vue.config.productionTip = false
Vue.use(VueResource);

var Cart = function(){
  this.items = [];
  if(localStorage.getItem("Cart")){
    try {
      this.items = JSON.parse(localStorage.getItem("Cart"));
    } catch (error) {
      localStorage.removeItem("Cart");
    }
  }
};
Cart.prototype = {
    CreateItem: function(){
        return {
            Id: Number,
            IdProduto: Number,
            Name: String,
            Price: Number,
            Quantity: Number,
            Image: String
        };
    },
    AddToCart: function(item){
        item.Id = this.items.length + 1;
        this.items.push(item);
        this._saveStorage();
        console.log(item);
    },
    RemoveCartItem: function(item){
        this.items = this.items.filter(function(sel){
            return sel.Id !== item.Id;
        });
        this._saveStorage();
    },
    GetAllItems: function(){
        return this.items;
    },
    ClearCar: function(){
        this.items = [];
        this._saveStorage();
    },
    _saveStorage: function(){
        const parsed = JSON.stringify(this.items);
        localStorage.setItem('Cart', parsed);
    }
}

var Usuario = function(){
  this.usuario = {};
  if(localStorage.getItem("Usuario_shoopper")){
    try {
      this.usuario = JSON.parse(localStorage.getItem("Usuario_shoopper"));
    } catch (error) {
      localStorage.removeItem("Usuario_shoopper");
    }
  }
}
Usuario.prototype = {
  Logout: function(){
    this.usuario = {};
    this._saveStorage();
  },
  Current: function(){
    return this.usuario;
  },
  SetUsuario: function(pessoa, email){
    this.usuario = { idpessoa: pessoa, email:  email};
    this._saveStorage();
  },
  _saveStorage: function(){
      const parsed = JSON.stringify(this.usuario);
      localStorage.setItem('Usuario_shoopper', parsed);
  }
}

new Vue({
  provide:{
    api: {
      baseUrl: "https://localhost:44372/api",
      diretorioImagens: "https://cs2496c7b05ef5fx4459xb88.file.core.windows.net/eshopping",
      sas: "sv=2019-10-10&ss=f&srt=so&sp=r&se=2030-12-08T01:55:22Z&st=2020-06-07T17:55:20Z&spr=https&sig=2wXkaOVYZuupXS3H65kp8kg9bWFyRxTQFbghEXsgSGk%3D",
      token: "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Ik1hcmxlaSIsInByb3BpZXRhcmlvIjoiMyIsImxvamEiOiIxIiwibmJmIjoxNTk2ODU4ODEwLCJleHAiOjE1OTc0NjM2MTAsImlhdCI6MTU5Njg1ODgxMH0.ecQsXSQzTtRcJmur_niM0_vozUCz-xhRoabK_hq19dY"
    },
    cart: new Cart(),
    usuario: new Usuario()
  },
  router: Router,
  render: h => h(App),
}).$mount('#app');
