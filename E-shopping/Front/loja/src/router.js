import Vue from 'vue';
import Router from 'vue-router';
import Login from './views/Login.vue';
import Home from './views/Home.vue';
import Shop from './views/Shop.vue';
import Cart from './views/Cart.vue';
import Checkout from './views/Checkout.vue';
import ProductInfo from './views/ProductInfo.vue';
import Contact from './views/Contact.vue';
import BuyedSucess from './views/BuyedSucessful.vue';
import Register from './views/Register.vue';
import Logout from './views/Logout.vue';
import Compras from './views/Compras.vue';

Vue.use(Router);

export default new Router({
    routes:[
        {
            path: '/',
            name: "Index",
            component: Home
        },
        {
            path: '/login',
            name: "Login",
            component: Login
        },
        {
            path: '/logout',
            name: "Logout",
            component: Logout
        },
        {
            path: '/cart',
            name: "Cart",
            component: Cart
        },
        {
            path: '/checkout',
            name: "Checkout",
            component: Checkout
        },
        {
            path: '/shop',
            name: "Shop",
            component: Shop
        },
        {
            path: '/productinfo/:id',
            name: "Product Info",
            component: ProductInfo
        },
        {
            path: '/contact',
            name: "Contact",
            component: Contact
        },
        {
            path: '/buyedsucessful',
            name: "BuyedSucess",
            component: BuyedSucess
        },
        {
            path: '/register',
            name: "Register",
            component: Register
        },
        {
            path: '/compras',
            name: "Compras",
            component: Compras
        }
    ]
})