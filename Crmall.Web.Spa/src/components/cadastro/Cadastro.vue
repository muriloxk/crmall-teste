<template>
    <div class="formulario">
        <form @submit.prevent="salvar(clienteSelecionado, $event)">

        <fieldset>
            <legend>Cliente:</legend>
        <label for="nome"> Nome</label> 
        <input type="text" id="nome" v-model="clienteSelecionado.nome" /><br />

        <div class="date-picker">
            <label for="nascimento">Data de nascimento</label>
            <date-picker type="date" v-model="clienteSelecionado.dataNascimento" valueType="format"></date-picker> <br />
        </div>

            <input type="radio" 
                   id="masculino" 
                   name="sexo" 
                   value="0" 
                   v-model="clienteSelecionado.sexo" 
                   :checked="clienteSelecionado.sexo == 0"
                   >
            <label for="masculino">Masculino</label> <br/>

            <input type="radio" 
                   id="feminino"
                   name="sexo" 
                   value="1"  
                   v-model="clienteSelecionado.sexo" 
                   :checked="clienteSelecionado.sexo == 1"  >
            <label for="feminino">Feminino</label> <br/>

            <input type="radio" 
                   id="outro" 
                   name="sexo" 
                   value="2"  
                   v-model="clienteSelecionado.sexo"
                   :checked="clienteSelecionado.sexo == 2"  >
            <label for="outro">Outro</label> <br/>
        </fieldset>

        <fieldset>
          <legend>Endereço do cliente:</legend>
          <div class="prop-form">
            <label for="cep">Cep</label>
            <input type="text" id="cep" v-model="clienteSelecionado.endereco.cep" />
            <button @click="buscarCep(clienteSelecionado.endereco.cep,  $event)" class="button-cep">Preecher com o cep</button> 
            <br/>
                <span v-show="respostaCep" class="msg msg-erro"> {{ respostaCep }} </span>
           </div>
        
          <div class="prop-form">
            <label for="logradouro">Logradouro</label> 
            <input type="text" id="logradouro" v-model="clienteSelecionado.endereco.logradouro" /> <br/>
          </div>
          
          <div class="prop-form">
            <label for="numero">Numero</label> 
            <input type="text" id="numero" v-model="clienteSelecionado.endereco.numero" /> <br/>
          </div>
        
         <div class="prop-form">
          <label for="complemento">Complemento</label> 
          <input type="text" id="complemento" v-model="clienteSelecionado.endereco.complemento" /> <br/>
         </div>

        <div class="prop-form">
          <label for="bairro">Bairro</label> 
          <input type="text" id="bairro" v-model="clienteSelecionado.endereco.bairro" /> <br/>
        </div>

        <div class="prop-form"> 
          <label for="cidade">Cidade</label> 
          <input type="text" id="cidade" v-model="clienteSelecionado.endereco.cidade" /> <br/>
        </div>

        <div class="prop-form">
          <label for="estado">Estado</label> 
          <input type="text" id="estado" v-model="clienteSelecionado.endereco.estado" /> <br/>
        </div>
        </fieldset>

        <span v-show="respostaApi" class="msg msg-api"> {{ respostaApi }} </span>
        <span v-show="respostaErro" class="msg msg-erro"> {{ respostaErro }} </span>
        <span v-show="validacoes.length > 0" v-for="validacao in validacoes" class="msg msg-erro"> {{ validacao }} </span>

        <button>Salvar</button>
        
        <router-link :to="{ name: 'home'}">
            <button>Voltar</button>
        </router-link>
    </form>

     
    </div>
</template>

