<template>
     <tr class="cliente-componente">
        <td> {{ cliente.nome }} </td>
        <td v-sexo-enum> {{ cliente.sexo }}  </td> 
        <td> {{ new Date(cliente.dataNascimento) | dateFormat('DD/MM/YYYY')  }} </td>
        <td>
            <router-link :to="{ name: 'altera', params: {id: cliente.id} }">
                <button class="btn btn-alterar">Alterar</button>
            </router-link>

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