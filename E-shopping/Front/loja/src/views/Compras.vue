<template>
    <div>
        <MasterHeader />
        <div>
            <div class="panel-body">
                <div class="row titulo-pagina">
                    <div class="col-sm-3 clearfix">
                        <h2>
                            Compras
                        </h2>
                    </div>
                </div>
                <fieldset v-for="(comp, ind) in compras" :key="ind">
                    <div class="item-header col-sm-12">
                        <div class="row">
                            <div class="col-sm-6 item-header-date">
                                <p>{{comp.sitcompra + ' ' + FormatarData(comp.datacompra)}}</p>
                            </div>
                        </div>
                    </div>
                    <div class="row item-compra" v-for="(item, index) in comp.itens" :key="index">
                        <div class="col-sm-1 clearfix"></div>
                        <div class="col-sm-11 clearfix"  >
                            <div class="item-body">
                                <div class="row">
                                    <div class="col-sm-1 clearfix imagem-produto">
                                        <img :src="item.imagem" alt="">
                                    </div>
                                    <div class="col-sm-3 clearfix">
                                        <h4><a v-bind:href='"#/productinfo/" + item.idproduto'>{{item.nome}}</a></h4>
                                        <p v-text="'R$ '+ item.valorunitario + ' x ' + item.quantidade + ' unidade'"></p>
                                    </div>
                                    <div class="col-sm-8 clearfix compra-detalhe">
                                        <a v-bind:href='"#/productinfo/" + item.idproduto'>Ver detalhes</a>
                                    </div>
                                </div>
                            </div>   
                        </div>
                    </div>    
                </fieldset>
            </div>
        </div>
    </div>
</template>

<script>
    import MasterHeader from '../components/MasterHeader.vue';
    import Client from '../components/ApiClient.vue';
    import moment from 'moment';

    export default {
        inject: ['api','usuario'],
        mixins: [Client],
        components:{
            MasterHeader
        },
        data(){
            return {
                compras: {}
            };
        },
        methods:{
            BuscarCompras(){
                let pessoa = this.usuario.Current();
                this.Post('/buyers/buscarCompras', pessoa).then(response => {
                    if(response){
                        this.compras = response;
                        this.compras.forEach(element => {
                            element.itens.forEach(ele => {
                                ele.imagem = this.api.diretorioImagens + ele.imagem + "?" + this.api.sas;
                            });
                        });
                    }else{
                        console.log(response);
                    }
                });
            },
            FormatarData(data){
                moment.defineLocale('pt-br', {
                    parentLocale: 'pt'
                });
                return moment(String(data)).format('[dia] DD [de] MMMM');
            }
        },
        mounted(){
            this.BuscarCompras();
        }
    }
</script>

<style lang="css" scoped>
    .imagem-produto > img{
        width: 100px;
        height: 100px;
    }
    .item-header{
        margin-bottom: 10px;
    }
    .item-compra{
        margin-bottom: 50px;
    }
    .compra-detalhe{
        text-align: right;
    }
    .item-header-date{
        font-size: 20px;
        text-align: left;
    }
    .titulo-pagina{
        margin-bottom: 15px
    }
    .register-form{
        margin-top: 15px
    }
    fieldset{
        border: 1px solid #eee !important;
        margin-bottom: 20px;
    }
</style>