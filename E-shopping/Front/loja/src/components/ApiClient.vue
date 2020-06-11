<script>
    export default {
        inject: ['api'],
        data(){
            return {};
        },
        methods:{
            _getHeaders(){
                return { 
                    "Authorization": "Bearer " + this.api.token,
                    "Content-Type": "application/json"
                }
            },
            Get(url){
                var headers = this._getHeaders();
                console.log(headers);
                var resultadoJson = this.$http.get(this.api.baseUrl + url, {"headers" : headers})
                .then(response => response.json());

                return resultadoJson;
            },
            Post(url, parametros){
                var headers = this._getHeaders();
                var resultadoJson = this.$http.post(this.api.baseUrl + url, parametros, { "headers": headers})
                .then(response => response.json());

                return resultadoJson;
            }
        }
    }
</script>