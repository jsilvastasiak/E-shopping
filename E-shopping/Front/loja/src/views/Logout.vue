<template>
    <div></div>
</template>

<script>
    export default {
        inject: ['usuario'],
        data(){
            return {};
        },
        methods:{
        },
        created(){
            if(this.usuario.Current().idpessoa != null){
                this.usuario.Logout();
            }
            this.$router.push("/");
        }
    }
</script>

<style lang="css" scoped>
</style>