//importa cliente http e angular
import {
    Component, Inject
} from '@angular/core';
import {
    Http
} from "@angular/http";

@Component({
    selector: 'pratos', //nome do app no arquivo html
    template: require('./pratos.component.html') //arquivo html de saida
})

export class PratosComponent {
    public pratos: Pratos[] = [];
    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {   
        http.get(baseUrl + '/api/PratosAPI/Prato').subscribe(result => {
            this.pratos = result.json() as Pratos[];
        }, error => console.error(error));
    }
}
export interface Pratos {
    nome: string;
    preco: number;
}  