<script>
    import DatePicker from 'vue2-datepicker';
    import 'vue2-datepicker/index.css';

    import Cliente from '../../domain/Cliente';
    import ClienteService from '../../domain/ClienteService';

 

    export default {

        components: {
            'date-picker': DatePicker
        },

        data() {
            return {
                 clienteSelecionado: new Cliente(),
                 service: new ClienteService(this.$http),
                 respostaApi: null,
                 respostaErro: null,
                 validacoes: [],
                 respostaCep: null,
                 id: this.$route.params.id
            }
        }, 

        methods: {
            salvar(cliente, event) {
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

                    this.validarCamposObrigatorios(clienteCommand, event);

                    if(this.validacoes.length > 0) {
                        event.preventDefault();
                        return;
                    }

                    if(clienteCommand.id === null){
                        this.service.salvar(clienteCommand)
                                    .then((res) =>  {
                                        this.validarResposta(res);
                                       this.$router.push({path: '/'})
                                    }, err => this.respostaErro = "Houve um erro salvar o cliente");
                    }
                    else{
                        this.service.alterar(clienteCommand)
                                        .then((res) =>  {
                                            this.validarResposta(res);
                                            this.$router.push({path: '/'})
                                        }, err => this.respostaErro = "Houve um erro alterar o cliente");
                    }
                },

                buscarCep(cep, event) {
                    if (event) event.preventDefault()

                    this.$http.get(`cep/${cep}`)
                                .then(res =>   res.json()  )
                                .then(res => { 
                                        this.clienteSelecionado.endereco = res;
                                }, 
                                err => {
                                    this.validacoes = [];
                                    this.respostaCep = "Cep não encontrado, por favor digite o endereço";
                                });
                },

                validarResposta(res) {
                        this.limparValidacoes();
                        
                        if(res.sucesso){
                            this.respostaApi = res.message;
                        }
                        else {
                            this.respostaErro = res.message;
                   
                            res.data.forEach((data) => this.validacoes.push(data.message));
                        }
                },

                validarCamposObrigatorios(clienteCommand, event) {
                    this.limparValidacoes();

                    if(clienteCommand.nome === null || clienteCommand.nome.length === 0)
                        this.validacoes.push("Por favor, preencha o nome do cliente");

                    if(clienteCommand.nome.length < 4)
                          this.validacoes.push("Por favor, preencha o nome do cliente, minimo 4 caracteres.");
            
                    if(clienteCommand.dataNascimento === null)
                        this.validacoes.push("O campo da data de nascimento é obrigatório");
      
                    if(clienteCommand.sexo === null)
                        this.validacoes.push("O campo do sexo é obrigatório");
                },

                limparValidacoes() {
                    this.validacoes = [];
                    this.respostaApi = null;
                    this.respostaErro = null;
                }
            },

            created() {

                

                if(this.id) {
                    this.service.buscarPorId(this.id)
                                .then(cliente => {
                                    this.clienteSelecionado = cliente;
                                    if(cliente.endereco === null){
                                        this.clienteSelecionado.endereco = new Cliente().endereco;
                                    }                            

                                }, err => console.log(err));
                }
            }
    }
</script>

<style scoped>
    body{
        font-size:10px;
    }

    fieldset {
        margin-bottom:1rem;
    }


    button {
         padding: 0.5rem;
         font-size: .8rem; 
    }

    .formulario {
        display:block;
        width: 60%;
        margin:0 auto;
        padding:0;
    }


    .date-picker {
        margin-top: 0.1rem;
    }

    .button-cep{
        padding:0.2rem;
    }

    .formulario input[type="text"] {
        padding: 0.3rem;
        font-size:.8rem;
        margin-top: 0.1rem;

    }

    .formulario label {
          padding: 0.2rem;
          font-size:.8rem;
    }
    .msg {
        padding:0.2rem;
        display: block;
        width: 90%;
        margin: 0 auto;
        margin-bottom: 0.1rem;
        font-size: .8rem;
    }

    .msg-erro {
        background:#CD5C5C;
    }

    .msg-api {
        background:#98FB98;
    }  

    .prop-form {
        display: flex;
        flex-direction:column;
        width:70%;
        margin:0 auto;
    }
</style>