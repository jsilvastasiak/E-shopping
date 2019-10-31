<script>
    export default {
        data(){
            return {
                Cart:{
                    Items: []
                }
            };
        },
        methods:{
            CreateItem(){
                return {
                    Id: Number,
                    Name: String,
                    Price: Number,
                    Quantity: Number,
                    Image: String
                };
            },
            AddToCart(item){
                this.Cart.Items.push(item);
                this._saveStorage();
            },
            RemoveCartItem(item){
                this.Cart.Items = this.Cart.Items.filter(function(sel){
                    return sel.Id !== item.Id;
                });
                this._saveStorage();
            },
            _saveStorage(){
                const parsed = JSON.stringify(this.Cart);
                localStorage.setItem('Cart', parsed);
            }
        },
        mounted(){
            if(localStorage.getItem("Cart")){
                try {
                    this.Cart = JSON.parse(localStorage.getItem("Cart"));
                } catch (error) {
                    localStorage.removeItem("Cart");
                }
            }
        }
    }
</script>