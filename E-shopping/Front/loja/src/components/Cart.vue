<script>
    export default {
        inject: ['cart'],
        data(){
            return {};
        },
        methods:{
            CreateItem(){
                return {
                    Id: Number,
                    IdProduto: Number,
                    Name: String,
                    Price: Number,
                    Quantity: Number,
                    Image: String
                };
            },
            AddToCart(item){
                item.Id = this.cart.items.length + 1;
                this.cart.items.push(item);
                this._saveStorage();
                console.log(item);
            },
            RemoveCartItem(item){
                this.cart.items = this.cart.items.filter(function(sel){
                    return sel.Id !== item.Id;
                });
                this._saveStorage();
            },
            GetAllItems(){
                return this.cart.items;
            },
            ClearCar(){
                this.cart.items = [];
                this._saveStorage();
            },
            _saveStorage(){
                const parsed = JSON.stringify(this.cart);
                localStorage.setItem('Cart', parsed);
            }
        },
        mounted(){
            if(localStorage.getItem("Cart")){
                try {
                    this.cart = JSON.parse(localStorage.getItem("Cart"));
                } catch (error) {
                    localStorage.removeItem("Cart");
                }
            }
        }
    }
</script>