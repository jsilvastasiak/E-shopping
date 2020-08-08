<template>
    <div>
        <MasterHeader />
        <div class="col-sm-3">
            <CategoryItems />
        </div>
        <div class="col-sm-9 padding-right">
            <div class="product-details"><!--product-details-->
                
                <div class="col-sm-5">
                    <div class="view-product">
                        <img :src='imagemselecionada.caminhodiretorio' alt="" />
                    </div>
                    <div id="similar-product" class="carousel slide" data-ride="carousel">
                            <!-- Wrapper for slides -->
                            <div class="carousel-inner">
                                <div v-bind:class="[{ active: index == 0 }, 'item']" v-for="(grupo, index) in imagensagrupadas" :key="index">
                                    <a href="" v-for="(item,ind) in grupo.imagens" :key="ind" v-on:click.prevent.stop="SelecionarImagem(item)">
                                        <img :src='item.caminhodiretorio' alt="" class="largura-imagem">
                                    </a>
                                </div>
                            </div>

                            <!-- Controls -->
                            <a class="left item-control" href="#similar-product" data-slide="prev">
                            <i class="fa fa-angle-left"></i>
                            </a>
                            <a class="right item-control" href="#similar-product" data-slide="next">
                            <i class="fa fa-angle-right"></i>
                            </a>
                    </div>
                </div>
                <div class="col-sm-7">
                    <div class="product-information"><!--/product-information-->
                        <img src="images/product-details/new.jpg" class="newarrival" alt="" />
                        <h2>{{ produto.nome }}</h2>
                        <p>Web ID: {{ produto.idproduto}}</p>
                        <img src="images/product-details/rating.png" alt="" />
                        <br />
                        <span>
                            <span v-text='"R$ " + produto.precounitario'></span>
                            <label>Quantity:</label>
                            <input type="text" v-model="contador.valor" />
                            <button type="button" class="btn btn-fefault cart" v-on:click.prevent.stop="AddItem(produto)">
                                <i class="fa fa-shopping-cart"></i>
                                Adicionar
                            </button>
                        </span>
                        <p><b>Disponível: </b> Em estoque</p>
                        <p><b>Marca: </b>{{produto.marca}}</p>
                    </div><!--/product-information-->
                </div>
            </div><!--/product-details-->
        </div>
    </div>
</template>

<script>
    import MasterHeader from '../components/MasterHeader.vue';
    import CategoryItems from '../components/CategorysItems.vue'
    import Client from '../components/ApiClient.vue';

    export default {
        inject: ['api','usuario','cart'],
        mixins: [Client],
        components:{
            MasterHeader,
            CategoryItems
        },
        data(){
            return {
                contador: {valor:1},
                produto: {},
                imagens: [],
                imagensagrupadas: [ {imagens: []}],
                imagemselecionada: {}
            };
        },
        methods:{
            GetProduto(id){
                this.Get('/products/' + id).then(response => {
                    if(response){
                        this.produto = response;
                        this.produto.imagem = this.api.diretorioImagens + this.produto.imagem + "?" + this.api.sas;
                    }else{
                        console.log(response);
                    }
                });
            },
            GetImagens(id){
                this.Get('/products/' + id + "/imagens").then(response => {
                    if(response){
                        let contgrupo = 0;
                        let contregistro = 0;
                        this.imagens = response;
                        this.imagens.forEach(element => {
                            element.caminhodiretorio = this.api.diretorioImagens + element.caminhodiretorio + "?" + this.api.sas;
                            if(element.imagemprincipal === "S")
                                this.imagemselecionada = element;
                            contregistro++;
                            if(contregistro == 4){
                                contregistro = 1;
                                contgrupo++;
                                this.imagensagrupadas.push({imagens: []});
                            }
                            this.imagensagrupadas[contgrupo].imagens.push(element);
                        });
                    }else{
                        console.log(response);
                    }
                });
            },
            AddItem(item){
                var newItem = this.cart.CreateItem();
                newItem.IdProduto = item.idproduto;
                newItem.Price = item.precounitario;
                newItem.Image = item.imagem;
                newItem.Name = item.nome;
                newItem.Quantity = this.contador.valor;

                this.cart.AddToCart(newItem);
            },
            SelecionarImagem(imagem){
                this.imagemselecionada = imagem;
            }
        },
        created(){
            this.GetProduto(this.$route.params.id);
            this.GetImagens(this.$route.params.id);
        }
    }
</script>

<style lang="css" scoped>
    .largura-imagem{
        width: 100px;
        height: auto;
    }
</style>