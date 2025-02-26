import { Component } from '@angular/core';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-code-checker',
  standalone: true,
  imports: [FormsModule, CommonModule, HttpClientModule], 
  template: `
   <div class="absolute top-4 right-4 flex flex-col items-end space-y-2">
      <div class="flex items-center space-x-2">
        <input 
          type="text" 
          [(ngModel)]="codigo" 
          maxlength="6" 
          placeholder="Ingresa el código" 
          class="input input-bordered input-sm w-40 text-left"
        />
        <button 
          (click)="verificarCodigo()" 
          class="btn btn-active btn-neutral btn-sm">
          Validar
        </button>
      </div>

      <div 
        *ngIf="mensaje" 
        [ngClass]="esValido ? 'alert-success' : 'alert-error'" 
        class="alert text-sm p-2 w-64 flex items-center justify-between mt-2">
        <div class="flex items-center space-x-2">
          <svg 
            xmlns="http://www.w3.org/2000/svg" 
            class="h-4 w-4 shrink-0 stroke-current" 
            fill="none" 
            viewBox="0 0 24 24">
            <path 
              [attr.d]="esValido ? 'M9 12l2 2 4-4m6 2a9 9 0 11-18 0 9 9 0 0118 0z' : ''" 
              stroke-linecap="round" stroke-linejoin="round" stroke-width="2" />
          </svg>
          <span>{{ mensaje }}</span>
        </div>
        <button (click)="cerrarAlerta()" class="text-xs font-bold ml-2">✖</button>
      </div>
    </div>
  `,
})
export class CodeCheckerComponent {
  codigo: string = '';
  mensaje: string = '';
  esValido: boolean = false;

  constructor(private http: HttpClient) {}

  verificarCodigo() {
    if (this.codigo.trim()) {
      this.http.get(`http://localhost:5140/api/ScratchCode/verify/${this.codigo}`)
        .subscribe(
          (response: any) => {
            this.mensaje = 'Código válido';
            this.esValido = true;
          },
          (error) => {
            if (error.status === 404) {
              this.mensaje = 'Código inválido';
            } else {
              console.error('Error:', error);
              this.mensaje = 'Error al verificar el código';
            }
            this.esValido = false;
          }
        );
    } else {
      this.mensaje = 'Ingresa un código primero';
      this.esValido = false;
    }
  }

  cerrarAlerta() {
    this.mensaje = '';
  }
}
