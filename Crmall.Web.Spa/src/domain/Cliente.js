export default class Cliente {
    constructor()
    {
        this.nome = null;
        this.dataNascimento = null;
        this.sexo = null;
        this.dataFormatada = null;
        this.endereco = {
                cep: null,
                logradouro: null,
                numero: null,
                complemento: null,
                bairro: null,
                cidade: null,
                estado: null,
        };
    }
}