<template>
    <div>
        <h2>Category</h2>
        <div class="panel-group category-products" id="accordian"><!--category-productsr-->
            <div class="panel panel-default" v-for="(category,index) in Categorys" :key="index">
                <div class="panel-heading">
                    <h4 class="panel-title" v-if="category.SubItems.length > 0">
                        <a data-toggle="collapse" data-parent="#accordian" :href='"#category"+index'>
                            <span class="badge pull-right"><i class="fa fa-plus"></i></span>
                            {{category.Name}}
                        </a>
                    </h4>
                    <h4 class="panel-title" v-else>
                        <a href="#">{{category.Name}}</a>
                    </h4>
                </div>
                <div v-if='category.SubItems.length > 0' :id='"category"+index' class="panel-collapse collapse">
                    <div class="panel-body">
                        <ul>
                            <li v-for='(subitem,subindex) in category.SubItems' :key='subindex'>
                                <a href="#">{{subitem.Name}}</a>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        data(){
            return {
                Categorys:[]
            }
        },
        methods: {
            GetCategorys(){
                // GET /someUrl
                this.$http.get('http://localhost:3000/categorys')
                .then(response => response.json())
                .then(response => {
                    this.Categorys = response;
                });
            }
        },
        created(){
            this.GetCategorys();
        }
    }
</script>

<style scoped>
.category-products{
    text-align: left    
}
</style>