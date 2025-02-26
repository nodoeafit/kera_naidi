import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { AppComponent } from './app/app.component';
import { FormsModule } from '@angular/forms';


bootstrapApplication(AppComponent, appConfig)
  .catch((err) => console.error(err));
