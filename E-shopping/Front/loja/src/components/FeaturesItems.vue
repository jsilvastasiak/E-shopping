<template>
    <div>
        <h2 class="title text-center">Artigos</h2>
        <div class="col-sm-4" v-for="(produto,index) in produtos" :key="index">
            <div class="product-image-wrapper">
                <div class="single-products">
                    <div class="productinfo text-center">
                        <img :src='produto.image' alt="Camisa" />
                        <h2 v-text='"R$" + produto.PriceValue'></h2>
                        <p v-text='produto.Name'></p>
                        <a href="#" class="btn btn-default add-to-cart" v-on:click.prevent.stop="AddItem(produto)"><i class="fa fa-shopping-cart"></i>Adicionar</a>
                    </div>
                    <div class="product-overlay">
                        <div class="overlay-content">
                            <h2 v-text="'R$' + produto.PriceValue"></h2>
                            <p v-text="produto.Name"></p>
                            <a href="#" class="btn btn-default add-to-cart" v-on:click.prevent.stop="AddItem(produto)"><i class="fa fa-shopping-cart"></i>Adicionar</a>
                        </div>
                    </div>
                </div>
                <div class="choose">
                    <ul class="nav nav-pills nav-justified">
                        <li><a href="#"><i class="fa fa-plus-square"></i>Lista de Desejos</a></li>
                        <li><a href="#"><i class="fa fa-plus-square"></i>Lista de Comparação</a></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    import Cart from '../components/Cart.vue'

    export default {
        mixins: [Cart],
        data(){
            return {
                produtos: []
            };
        },
        methods: {
            GetProducts(){
                // GET /someUrl
                this.$http.get('http://localhost:3000/produtos')
                .then(response => response.json())
                .then(response => {
                    this.produtos = response;
                });
            },
            AddItem(item){
                var newItem = this.CreateItem();
                newItem.Id = item.Id;
                newItem.Price = item.PriceValue;
                newItem.Image = item.image;
                newItem.Name = item.Name;
                newItem.Quantity = 1;

                this.AddToCart(newItem);
            }
        },
        created(){
            this.GetProducts();
        }
    }
</script>

<style lang="scss" scoped>

</style>