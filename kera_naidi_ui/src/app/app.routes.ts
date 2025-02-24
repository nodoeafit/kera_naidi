import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { BateriasComponent } from './pages/baterias/baterias.component';
import { MapaComponent } from './pages/mapa/mapa.component';
import { CanjeComponent } from './pages/canje/canje.component';
import { PuntosComponent } from './pages/puntos/puntos.component';


export const routes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },

    
    { path: 'home', component: HomeComponent },
    { path: 'baterias', component: BateriasComponent },
    { path: 'canje', component: CanjeComponent },
    { path: 'puntos', component: PuntosComponent },
    { path: 'mapa', component: MapaComponent },
];