import { Component, ViewChild, ElementRef } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-login-container',
  templateUrl: './login-container.component.html',
  styleUrls: ['./login-container.component.css']
})
export class LoginContainerComponent {
tlo = '/assets/sunset.png';

@ViewChild('Login')Login!:ElementRef;
@ViewChild('Password')Password!:ElementRef;
@ViewChild('LoginError')LoginError!:ElementRef;

  constructor(private http: HttpClient, private router:Router, private cookieService:CookieService){}
  LoginToApp()
  {
    console.log("x");
    console.log(this.Login.nativeElement.value + "x");
    let body = {
      "login": this.Login.nativeElement.value,
      "password": this.Password.nativeElement.value
    };

    this.http.post('http://api.hackathon.authdevs.com/LoginToAccount', body).subscribe(response => {
      let jsonStr = JSON.stringify(response);
      let jsonObj = JSON.parse(jsonStr);

      console.log(jsonObj);

      if(jsonObj.id == -1)
      {
        console.log("Nnie się zalogowac");
        //Nie udało się zalogować
        this.LoginError.nativeElement.style.display = "block";
      }
      else
      {
        //Udało się zalogować 
        console.log("Udalo się zalogowac");
        this.router.navigate(["main"]);
        this.LoginError.nativeElement.style.display = "none";
        this.cookieService.set("id", jsonObj.id);
      }
    });
  }
}
