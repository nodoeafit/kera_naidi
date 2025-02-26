import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable({providedIn: 'root'})
export class HealthService{
  httpOptions:{headers: HttpHeaders}

  constructor(private http: HttpClient){
    this.httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':'application/json',
        'Authorization': 'Bearer ' + 'TOKEN'
      })
    }
  }

  getHealth(): Observable<any>{
    return this.http.post("http://localhost:5140/api/health/HealthCheck", this.httpOptions);
  }
}
