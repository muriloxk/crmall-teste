<template>
  <div id="home">
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


    <form @submit.prevent="salvar(clienteSelecionado)">
        <label for="nome"> Nome:</label> 
        <input type="text" id="nome" v-model="clienteSelecionado.nome" /> <br />

        <label for="nascimento">Data de nascimento</label>
         <date-picker type="date" v-model="clienteSelecionado.dataNascimento" valueType="format"></date-picker> <br />

        <fieldset>
            <legend>Sexo:</legend>

            <input type="radio" 
                   id="masculino" 
                   name="sexo" 
                   value="0" 
                   v-model="clienteSelecionado.sexo" 
                   :checked="clienteSelecionado.sexo == 0">
            <label for="masculino">Masculino</label> <br/>

            <input type="radio" 
                   id="feminino"
                   name="sexo" 
                   value="1"  
                   v-model="clienteSelecionado.sexo" 
                   :checked="clienteSelecionado.sexo == 1" >
            <label for="feminino">Feminino</label> <br/>

            <input type="radio" 
                   id="outro" 
                   name="sexo" 
                   value="2"  
                   v-model="clienteSelecionado.sexo"
                   :checked="clienteSelecionado.sexo == 2" >
            <label for="outro">Outro</label> <br/>
        </fieldset>

        <fieldset>
          <legend>Endereço</legend>

          <label for="cep">Cep</label>
          <input type="text" id="cep" v-model="clienteSelecionado.endereco.cep" />
          <button @click="buscarCep(clienteSelecionado.endereco.cep)">Buscar por CEP</button> <br/>

          <label for="logradouro">Logradouro</label> 
          <input type="text" id="logradouro" v-model="clienteSelecionado.endereco.logradouro" /> <br/>
          
          <label for="numero">Numero</label> 
          <input type="text" id="numero" v-model="clienteSelecionado.endereco.numero" /> <br/>

          <label for="complemento">Complemento</label> 
          <input type="text" id="complemento" v-model="clienteSelecionado.endereco.complemento" /> <br/>

          <label for="bairro">Bairro</label> 
          <input type="text" id="bairro" v-model="clienteSelecionado.endereco.bairro" /> <br/>

          <label for="cidade">Cidade</label> 
          <input type="text" id="bairro" v-model="clienteSelecionado.endereco.cidade" /> <br/>

          <label for="estado">Estado</label> 
          <input type="text" id="bairro" v-model="clienteSelecionado.endereco.estado" /> <br/>
        </fieldset>

        <button>Salvar</button>
    </form>

  </div>
</template>

<script>
	import ClienteComponente from '../shared/cliente/Cliente.vue';
    import DatePicker from 'vue2-datepicker';
    import 'vue2-datepicker/index.css';

    import Cliente from '../../domain/Cliente';
    import ClienteService from '../../domain/ClienteService';

  export default {
    name: 'app',

    components: {
      'cliente-componente': ClienteComponente,
      'date-picker': DatePicker
    },

    data () {
      return {
        service: new ClienteService(this.$http),
        titulo: 'Cadastro de clientes',
        clientes: [],
        clienteSelecionado: new Cliente(),
        respostaApi: "",
        visivel: false,
      }
    },

    methods: {
        remover(cliente) {
          this.service.remover(cliente)
                    .then((response) => {
                      this.respostaApi = response.message;
                      this.visivel = true;
                      setTimeout(() => this.visivel = false, 5000);
                      this.removerClienteDaLista(cliente);
                    }, err => console.log(err));
        },

        alterar(cliente) {
            this.clienteSelecionado = cliente; 
        },

        removerClienteDaLista(cliente) {
          let indice = this.clientes.indexOf(cliente);
          this.clientes.splice(indice, 1);
        },

        salvar(cliente) {
          var clienteCommand = {
                  id: cliente.id,
                  nome: cliente.nome,
                  dataNascimento: cliente.dataNascimento,
                  sexo: parseInt(cliente.sexo),
                  cep: cliente.endereco.cep,
                  logradouro: cliente.endereco.logradouro,
                  numero: cliente.endereco.numero,
                  complemento: cliente.endereco.complemento,
                  bairro: cliente.endereco.bairro,
                  cidade: cliente.endereco.cidade,
                  estado: cliente.endereco.estado
                 };
        

          if(clienteCommand.id === null){
            this.service.salvar(clienteCommand)
                        .then((res) =>  {
                            this.respostaApi = res.message;
                            this.visivel = true;
                            setTimeout(() => this.visivel = false, 5000)
                        }, err => console.log("err", err));
          }
          else{
              this.service.alterar(clienteCommand)
                            .then((res) =>  {
                                this.respostaApi = res.message;
                                this.visivel = true;
                                setTimeout(() => this.visivel = false, 5000)
                            }, err => console.log("err", err));
          }

          this.atualizarLista();
        },

        buscarCep(cep) {
          this.$http.get(`cep/${cep}`)
                    .then(res => res.json())
                    .then(res => { 
                            console.log(res);
                            this.clienteSelecionado.endereco = res;
                       }, 
                     err => console.log(err));
        },

        atualizarLista() {
            this.service.carregarTodos()
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
