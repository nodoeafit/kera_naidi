import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { LayoutComponent } from './components/layout/layout.component';



@Component({
  selector: 'app-root',
  standalone: true,
  imports: [LayoutComponent, RouterModule],
  template:`<app-layout></app-layout>` ,
  templateUrl: './app.component.html',
})
export class AppComponent {
  title = 'PruebaAngular';
}