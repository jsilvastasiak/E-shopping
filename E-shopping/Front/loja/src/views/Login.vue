<template>
    <div>
        <MasterHeader />
        <div class="shopper-informations">
            <div class="row">
                <div class="col-sm-4"></div>
                <div class="col-sm-4">
                    <div class="shopper-info">
                        <p>Fazer Login</p>
                        <form>
                            <label ref="cep">E-mail</label>
                            <input type="text" placeholder="E-mail" v-model="usuariologin.email">
                            <label ref="cep">Senha</label>
                            <input type="password" placeholder="Senha" v-model="usuariologin.senha">
                        </form>
                        <a class="btn btn-primary" href="#" v-on:click.prevent.stop="FazerLogin(usuariologin)">Login</a>
                    </div>
                </div>
            </div>
            <div class="row register-form">
                <div class="col-sm-4"></div>
                <div class="col-sm-4 choose">
                    <p>Ainda não tem Cadastro?</p>
                    <ul class="nav nav-pills nav-justified">
                        <li><a href="#" v-on:click.prevent.stop="IrParaRegistro()"><i class="fa fa-plus-square"></i>Registrar-se</a></li>
                    </ul>
                </div>
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
                mensagemlogin: null,
                usuariologin: {}
            };
        },
        methods:{
            FazerLogin(usuarioform){
                this.Post('/buyers/fazerLogin', usuarioform).then(response => {
                    if(response.idpessoa){
                        this.usuario.SetUsuario(response.idpessoa, response.email);
                        this.$router.push("/");
                    }else{
                        if(response.mensagem)
                            this.mensagemlogin = response.mensagem;
                    }
                });
            },
            IrParaRegistro(){
                this.$router.push("Register");
            }
        }
    }
</script>

<style lang="css" scoped>
    .shopper-info > form{
        text-align: left;
    }
    .register-form{
        margin-top: 15px
    }
</style>