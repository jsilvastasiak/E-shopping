<template>
    <div>
        <MasterHeader />
        <div class="col-sm-12 clearfix">
            <p>Sua Compra foi finalizada com Sucesso. Em Breve você receberá informações no seu e-mail do andamento de entrega do seu pedido!</p>
            <img src="../assets/compra-efetivada.png" />
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

<style lang="scss" scoped>

</style>