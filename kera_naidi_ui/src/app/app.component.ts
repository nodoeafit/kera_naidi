import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { HealthService } from './services/health.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, RouterLink, RouterLinkActive],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'kera_naidi_ui';

  /**
   *
   */
  constructor(private healthService : HealthService) {
    
  }


  getHealth(){
    this.healthService.getHealth().subscribe({
        next: ((data: any)=>{
            // Haz algo con lo que viene llegando
        })
    }); 
  }
}
