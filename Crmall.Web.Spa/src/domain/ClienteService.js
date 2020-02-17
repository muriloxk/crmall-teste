export default class ClienteService {

    constructor(http) {
        this._http = http;
    this._rota = "clientes";
    }

    remover(cliente) {
        return this._http.delete(this._rota, {body: cliente})
                         .then(response => response.json());
    }

    salvar(cliente) {
        return this._http.post(this._rota, cliente)
                         .then(response => response.json());
    }

    alterar(cliente) {
        return this._http.put(this._rota, cliente)
                         .then(response => response.json());
    }

    buscarPorId(id) {
        return this._http.get(`${this._rota}?id=${id}`)
                         .then(response => response.json());
    }

    carregarTodos() {
       return this._http.get(`${this._rota}/todos`)
                        .then(res => res.json());
    }
}