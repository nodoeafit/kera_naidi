import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";


export interface Baterias  {
    id: number;
    codigo : string;
    porcentajeDeEnergia : number;
    isInUse: boolean;
    precio : number
  
}

  @Injectable ({
    providedIn: 'root'
  })

export class BateriasService {
    private apiUrl = 'http://localhost:5140/api/Baterias/GetAllBaterias';
    
    private http = inject (HttpClient);

    getBaterias(): Observable<Baterias[]>{
        return this.http.get<Baterias[]>(this.apiUrl)
    }
}
