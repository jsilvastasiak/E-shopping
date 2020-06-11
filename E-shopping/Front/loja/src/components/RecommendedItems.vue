<template>
    <div>
        <div class="recommended_items"><!--recommended_items-->
            <h2 class="title text-center">Artigos Recomendados</h2>
                                        
            <div id="recommended-item-carousel" class="carousel slide" data-ride="carousel">
                <div class="carousel-inner">
                    <div class="item active">	
                        <div class="col-sm-4" v-for="(produto,index) in produtosActive" :key="index">
                            <div class="product-image-wrapper">
                                <div class="single-products">
                                    <div class="productinfo text-center">
                                        <img :src="produto.imagem" alt="" />
                                        <h2 v-text="'R$' + produto.precounitario"></h2>
                                        <p v-text="produto.nome"></p>
                                        <a href="#" class="btn btn-default add-to-cart" v-on:click.prevent.stop="AddItem(produto)"><i class="fa fa-shopping-cart"></i>Adicionar</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="item">
                        <div class="col-sm-4" v-for="(produto,index) in produtos" :key="index">
                            <div class="product-image-wrapper">
                                <div class="single-products">
                                    <div class="productinfo text-center">
                                        <img :src="produto.imagem" alt="" />
                                        <h2 v-text="'R$' + produto.precounitario"></h2>
                                        <p v-text="produto.nome"></p>
                                        <a href="#" class="btn btn-default add-to-cart" v-on:click.prevent.stop="AddItem(produto)"><i class="fa fa-shopping-cart"></i>Adicionar</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <a class="left recommended-item-control" href="#recommended-item-carousel" data-slide="prev">
                    <i class="fa fa-angle-left"></i>
                </a>
                <a class="right recommended-item-control" href="#recommended-item-carousel" data-slide="next">
                    <i class="fa fa-angle-right"></i>
                </a>			
            </div>
        </div>
    </div>
</template>

<script>
    import Client from '../components/ApiClient.vue';
    import Cart from '../components/Cart.vue';

    export default {
        mixins: [Cart, Client],
        inject: ['api'],
        data(){
            return {
                produtosActive: [],
                produtos: [],
            };
        },
        methods: {
            GetProducts(){
                // GET /someUrl
                this.Get('/products', {})
                .then(response => {
                    if(response.length > 3){
                        this.produtosActive = response.slice(0,3);
                        this.produtos = response.slice(3);
                    }
                    else
                        this.produtosActive = response;

                    this.produtos.forEach(element => {
                        element.imagem = this.api.diretorioImagens + element.imagem + "?" + this.api.sas;
                    });
                    this.produtosActive.forEach(element => {
                        element.imagem = this.api.diretorioImagens + element.imagem + "?" + this.api.sas;
                    });
                });
            },
            AddItem(item){
                var newItem = this.CreateItem();
                newItem.IdProduto = item.idproduto;
                newItem.Price = item.precounitario;
                newItem.Image = item.imagem;
                newItem.Name = item.nome;
                newItem.Quantity = 1;

                this.AddToCart(newItem);
            }
        },
        created(){
            this.GetProducts();
        }
    }
</script>

<style scoped>
    .left{
        left:0;
    }
</style>