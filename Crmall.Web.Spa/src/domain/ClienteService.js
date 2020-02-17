export default class ClienteService {

    constructor(http)
    {
        this._http = http;
        this._rota = "clientes";
    }

    remover(cliente) {
        return this._http.delete(this._rota, {body: cliente})
        .then(response => response.json());
    }

    carregarTodos() {
       return this._http.get(`${this._rota}/todos`)
                      .then(res => res.json());
    }
}