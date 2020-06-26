<template>
    <div>
        <MasterHeader />
        <p>Sua Compra foi finalizada com Sucesso. Em Breve você receberá informações no seu e-mail do andamento de entrega do seu pedido!</p>
        <div class="row">
            <div class="col-sm-4 clearfix"></div>
            <div class="col-sm-4 clearfix">
                <img src="../assets/compra-efetivada.png" />
            </div>
        </div>
    </div>
</template>

<script>
    import MasterHeader from '../components/MasterHeader.vue';

    export default {
        components:{
            MasterHeader
        },
        data(){
            return {};
        }
    }
</script>

<style lang="css" scoped>
    .clearfix > img{
        width: 100%;
    }
</style>