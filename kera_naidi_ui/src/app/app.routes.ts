import { Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { HealthcheckComponent } from './pages/healthcheck/healthcheck.component';

export const routes: Routes = [
    {path: '', component: AppComponent},
    {path: 'healthcheck', component: HealthcheckComponent}
];
