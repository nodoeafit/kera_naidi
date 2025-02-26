import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {FormsModule} from '@angular/forms';
import { CommonModule } from '@angular/common';
import { CodeCheckerComponent } from './code-checker.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [ FormsModule, CommonModule, CodeCheckerComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'kera_naidi_ui';
  
}

