<template>
	<div>
		<MasterHeader />
		<div id="contact-page" class="container">
			<div class="bg">
				<div class="row">    		
					<div class="col-sm-12">    			   			
						<h2 class="title text-center">Entre em Contato <strong>Conosco</strong></h2>    			    				    				
						<div id="gmap" class="contact-map">
						</div>
					</div>			 		
				</div>    	
				<div class="row">  	
					<div class="col-sm-8">
						<div class="contact-form">
							<h2 class="title text-center">Mande uma mensagem</h2>
							<div class="status alert alert-success" style="display: none"></div>
							<form id="main-contact-form" class="contact-form row" name="contact-form">
								<div class="form-group col-md-6">
									<input type="text" name="name" class="form-control" required="required" placeholder="Nome">
								</div>
								<div class="form-group col-md-6">
									<input type="email" name="email" class="form-control" required="required" placeholder="E-mail">
								</div>
								<div class="form-group col-md-12">
									<input type="text" name="subject" class="form-control" required="required" placeholder="Assunto">
								</div>
								<div class="form-group col-md-12">
									<textarea name="message" id="message" required="required" class="form-control" rows="8" placeholder="Sua Mensagem Aqui"></textarea>
								</div>                        
								<div class="form-group col-md-12">
									<input type="submit" name="submit" class="btn btn-primary pull-right" value="Enviar">
								</div>
							</form>
						</div>
					</div>
					<div class="col-sm-4">
						<div class="contact-info">
							<h2 class="title text-center">Contato</h2>
							<address>
								<p>E-Shopper Inc.</p>
								<p>4652 Rua Florença, 22, Santa Terezinha</p>
								<p>Gaspar SC</p>
								<p>Celular: (47) 99975-9323</p>
								<p>E-mail: eshopper@eshopper.com.br</p>
							</address>
							<div class="social-networks">
								<h2 class="title text-center">Redes Sociais</h2>
								<ul>
									<li>
										<a href="#"><i class="fa fa-facebook"></i></a>
									</li>
									<li>
										<a href="#"><i class="fa fa-twitter"></i></a>
									</li>
									<li>
										<a href="#"><i class="fa fa-google-plus"></i></a>
									</li>
									<li>
										<a href="#"><i class="fa fa-youtube"></i></a>
									</li>
								</ul>
							</div>
						</div>
					</div>    			
				</div>  
			</div>
		</div><!--/#contact-page-->
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
        },
        methods:{},
		mounted(){
			let google = document.createElement('script');
			google.setAttribute('src', 'http://maps.google.com/maps/api/js?sensor=true');
			let gmap = document.createElement('script');
			gmap.setAttribute('src', 'js/gmaps.js');
			let contact = document.createElement('script');
			gmap.setAttribute('src', 'js/contact.js');
			document.body.appendChild(google);
			document.body.appendChild(gmap);
			document.body.appendChild(contact);
		}
    }
</script>