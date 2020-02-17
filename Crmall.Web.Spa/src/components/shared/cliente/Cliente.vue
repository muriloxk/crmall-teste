<template>
     <tr class="cliente-componente">
        <td> {{ cliente.nome }} </td>
        <td> {{ cliente.sexo }} </td> 
        <td> {{ new Date(cliente.dataNascimento) | dateFormat('DD/MM/YYYY')  }} </td>
        <td>
            <button class="btn btn-alterar" @click="alterar(cliente)">Alterar</button>
            <button class="btn btn-remover" @click="remover(cliente)">Remover</button>
        </td>
      </tr>
</template>

<script>
    export default {
        props: ["cliente"],

        methods: {
            remover(){
                if(confirm("Você tem certeza que deseja excluir o cliente?")){
                    this.$emit('removerCliente'); 
                }
            },

            alterar(){
                this.$emit('alterarCliente');
            }
        }
    }
</script>

<style scoped>
    .btn {
        padding:0.5rem;
        font-size:1rem;
        color:white;
        border-radius:1rem;
    }
    .btn-remover {
        background-color:FireBrick;
    }

    .btn-alterar {
        background-color:SeaGreen;
    }
</style>