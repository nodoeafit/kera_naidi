import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { BateriasComponent } from './pages/baterias/baterias.component';
import { MapaUbicacionComponent } from './pages/mapa-ubicacion/mapa-ubicacion.component';
import { CanjeComponent } from './pages/canje/canje.component';
import { PuntosComponent } from './pages/puntos/puntos.component';
import { LoginComponent } from './pages/login/login.component';

export const routes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },

    
    { path: 'home', component: HomeComponent },
    { path: 'baterias', component: BateriasComponent },
    { path: 'canje', component: CanjeComponent },
    { path: 'puntos', component: PuntosComponent },
    { path: 'mapa', component: MapaUbicacionComponent },
    { path: 'login', component: LoginComponent },
  
];