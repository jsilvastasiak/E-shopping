<template>
    <div>
        <MasterHeader />
        <div class="shopper-informations">
            <div class="row">
                <div class="col-sm-4"></div>
                <div class="col-sm-4">
                    <div class="shopper-info">
                        <p>Suas Informações</p>
                        <form>
                            <label ref="cep">Nome</label>
                            <input type="text" placeholder="Nome" v-model="usuarioregistro.nome">
                            <label ref="cep">E-mail</label>
                            <input type="text" placeholder="E-mail" v-model="usuarioregistro.email">
                            <label ref="cep">CPF</label>
                            <input type="text" placeholder="CPF" v-model="usuarioregistro.cpf">
                            <label ref="cep">Senha</label>
                            <input type="password" placeholder="Senha" v-model="usuarioregistro.senha">
                            <label ref="cep">Confirme a Senha</label>
                            <input type="password" placeholder="Confirme a Senha" v-model="usuarioregistro.confirmsenha">
                        </form>
                        <a class="btn btn-primary" href="#" v-on:click.prevent.stop="FazerCadastro(usuarioregistro)">Registrar</a>
                    </div>
                </div>
                <div class="col-sm-4"></div>
            </div>
        </div>
    </div>
</template>

<script>
    import MasterHeader from '../components/MasterHeader.vue';
    import Client from '../components/ApiClient.vue';

    export default {
        inject: ['api','usuario'],
        mixins: [Client],
        components:{
            MasterHeader
        },
        data(){
            return {
                mensagemregistro: null,
                usuarioregistro: {}
            };
        },
        methods:{
            FazerCadastro(usuario){
                this.Post('/buyers/cadastrarPessoa', usuario).then(response => {
                    if(response.email){
                        console.log(response);
                        this.$router.go(-1);
                    }else{
                        if(response.mensagem)
                            this.mensagemregistro = response.mensagem;
                    }
                });
            }
        }
    }
</script>

<style lang="css" scoped>
    .shopper-info > form{
        text-align: left;
    }
</style>