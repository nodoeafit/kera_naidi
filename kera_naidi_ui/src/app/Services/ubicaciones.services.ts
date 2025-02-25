import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'  // Hace que el servicio esté disponible en toda la app
})
export class UbicacionesService {
  private apiUrl = 'http://localhost:5199/api/ubicaciones'; // URL de la API

  constructor(private http: HttpClient) {}

  getUbicaciones(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }
}