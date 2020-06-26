<template>
    <div>
        <MasterHeader />
        <div class="step-one">
            <h2 class="heading">Passo 1</h2>
        </div>
        <div class="checkout-options">
            <h3></h3>
            <p>Opções de Checkout</p>
        </div><!--/checkout-options-->

        <div class="register-req" v-show="!logado">
            <p>Você ainda não possui uma conta com as informações necessárias para finalizar a compra. Por favor faça Login ou cadastra-se. É rápido!</p>
            <a class="btn btn-primary" href="#top" v-on:click.prevent.stop="IrParaLogin()">Fazer Login</a>
        </div><!--/register-req-->

        <div class="shopper-informations">
            <div class="panel-group" :id="'accordian' + index" v-for="(end, index) in enderecos" :key="index"><!--category-productsr-->
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <span class="pull-right"><input type="checkbox" v-on:change.stop="SelecionarEndereco(end)">
                                Entregar neste Endereço
                            </span>
                            <a data-toggle="collapse" :data-parent="'#accordian' + index" :href="'#end' + index">
                                {{end.rua + " - " + end.cidade}}
                            </a>
                        </h4>
                        <a class="btn btn-primary" href="#" v-show="!end.salvo" v-on:click.stop="AddEndereco(end)">Salvar Endereço</a>
                    </div>
                    <div :id="'end' + index" class="panel-collapse collapse">
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-sm-1 clearfix">
                                    
                                </div>
                                <div class="col-sm-5 clearfix">
                                    <div class="bill-to">
                                        <p>Endereço de Entrega</p>
                                        <div class="form-one">
                                            <form class="form-endereco">
                                                <label ref="cep">CEP</label>
                                                <input name="cep" type="text" placeholder="CEP*" v-model="end.cep">
                                                <label ref="cep">UF</label>
                                                <select v-model="end.uf">
                                                    <option>-- UF --</option>
                                                    <option>SC</option>
                                                    <option>RS</option>
                                                </select>
                                                <label ref="cep">Cidade</label>
                                                <select v-model="end.cidade">
                                                    <option>-- Cidade --</option>
                                                    <option>Gaspar</option>
                                                    <option>Blumenau</option>
                                                </select>
                                                <label ref="cep">Bairro</label>
                                                <input type="text" placeholder="Bairro*" v-model="end.bairro">
                                                <label ref="cep">Logradouro</label>
                                                <input type="text" placeholder="Logradouro*" v-model="end.rua">
                                                <label ref="cep">Número</label>
                                                <input type="text" placeholder="Número*" v-model="end.numero">
                                                <label ref="cep">Complemento</label>
                                                <input type="text" placeholder="Complemento" v-model="end.complemento">
                                            </form>
                                        </div>
                                        <div class="form-two">
                                            <form>
                                                <label ref="cep">DDD</label>
                                                <input type="text" placeholder="DDD*" v-model="end.ddd">
                                                <label ref="cep">Fone</label>
                                                <input type="text" placeholder="Fone*" v-model="end.telefone">
                                                <label ref="cep">E-mail</label>
                                                <input type="text" placeholder="Email" v-model="end.email">
                                            </form>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="order-message">
                                        <p>Observações de Entrega</p>
                                        <textarea name="message" v-model="end.observacao" placeholder="Alguma observação para o entregador saber no momento da entrega?" rows="16"></textarea>
                                    </div>	
                                </div>
                                <div class="col-sm-1">
                                    
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel-group" id="accordian999" v-show="logado"><!--category-productsr-->
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a data-toggle="collapse" data-parent="#accordian999" href="#end999">
                                <a class="btn btn-primary" href="#" v-show="!novoendereco.salvo">Novo Endereço</a>
                            </a>
                        </h4>
                    </div>
                    <div id="end999" class="panel-collapse collapse">
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-sm-1 clearfix">
                                </div>
                                <div class="col-sm-5 clearfix">
                                    <div class="bill-to">
                                        <p>Endereço de Entrega</p>
                                        <div class="form-one">
                                            <form class="form-endereco">
                                                <label ref="cep">CEP</label>
                                                <input name="cep" type="text" placeholder="CEP*" v-model="novoendereco.cep">
                                                <label ref="cep">UF</label>
                                                <select v-model="novoendereco.uf">
                                                    <option>-- UF --</option>
                                                    <option>SC</option>
                                                    <option>RS</option>
                                                </select>
                                                <label ref="cep">Cidade</label>
                                                <select v-model="novoendereco.cidade">
                                                    <option>-- Cidade --</option>
                                                    <option>Gaspar</option>
                                                    <option>Blumenau</option>
                                                </select>
                                                <label ref="cep">Bairro</label>
                                                <input type="text" placeholder="Bairro*" v-model="novoendereco.bairro">
                                                <label ref="cep">Logradouro</label>
                                                <input type="text" placeholder="Logradouro*" v-model="novoendereco.rua">
                                                <label ref="cep">Número</label>
                                                <input type="text" placeholder="Número*" v-model="novoendereco.numero">
                                                <label ref="cep">Complemento</label>
                                                <input type="text" placeholder="Complemento" v-model="novoendereco.complemento">
                                            </form>
                                        </div>
                                        <div class="form-two">
                                            <form>
                                                <label ref="cep">DDD</label>
                                                <input type="text" placeholder="DDD*" v-model="novoendereco.ddd">
                                                <label ref="cep">Fone</label>
                                                <input type="text" placeholder="Fone*" v-model="novoendereco.telefone">
                                                <label ref="cep">E-mail</label>
                                                <input type="text" placeholder="Email" v-model="novoendereco.email">
                                            </form>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="order-message">
                                        <p>Observações de Entrega</p>
                                        <textarea name="message" v-model="novoendereco.observacao" placeholder="Alguma observação para o entregador saber no momento da entrega?" rows="16"></textarea>
                                    </div>	
                                </div>
                                <div class="col-sm-1">
                                    
                                </div>
                            </div>
                            <div class="col-sm-12">
                                <a class="btn btn-primary" href="#" v-show="!novoendereco.salvo" v-on:click.stop="AddEndereco(novoendereco)">Salvar Endereço</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="review-payment">
            <h2>Resumo & Pagamento</h2>
        </div>
        <section id="cart_items">
            <div class="container">
                <CartGrid />
            </div>
            <div class="row">
                <div class="col-sm-5"></div>
                <div class="col-sm-6">
                    <div class="total_area">
                        <ul>
                            <li>Sub Total Carrinho<span v-text='"R$ " + GetSubTotal()'></span></li>
                            <li>Frete<span v-text='"R$ " + costs.TaxShippingValue'></span></li>
                            <li>Total<span v-text='"R$ " + GetTotal()'></span></li>
                        </ul>
                            <a href="#" class="btn btn-default check_out" v-on:click.prevent.stop="FinalizarCompra()">Prosseguir Compra</a>
                    </div>
                </div>
                <div class="col-sm-1"></div>
            </div>
        </section>
    </div>
