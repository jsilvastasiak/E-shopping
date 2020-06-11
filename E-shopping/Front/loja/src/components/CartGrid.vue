<template>
    <div>
        <div class="table-responsive cart_info">
            <table class="table table-condensed">
                <thead>
                    <tr class="cart_menu">
                        <td class="image">Item</td>
                        <td class="description"></td>
                        <td class="price">Preço</td>
                        <td class="quantity">Quantidade</td>
                        <td class="total">Total</td>
                        <td></td>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="(item, index) in CartItems" :key="index">
                        <td class="cart_product">
                            <a href="#/productinfo"><img :src="item.Image" alt=""></a>
                        </td>
                        <td class="cart_description">
                            <h4><a href="#/productinfo">{{item.Name}}</a></h4>
                            <p v-text="'Web ID: '+ item.Id"></p>
                        </td>
                        <td class="cart_price">
                            <p v-text='"R$ " + item.Price'></p>
                        </td>
                        <td class="cart_quantity">
                            <div class="cart_quantity_button">
                                <a class="cart_quantity_up" v-on:click.prevent.stop="SetQuantity(item, 1)"> + </a>
                                <input class="cart_quantity_input" type="number" name="quantity" v-model="item.Quantity" autocomplete="off" size="2">
                                <a class="cart_quantity_down" v-on:click.prevent.stop="SetQuantity(item, -1)"> - </a>
                            </div>
                        </td>
                        <td class="cart_total">
                            <p class="cart_total_price" v-text='"R$ " + GetTotalItem(item)'></p>
                        </td>
                        <td class="cart_delete">
                            <a class="cart_quantity_delete" v-on:click.prevent.stop="RemoveItem(item)"><i class="fa fa-times"></i></a>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>

<script>

    export default {
        inject: ['cart'],
        data(){
            return{
                CartItems: []
            }
        },
        methods: {
            RemoveItem(selected){
                this.cart.RemoveCartItem(selected);
                this.CartItems = this.cart.GetAllItems();
            },
            SetQuantity(item, value){
                item.Quantity = parseInt(item.Quantity) + value;
            },
            GetTotalItem(sel){
                return sel.Price * sel.Quantity;
            }
        },
        mounted(){
            this.CartItems = this.cart.GetAllItems();
        }
    }
</script>

<style scoped>
.cart_product > a > img{
    width: 110px;
    height: 110px;
}
.quantity{
    text-align: left;
}
.total{
    min-width: 95px;
}
.cart_quantity_input{
    width: 50px;
}
</style>