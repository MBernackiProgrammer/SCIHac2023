import { HttpClient } from '@angular/common/http';
import { AfterViewInit, Component, ElementRef, ViewChild } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { DomSanitizer, SafeUrl  } from '@angular/platform-browser';

@Component({
  selector: 'app-main-container',
  templateUrl: './main-container.component.html',
  styleUrls: ['./main-container.component.css']
})
export class MainContainerComponent implements AfterViewInit{
  @ViewChild('UserPhoto') UserPhoto!:ElementRef;
  @ViewChild('UserDescribe') UserDescribe!:ElementRef;

  @ViewChild('SelectPerson') SelectPerson!:ElementRef;
  @ViewChild('NoPersons') NoPersons!:ElementRef;

  @ViewChild('B_Next') B_Next!:ElementRef;
  @ViewChild('B_SendReq') B_SendReq!:ElementRef;

  displayedImage!:SafeUrl;
  //NoPersons
  //SelectPerson

  noPersonsWithFilters()
  {
    this.SelectPerson.nativeElement.style.display = "none";
    this.NoPersons.nativeElement.style.display = "block";
    
    this.B_Next.nativeElement.style.display = "none";
    this.B_SendReq.nativeElement.style.display = "none";
  }

  GetPerson()
  {
    let body = {
      "userID": 1
    };
  
    this.http.post('http://api.hackathon.authdevs.com/NextMatch', body).subscribe(response => {
      let jsonStr = JSON.stringify(response);
      let jsonObj = JSON.parse(jsonStr);

      console.log(jsonObj);
      if(jsonObj.gotPerson == -1)
      {
        //Nie ma osób w z filrem
        this.noPersonsWithFilters();
        return;
      }
      else
      {
        //Pokazuje osoby 
        this.Acctual = jsonObj.UserID;

        let body = {
          'fileID': 1,
        };
    
        //this.http.post('http://api.authcontrol.pl/authservices/getPhoto', body).subscribe(response => { });
    
        this.http.post("http://api.hackathon.authdevs.com/GetUserImage", body, { responseType: 'blob' })
        .subscribe(blob => {
          
          const safeUrl: SafeUrl = this.sanitizer.bypassSecurityTrustUrl(URL.createObjectURL(blob));
          this.displayedImage = safeUrl;
        });
      }
    });

    
  }

  ngAfterViewInit(): void {
    this.GetPerson();
  }

  constructor(private http: HttpClient, private cookieSercies:CookieService, private sanitizer: DomSanitizer) {}
  Acctual = 0;
  IsDoneAnimation:Boolean = true;
  Next()
  {
    if(this.IsDoneAnimation == true)
    {
      this.IsDoneAnimation = false;
      this.UserPhoto.nativeElement.style.scale = 0.5;
      this.UserPhoto.nativeElement.style.rotate = "-30deg";
      this.UserPhoto.nativeElement.style.marginLeft = "-150px";
      this.UserPhoto.nativeElement.style.opacity = 0;
  
      this.UserDescribe.nativeElement.style.marginTop = "-150px";
      this.UserDescribe.nativeElement.style.opacity = 0;
  
      setTimeout(()=>{
        this.UserPhoto.nativeElement.style.scale = 1;
        this.UserPhoto.nativeElement.style.rotate = "0deg";
        this.UserPhoto.nativeElement.style.marginLeft = "0px";
        this.UserPhoto.nativeElement.style.opacity = 0;
    
        this.UserDescribe.nativeElement.style.marginTop = "0px";
        this.GetPerson();
      }, 500);
  
      setTimeout(()=>{
        this.UserPhoto.nativeElement.style.opacity = 1;
        this.UserDescribe.nativeElement.style.opacity = 1;
        
      }, 1000)
      setTimeout(()=>{
        this.IsDoneAnimation = true;

      }, 2000);
    }
    
  }

  SendRequest()
  {
    let body = {
      "byUserID": this.cookieSercies.get("id"),
      "toUserID": this.Acctual
    };
  
    this.http.post('http://api.hackathon.authdevs.com/SendRequest', body).subscribe(response => {
      let jsonStr = JSON.stringify(response);
      let jsonObj = JSON.parse(jsonStr);
    });
    
    if(this.IsDoneAnimation == true)
    {

      this.IsDoneAnimation = false;
      this.UserPhoto.nativeElement.style.scale = 0.5;
      this.UserPhoto.nativeElement.style.opacity = 0;
      this.UserDescribe.nativeElement.style.marginLeft = "350px";
      this.UserDescribe.nativeElement.style.scale = 0.5;
      this.UserDescribe.nativeElement.style.opacity = 0;
  
      setTimeout(()=>{
        this.UserPhoto.nativeElement.style.marginLeft = "0px";
        this.UserDescribe.nativeElement.style.marginLeft = "0px";
        this.GetPerson();
      }, 500);
      setTimeout(()=>{
        
        this.UserPhoto.nativeElement.style.scale = 1;
        this.UserPhoto.nativeElement.style.opacity = 1;
        
        this.UserDescribe.nativeElement.style.scale = 1;
        this.UserDescribe.nativeElement.style.opacity = 1;
      }, 1000);

      setTimeout(()=>{
        this.IsDoneAnimation = true;
      }, 2000);
    }
    
  }
}
