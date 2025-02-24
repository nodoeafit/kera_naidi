import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { NavbarComponent } from '../navbar/navbar.component';
import { FooterComponent } from '../footer/footer.component';
import { LupaComponent } from '../lupa/lupa.component';

@Component({
  selector: 'app-layout',
  standalone: true,
  imports: [LupaComponent, NavbarComponent, FooterComponent, RouterModule],
  templateUrl: './layout.component.html',
})
export class LayoutComponent {

}