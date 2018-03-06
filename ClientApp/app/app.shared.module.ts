import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { RestaurantesComponent } from './components/restaurantes/restaurantes.component';
import { PratosComponent } from './components/pratos/pratos.component';
import { CadastrarRestaurantesComponent } from './components/cadastrar-restaurante/cadastrar-restaurante.component';
import { CadastrarPratosComponent } from './components/cadastrar-pratos/cadastrar-pratos.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        RestaurantesComponent,
        CadastrarRestaurantesComponent,
        PratosComponent,
        CadastrarPratosComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'restaurantes', component: RestaurantesComponent },
            { path: 'pratos', component: PratosComponent },
            { path: 'cadastrar-restaurantes', component: CadastrarRestaurantesComponent },
            { path: 'cadastrar-pratos', component: CadastrarPratosComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}
