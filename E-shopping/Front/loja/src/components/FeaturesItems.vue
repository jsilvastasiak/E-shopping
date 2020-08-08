<template>
    <div>
        <h2 class="title text-center">Artigos</h2>
        <div class="col-sm-4" v-for="(produto,index) in produtos" :key="index">
            <div class="product-image-wrapper">
                <div class="single-products">
                    <div class="productinfo text-center">
                        <img :src='produto.imagem' alt="Camisa" />
                        <h2 v-text='"R$" + produto.precounitario'></h2>
                        <p v-text='produto.nome' v-on:click.prevent.stop="NavegarProduto(produto)"></p>
                        <a href="#" class="btn btn-default add-to-cart" v-on:click.prevent.stop="AddItem(produto)"><i class="fa fa-shopping-cart"></i>Adicionar</a>
                    </div>
                    <div class="product-overlay">
                        <div class="overlay-content">
                            <h2 v-text="'R$' + produto.precounitario"></h2>
                            <p v-text="produto.nome" v-on:click.prevent.stop="NavegarProduto(produto)"></p>
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
    import Client from '../components/ApiClient.vue'

    export default {
        mixins: [Client],
        inject: ['api','cart'],
        data(){
            return {
                produtos: []
            };
        },
        methods: {
            GetProducts(){
                // GET /someUrl
                this.Get('/products', {})
                .then(response => {
                    this.produtos = response;
                    this.produtos.forEach(element => {
                        element.imagem = this.api.diretorioImagens + element.imagem + "?" + this.api.sas;
                    });
                });
            },
            AddItem(item){
                var newItem = this.cart.CreateItem();
                newItem.IdProduto = item.idproduto;
                newItem.Price = item.precounitario;
                newItem.Image = item.imagem;
                newItem.Name = item.nome;
                newItem.Quantity = 1;

                this.cart.AddToCart(newItem);
            },
            NavegarProduto(item){
                this.$router.push("/productinfo/" + item.idproduto);
            }
        },
        created(){
            this.GetProducts();
        }
    }
</script>

<style lang="scss" scoped>

</style>