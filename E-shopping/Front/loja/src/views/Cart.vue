<template>
    <div>
        <MasterHeader />
        <section id="cart_items">
            <div class="container">
                <div class="breadcrumbs">
                    <ol class="breadcrumb">
                    <li><a href="#/">Home</a></li>
                    <li class="active">Carrinho</li>
                    </ol>
                </div>
                <CartGrid />
                <section id="do_action">
                    <div class="container">
                        <div class="heading">
                            <h3>O que você gostaria de fazer depois?</h3>
                            <p>Escolha se você tem um código de desconto ou pontos de recompensa que deseja usar ou gostaria de estimar seu custo de entrega.</p>
                        </div>
                        <div class="row">
                            <div class="col-sm-6">
                                <div class="chose_area">
                                    <ul class="user_option">
                                        <li>
                                            <input type="checkbox">
                                            <label>Use meu Cupon de Desconto</label>
                                        </li>
                                        <li>
                                            <input type="checkbox">
                                            <label>Use meu Cupon de Presente</label>
                                        </li>
                                        <li>
                                            <input type="checkbox">
                                            <label>Estimar Custo de Expedição e Taxas</label>
                                        </li>
                                    </ul>
                                    <ul class="user_info">
                                        <li class="single_field">
                                            <label>País:</label>
                                            <select v-model="countryCode" v-on:change="ResetRegion()">
                                                <option v-for="(item,index) in country" :key="index" :value="item.Id">{{item.Name}}</option>
                                            </select>
                                            
                                        </li>
                                        <li class="single_field">
                                            <label>Região / Estado:</label>
                                            <select v-model="regionCode">
                                                <option v-for="(item,index) in regions" :key="index" :value="item.Id">{{item.Name}}</option>
                                            </select>
                                        
                                        </li>
                                        <li class="single_field zip-field">
                                            <label>CEP:</label>
                                            <input type="text" v-model="cepNumber" v-on:blur.prevent.stop="RefreshBuy()">
                                        </li>
                                    </ul>
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="total_area">
                                    <ul>
                                        <li>Sub Total Carrinho<span v-text='"R$ " + GetSubTotal()'></span></li>
                                        <li>Total<span v-text='"R$ " + GetTotal()'></span></li>
                                    </ul>
                                        <a href="#top" class="btn btn-default check_out" v-on:click.prevent.stop="InitBuy()">Prosseguir Compra</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </section><!--/#do_action-->
            </div>
        </section> <!--/#cart_items-->
    </div>
</template>

<script>
    
    import MasterHeader from '../components/MasterHeader.vue';
    import CartGrid from '../components/CartGrid.vue';
    import Client from '../components/ApiClient.vue';

    export default {
        inject: ['api','cart'],
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
                country: [],
                regions: [],
                cepNumber: "",
                countryCode: Number,
                regionCode: Number,
            };
        },
        methods:{
            GetCountry(){    
                //Precisa fazer uma integração com correios talvez
            },
            GetRegion(){
                let countryCodeSelected = this.countryCode;
                let countrySel = this.country.filter(function(item){
                    return item.Id === countryCodeSelected;
                });
                this.regions = countrySel.length > 0 ? countrySel[0].Regions : {};
            },            
            RefreshBuy(){
                let cepCode = this.cepNumber ? this.cepNumber.replace(new RegExp("[^0-9]"), "") : undefined;
                if(cepCode){
                    this.$http.get(this.api.baseUrl + '/regionByCep', {
                        params: {
                            CepNumber: cepCode
                        }
                    })
                    .then(res => res.json())
                    .then(res => res.length > 0 ? res[0] : {})
                    .then(res => {
                        this.countryCode = res.CountryId;
                        this.regionCode = res.Id;
                    });
                }
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
            ResetRegion(){
                this.regionCode = undefined;
                this.cepNumber = undefined;
            },
            InitBuy(){
                this.$router.push("Checkout");
            }
        },
        watch:{
            countryCode: function(){
                this.GetRegion();
            },
            regionCode: function(newValue){
                if(newValue){
                    let region = this.regions.filter(function(item){
                        return item.Id == newValue;
                    })[0];

                    this.costs.TaxShippingValue = region.TaxShippingValue;
                }else
                    this.costs.TaxShippingValue = 0;
            }
        },
        created(){
            this.GetCountry();
        }
    }
</script>

<style scoped>

</style>