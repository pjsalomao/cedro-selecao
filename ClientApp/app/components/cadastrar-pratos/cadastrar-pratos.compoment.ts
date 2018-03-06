import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { PratosComponent, Pratos} from '../pratos/pratos.component';

@Component({
    selector: 'casdastrar-pratos',
    templateUrl: './cadastrar-pratos.component.html'
})

export class CadastrarRestaurantesComponent {   

    private baseUrl = 'api/PratosAPI/Pratos';  // URL to web api

    constructor() {                             
       
    }

    addRestaurante (prato: Pratos): Observable<Pratos> {
        return this.baseUrl.post<Pratos>(this.baseUrl, prato).pipe(
          tap((pratos: Pratos) => this.log(`added prato w/ nome=${prato.nome} preco=${prato.preco}`)),
          catchError(this.handleError<Pratos>('addPrato'))
        );
      }

}