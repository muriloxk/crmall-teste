export default class Cliente {
    constructor()
    {
        this.id = null;
        this.nome = null;
        this.dataNascimento = new Date().toJSON();
        this.sexo = 0;
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