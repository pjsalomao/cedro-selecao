import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { RestaurantesComponent, Restaurante } from '../restaurantes/restaurantes.component';

@Component({
    selector: 'casdastrar-restaurante',
    templateUrl: './cadastrar-restaurantes.component.html'
})

export class CadastrarRestaurantesComponent {   

    private baseUrl = 'api/RestauranteAPI/Restaurante';  // URL to web api

    constructor() {                             
       
    }

    addRestaurante (restaurante: Restaurante): Observable<Restaurante> {
        return this.baseUrl.post<Restaurante>(this.baseUrl, restaurante).pipe(
          tap((restaurante: Restaurante) => this.log(`added restaurante w/ restaranteNome=${restaurante.restauranteNome}`)),
          catchError(this.handleError<Restaurante>('addRestaurante'))
        );
      }

}
