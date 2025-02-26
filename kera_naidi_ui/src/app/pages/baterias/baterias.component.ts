import { Component, inject, OnInit } from '@angular/core';
import { Baterias, BateriasService } from './baterias.service';
import { CommonModule } from '@angular/common';



@Component({
  selector: 'app-baterias',
  imports: [ CommonModule],
  standalone: true, 
  templateUrl: './baterias.component.html',
  styleUrl: './baterias.component.css'
})
export class BateriasComponent implements OnInit{
  baterias: Baterias[] = [];
  constructor( private _bateriasService : BateriasService) {}
  // private bateriasService = inject(BateriasService); 

  ngOnInit():void {
         this.loadBaterias();
          }
  
  loadBaterias():void{
    this._bateriasService.getBaterias().subscribe({
      next: (data) => {
        this.baterias = data;
      },
      error: (error)=> {
        console.error(error)
      }
    })
  }
    


 
}