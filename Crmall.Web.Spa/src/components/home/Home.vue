<template>
  <div id="home">
    <h1>  {{ titulo }} </h1>

    <span v-if="respostaErro" class="msg msg-erro"> {{respostaErro}} </span>
    <span v-if="respostaApi" class="msg msg-api"> {{respostaApi}} </span>

    <table class="lista-clientes" v-if="clientes.length > 0"> 
      <thead> 
          <th>Nome</th>
          <th>Sexo</th>
          <th>Nascimento</th>
      </thead>

      <cliente-componente  v-for="cliente in clientes" 
                           v-bind:cliente="cliente" 
                           @removerCliente="remover(cliente)" 
                           @alterarCliente="alterar(cliente)">
      </cliente-componente>
    </table>
  
    <span v-if="clientes.length == 0">Não possuimos nenhum cliente para listar</span>

        <router-link :to="{ name: 'cadastro'}">
            <button class="button-adicionar">Adicionar novo cliente</button>
        </router-link>

  </div>
</template>

<script>
	  import ClienteComponente from '../shared/cliente/Cliente.vue';
    import ClienteService from '../../domain/ClienteService';

  export default {
    name: 'app',

    components: {
      'cliente-componente': ClienteComponente,
    },

    data () {
      return {
        service: new ClienteService(this.$http),
        titulo: 'Cadastro de clientes',
        clientes: [],
      }
    },

    methods: {
        remover(cliente) {
          this.service.remover(cliente)
                    .then((response) => {
                      this.respostaApi = response.message; 
                      setTimeout(() => this.respostaApi = null, 5000);
                      this.removerClienteDaLista(cliente);
                    }, err => his.respostaErro = "Não foi possivel excluir o cliente");
        },

        removerClienteDaLista(cliente) {
          let indice = this.clientes.indexOf(cliente);
          this.clientes.splice(indice, 1);
        },

        atualizarLista() {
            this.service.carregarTodos()
                      .then(clientes => {
                            this.clientes = clientes 
                      }, err => this.respostaErro = "Não foi possivel listar os clientes");  
        }
    },

    created: function () {
          this.atualizarLista();     
    }
  }
</script>

<style>

#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

.button-adicionar {
       display: block;
       margin: auto;
       padding: 10px;
       border-radius: 1rem;
       font-size: 1em;
       margin-top:0.5rem;
       background:SeaGreen;
       color:white;
       text-decoration:none;
}

.msg {
    padding:0.5rem;
    display: block;
    width: 30%;
    margin: 0 auto;
    margin-bottom:10px;
}

.msg-erro {
    background:#CD5C5C;
}

.msg-api {
    background:#98FB98;
}  

.lista-clientes{
  display: inline-block;
  padding:2rem;
  border: 1px #ccc dotted;
}

.lista-clientes th{
    padding:10px;
    font-size:1.2rem;
}

.lista-clientes td{
  padding:10px;
  font-size:1rem;
}
</style>
