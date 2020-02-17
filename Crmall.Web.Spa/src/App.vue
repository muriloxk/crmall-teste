<template>
  <div id="app">
    <h1>  {{ titulo }} </h1>

    <span v-show="visivel" class="msg-api"> {{ respostaApi }} </span>

    <table class="lista-clientes"> 
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

  </div>
</template>

<script>
	import Cliente from './components/shared/cliente/Cliente.vue';

  export default {
    name: 'app',

    components: {
      'cliente-componente': Cliente
    },

    data () {
      return {
        titulo: 'Cadastro de clientes',
        clientes: [],
        respostaApi: "",
        visivel: false,
      }
    },

    methods: {
        remover(cliente) {
          this.$http.delete('https://localhost:5003/clientes', {body: cliente})
                    .then(response => response.json())
                    .then((response) => {

                      console.log(response);
                      this.respostaApi = response.message;
                      this.visivel = true;
                      
                      setTimeout(() => this.visivel = false, 5000);
                      
                      this.atualizarLista();

                    }, err => console.log(err));
        },

        alterar(cliente) {
          alert("Estamos escutando o evento de alterar cliente");
        },

        atualizarLista() {
            this.$http.get('https://localhost:5003/clientes/todos')
                      .then(res => res.json())
                      .then(clientes => {
                            this.clientes = clientes 
                      }, err => console.log(err));  
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

.msg-api {
  display:block;
  width: 30%;
  text-align:center;
  margin: 0 auto;
  margin-bottom:0.5rem;
  padding:1em;
  background-color:#CCCCCC;
}

.lista-clientes{
  display: inline-block;
  border: 1px solid black;
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
