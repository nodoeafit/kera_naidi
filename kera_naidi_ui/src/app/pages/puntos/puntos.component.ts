import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-puntos',
  standalone: true,
  imports: [FormsModule, CommonModule],
  template: `
  <div class="flex justify-center items-center min-h-screen bg-base-200 px-4">
    <div class="w-full max-w-3xl p-6 bg-white shadow-lg rounded-lg">
      
      <h1 class="text-4xl font-bold text-center text-green-600">Ecopoints</h1>
      <p class="text-center text-gray-600 text-lg italic mt-2">
        ¡Recicla, gana puntos y canjea recompensas! ♻💚
      </p>

      <section class="mt-6 space-y-6">
        <div class="card bg-base-100 shadow-md p-6">
          <h2 class="text-2xl font-bold text-green-700">Únete a Ecopoints</h2>
          <p class="text-gray-600">Ayuda al planeta mientras obtienes increíbles beneficios.</p>
        </div>

        <div class="card bg-base-100 shadow-md p-6">
          <h2 class="text-2xl font-bold text-green-700">¿Cómo funciona?</h2>
          <ul class="list-disc list-inside text-gray-600 space-y-2">
            <li>♻ Recoge y recicla desechos.</li>
            <li>🎁 Acumula puntos por cada residuo.</li>
            <li>✨ Canjea tus puntos por recompensas.</li>
          </ul>
        </div>

        <div class="card bg-base-100 shadow-md p-6">
          <h3 class="text-2xl font-bold text-green-700">Tipos de residuos y puntos</h3>
          <ul class="space-y-2 text-gray-600">
            <li><strong>🔹 Vidrio:</strong> 30 puntos</li>
            <li><strong>🔹 Plásticos y Latas:</strong> 25 puntos</li>
            <li><strong>🔹 Papel y Cartón:</strong> 20 puntos</li>
            <li><strong>🔹 Orgánicos:</strong> 15 puntos</li>
            <li><strong>🔹 Especiales:</strong> 10 puntos</li>
            <li><strong>🔹 No Reciclables:</strong> 5 puntos</li>
          </ul>
        </div>
      </section>

      <div class="mt-8">
        <p class="text-center text-lg font-semibold text-gray-800">
          "Cada pequeña cosa que haces realmente importa, y ayuda a construir el mundo en el que quieres vivir 🌍"
        </p>
        <p class="text-right text-sm text-gray-500 italic">- Wangari Maathai</p>
      </div>

      <!-- Input de código y validación -->
      <div class="mt-6 flex flex-col items-center space-y-2">
        <div class="flex items-center space-x-2">
          <input 
            type="text" 
            [(ngModel)]="codigo" 
            maxlength="6" 
            placeholder="Ingresa el código" 
            class="input input-bordered w-40 text-left"
          />
          <button 
            (click)="validarCodigo()" 
            class="btn btn-success">
            Validar
          </button>
        </div>

        <div 
          *ngIf="mensaje" 
          [ngClass]="esValido ? 'alert alert-success' : 'alert alert-error'" 
          class="w-full max-w-xs text-center p-2 rounded-lg">
          {{ mensaje }}
        </div>
      </div>

    </div>
  </div>
  `,
})
export class PuntosComponent {
  codigo: string = '';
  mensaje: string = '';
  esValido: boolean = false;

  validarCodigo() {
    const mensajes: { [key: string]: string } = {
      'SSD862': '¡Felicidades! Has obtenido +15 puntos por residuos orgánicos',
      'IKA604': '¡Felicidades! Has obtenido +25 puntos por plásticos o latas',
      'YCU818': '¡Felicidades! Has obtenido +20 puntos por residuos de papel o cartón',
      'TYU336': '¡Felicidades! Has obtenido +30 puntos por residuos de vidrio',
      'LQD165': '¡Felicidades! Has obtenido +5 puntos por residuos no reciclables',
      'CDU831': '¡Felicidades! Has obtenido +10 puntos por residuos especiales',
    };

    if (mensajes[this.codigo]) {
      this.mensaje = mensajes[this.codigo];
      this.esValido = true;
    } else {
      this.mensaje = '¡ERROR! Código inválido';
      this.esValido = false;
    }
  }
}
