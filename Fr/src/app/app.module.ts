import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginContainerComponent } from './login-container/login-container.component';
import { RegistContainerComponent } from './regist-container/regist-container.component';
import { AnkietaContainerComponent } from './ankieta-container/ankieta-container.component';
import { ProfilContainerComponent } from './profil-container/profil-container.component';
import { HeaderComponent } from './header/header.component';
import { ChatComponent } from './chat/chat.component';
import { MainContainerComponent } from './main-container/main-container.component';
import { HttpClientModule } from '@angular/common/http';

const appRoute: Routes = [
  {path:'',component:LoginContainerComponent},
  {path:'login',component:LoginContainerComponent},
  {path:'reg',component: RegistContainerComponent},
  {path:'ankieta',component: AnkietaContainerComponent},
  {path:'profil', component: ProfilContainerComponent},
  {path:'chat', component: ChatComponent},
  {path:'main', component: MainContainerComponent},
  {path:'**', component: LoginContainerComponent}
  
  
 
]
@NgModule({
  declarations: [
    AppComponent,
    LoginContainerComponent,
    RegistContainerComponent,
    AnkietaContainerComponent,
    ProfilContainerComponent,
    HeaderComponent,
    ChatComponent,
    MainContainerComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot(appRoute),
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
