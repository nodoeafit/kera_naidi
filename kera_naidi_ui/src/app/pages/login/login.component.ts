import { Component } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
    simulateGoogleLogin() {
        const googleWindow = window.open('', 'Google Login', 'width=500,height=600');
        if (googleWindow) {
          googleWindow.document.write(`
            <html>
              <head>
                <title>Google Login</title>
                <style>
                  body { 
                    display: flex; 
                    justify-content: center; 
                    align-items: center; 
                    height: 100vh; 
                    font-family: Arial, sans-serif;
                    flex-direction: column;
                  }
                  .logo { font-size: 24px; font-weight: bold; color: #4285F4; }
                  .container { text-align: center; width: 90%; max-width: 400px; }
                  .profile-pic { 
                    width: 80px; height: 80px; border-radius: 50%;
                    display: block; margin: 10px auto;
                  }
                  .email { font-size: 14px; color: #555; margin-bottom: 20px; }
                  .btn { 
                    background: #4285F4; color: white; padding: 10px 20px; 
                    border: none; cursor: pointer; font-size: 16px; 
                    display: flex; align-items: center; justify-content: center;
                    width: 100%; border-radius: 5px;
                  }
                  .btn img { width: 20px; margin-right: 10px; }
                  .link { color: #4285F4; cursor: pointer; font-size: 14px; margin-top: 10px; }
                  .success-container { display: none; text-align: center; }
                  .success-icon {
                    font-size: 50px; color: green; margin: 20px 0;
                  }
                </style>
                <script>
                  function showSuccess() {
                    document.getElementById('login-container').style.display = 'none';
                    document.getElementById('success-container').style.display = 'block';
                    setTimeout(() => { window.close(); }, 2000);
                  }
                </script>
              </head>
              <body>
                <div class="container" id="login-container">
                  <div class="logo">FREEPIK</div>
                  <h2>Log in</h2>
                  <p>Welcome back!</p>
                  <img class="profile-pic" src="https://www.w3schools.com/howto/img_avatar.png" alt="Profile Picture" />
                  <p class="email">user@example.com</p>
                  <button class="btn" onclick="showSuccess()">
                    <img src="assets/pngegg.png" alt="Google Logo" />
                    Continue as User
                  </button>
                  <p class="link" onclick="window.close()">Use another account</p>
                </div>
      
                <div class="container success-container" id="success-container">
                  <div class="success-icon">✅</div>
                  <h2>Registro exitoso</h2>
                  <p>Tu inicio de sesión se ha completado con éxito.</p>
                </div>
              </body>
            </html>
          `);
        }
      }
};