import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';

@Component({
    selector: 'restaurantes',
    templateUrl: './restaurantes.component.html'
})

export class RestaurantesComponent {   
    public restaurantes: Restaurante[];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {   
        http.get(baseUrl + '/api/RestauranteAPI/Restaurante').subscribe(result => {
            this.restaurantes = result.json() as Restaurante[];
        }, error => console.error(error));
    }

}
export interface Restaurante {   
    restauranteNome: string;
}  