</template>

<script>
    import MasterHeader from '../components/MasterHeader.vue';
    import CartGrid from '../components/CartGrid.vue';
    import Client from '../components/ApiClient.vue';

    export default {
        inject: ['api','cart','usuario'],
        mixins: [Client],
        components:{
            MasterHeader,
            CartGrid
        },
        data(){
            return {
                costs: {
                    TaxShippingValue: 0
                },
                logado: false,
                usuariologado: {},
                enderecos: [],
                enderecoSelecionado: {},
                novoendereco: {}
            };
        },
        methods:{
            AddEndereco(endereco){
                if(this.logado){
                    endereco.idpessoa = this.usuariologado.idpessoa;
                    this.Post('/buyers/cadastrarEndereco', endereco).then(response => {
                        if(response.idpessoa){
                            this.BuscarEnderecos();
                            this.enderecoSelecionado = response;
                            this.enderecoSelecionado.salvo = true;
                            this.novoendereco = {};
                        }
                    });
                }
            },
            SelecionarEndereco(endereco){ 
                this.enderecos.forEach(function(el){
                    el.selecionado = false;
                });
                endereco.selecionado = true;
                this.enderecoSelecionado = endereco;
                console.log(this.enderecoSelecionado);
            },
            BuscarEnderecos(){
                if(this.logado){
                    var url = '/buyers/' + this.usuariologado.idpessoa + '/address';
                    this.Get(url).then(response => {
                        this.enderecos = response;
                        this.enderecos.forEach(function(el){
                            el.salvo = true;
                        });
                    });
                }
            },
            FinalizarCompra(){
                var produtos = [];
                this.cart.GetAllItems().forEach(function(el){
                    produtos.push({
                        quantidade: el.Quantity,
                        valorCompra: el.Price * el.Quantity,
                        precounitario: el.Price,
                        idproduto: el.IdProduto
                    });
                });
                var request = {
                    produtos: produtos,
                    comprador: this.usuariologado,
                    endereco: this.enderecoSelecionado
                };
                this.Post('/products/finalizarCompra', request).then(response => {
                    if(response.idcompra){
                        this.cart.ClearCar();
                        this.$router.push('buyedsucessful');
                    }
                });
            },
            GetSubTotal(){
                if(this.cart.GetAllItems()){
                    return this.cart.GetAllItems().reduce(function(value, next){
                        return value + next.Price;
                    },0);
                }else{
                    return 0;
                }
            },
            GetTotal(){
                return this.GetSubTotal() + this.costs.TaxShippingValue;
            },
            IrParaLogin(){
                this.$router.push("Login");
            }
        },
        created(){
            this.logado = this.usuario.Current().idpessoa != null;
            this.usuariologado = this.usuario.Current();
            this.BuscarEnderecos();
        }
    }
</script>

<style lang="css" scoped>
    .form-endereco{
        text-align: left;
    }
</style>