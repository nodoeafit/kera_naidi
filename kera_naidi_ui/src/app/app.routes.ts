import { Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { HealthcheckComponent } from './pages/healthcheck/healthcheck.component';
import { BateriasComponent } from './pages/baterias/baterias.component';


export const routes: Routes = [
    {path: '', component: AppComponent, pathMatch: "full"},
    {path: 'healthcheck', component: HealthcheckComponent},
    {path: 'baterias', component: BateriasComponent}

];
