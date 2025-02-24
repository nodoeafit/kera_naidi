import { Component, inject } from '@angular/core';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [ReactiveFormsModule, RouterLink],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  private apiUser = inject(UserService);
  private router = inject(Router);
  nombreC = new FormControl('')
  emailC = new FormControl('')
  contrasenaC = new FormControl('')
  confirmarcontrasenaC = new FormControl('')

  dataUsuario: any = {}


  resgistrarUsuario() {
    this.dataUsuario = {
      "nombre": this.nombreC.value,
      "email": this.emailC.value,
      "contrasenac": this.contrasenaC.value,
      "avatar": "https://yt3.googleusercontent.com/vRF8BHREiJ3Y16AbMxEi_oEuoQlnNNqGpgULuZ6zrWSAi24HcxX3Vko42RN8ToctH-G0qlWd=s900-c-k-c0x00ffffff-no-rj"
    }
    this.apiUser.registerUser(this.dataUsuario).subscribe(
      data => {
        console.log(data);
        alert("Registro Exitoso")
        this.router.navigate(['/inicio'])
      }
    )

  }
}
