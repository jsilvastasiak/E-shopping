<template>
  <header id="header">
    <!--header-->
    <div class="header_top">
      <!--header_top-->
      <div class="container">
        <div class="row">
          <div class="col-sm-6">
            <div class="contactinfo">
              <ul class="nav nav-pills">
                <li>
                  <a href="#" v-on:click="ShowMessage()">
                    <i class="fa fa-phone"></i>
                    {{CurrentCompany.fone}}
                  </a>
                </li>
                <li>
                  <a href="#">
                    <i class="fa fa-envelope"></i>
                    {{CurrentCompany.mailAdress}}
                  </a>
                </li>
              </ul>
            </div>
          </div>
          <div class="col-sm-6">
            <div class="social-icons pull-right">
              <ul class="nav navbar-nav">
                <li>
                  <a href="#">
                    <i class="fa fa-facebook"></i>
                  </a>
                </li>
                <li>
                  <a href="#">
                    <i class="fa fa-twitter"></i>
                  </a>
                </li>
                <li>
                  <a href="#">
                    <i class="fa fa-linkedin"></i>
                  </a>
                </li>
                <li>
                  <a href="#">
                    <i class="fa fa-dribbble"></i>
                  </a>
                </li>
                <li>
                  <a href="#">
                    <i class="fa fa-google-plus"></i>
                  </a>
                </li>
              </ul>
            </div>
          </div>
        </div>
      </div>
    </div>
    <!--/header_top-->

    <div class="header-middle">
      <!--header-middle-->
      <div class="container">
        <div class="row">
          <div class="col-md-4 clearfix">
            <div class="logo pull-left">
              <a href="#/">
                <img src="images/home/logo.png" alt />
              </a>
            </div>
            <div class="btn-group pull-right clearfix">
            </div>
          </div>
          <div class="col-md-8 clearfix">
            <div class="shop-menu clearfix pull-right">
              <ul class="nav navbar-nav">
                <li>
                  <a href="#/login">
                    <i class="fa fa-user"></i> Entrar
                  </a>
                </li>
                <li>
                  <a href>
                    <i class="fa fa-star"></i> Desejos
                  </a>
                </li>
                <li>
                  <a href="#/checkout">
                    <i class="fa fa-crosshairs"></i> Checkout
                  </a>
                </li>
                <li>
                  <a href="#/cart">
                    <i class="fa fa-shopping-cart"></i> Carrinho
                  </a>
                </li>
                <li>
                  <a href="#/login">
                    <i class="fa fa-lock"></i> Login
                  </a>
                </li>
              </ul>
            </div>
          </div>
        </div>
      </div>
    </div>
    <!--/header-middle-->

    <div class="header-bottom">
      <!--header-bottom-->
      <div class="container">
        <div class="row">
          <div class="col-sm-9">
            <div class="navbar-header">
              <button
                type="button"
                class="navbar-toggle"
                data-toggle="collapse"
                data-target=".navbar-collapse"
              >
                <span class="sr-only">Toggle navigation</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
              </button>
            </div>
            <div class="mainmenu pull-left">
              <ul class="nav navbar-nav collapse navbar-collapse">
                <li>
                  <a href="index.html" class="active">Home</a>
                </li>
                <li class="dropdown">
                  <a href="#">
                    Loja
                    <i class="fa fa-angle-down"></i>
                  </a>
                  <ul role="menu" class="sub-menu">
                    <li>
                      <a href="#/shop">Artigos</a>
                    </li>
                    <li>
                      <a href="#/cart">Carrinho</a>
                    </li>
                    <li>
                      <a href="#/login">Login</a>
                    </li>
                  </ul>
                </li>
                <li>
                  <a href="#/contact">Contato</a>
                </li>
              </ul>
            </div>
          </div>
          <div class="col-sm-3">
            <div class="search_box pull-right">
              <input type="text" placeholder="Search" />
            </div>
          </div>
        </div>
      </div>
    </div>
    <!--/header-bottom-->
  </header>
  <!--/header-->
</template>

<script>
export default {
  name: "MasterHeader",
  props: {
    msg: String
  },
  data() {
    return {
      CurrentCompany: {
        mailAdress: "jstasiak@gmail.com",
        fone: "(47) 9975-9323"
      }
    };
  },
  methods: {
    ShowMessage: function() {
      return alert("Funciona!");
    }
  }
};
</script>