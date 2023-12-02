import { Component, ViewChild, ElementRef,ViewContainerRef, HostListener, ComponentRef, ComponentFactoryResolver, AfterViewInit } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { HttpClient } from '@angular/common/http';
import { AlComponentChatTextValueComponent } from './ChatComponents/al-component-chat-text-value/al-component-chat-text-value.component';
import { AlComponentChatReciveComponent } from './ChatComponents/al-component-chat-recive/al-component-chat-recive.component';
import { SharedSessionService } from './ChatComponents/Services/shared-session.service';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css']
})
export class ChatComponent {
zdj = '/assets/test.png';

textes:any = [];
  userNick = "Użytkownik";
  ElierMessageFrom = "";
  @ViewChild('I_TextBox')I_TextBox!:ElementRef;
  @ViewChild('D_ChatCointainer', { read: ViewContainerRef }) D_ChatCointainer!: ViewContainerRef;
  @ViewChild('sc', { static: false }) sc!: ElementRef;

  @ViewChild('Container')Container!:ElementRef; //D_ChatInfoAll
  @ViewChild('D_ChatInfoAll')D_ChatInfoAll!:ElementRef;//D_ChatInfo
  @ViewChild('D_ChatInfo')D_ChatInfo!:ElementRef; //D_AnswerDisplay
  @ViewChild('D_AnswerDisplay')D_AnswerDisplay!:ElementRef;
  @ViewChild('P_AnwserTo')P_AnwserTo!:ElementRef;
//P_AnwserTo
  NicksInChat:any;
  
  MyLastMessage = "";
  chatID = 0;

ngAfterViewInit()
  {
  }

  constructor(private SharedSession:SharedSessionService, private componentFactoryResolver: ComponentFactoryResolver, private cookieService:CookieService, private http:HttpClient)
  {
    SharedSession.ConnectWithSession();
    

    SharedSession.HubConnetion.on('ReceiveMessage', (message:string, ByUserID:number, ToChatID:number, AnwserTo:number) => {
      console.log("x:" + message);
      
      if(Number.parseInt(this.cookieService.get("id")) != ByUserID)
      {
        const componentFactory = this.componentFactoryResolver.resolveComponentFactory(AlComponentChatReciveComponent);
        const componentRef: ComponentRef<AlComponentChatReciveComponent> = this.D_ChatCointainer.createComponent(componentFactory);
        componentRef.instance.TextValue = message;
        componentRef.instance.I_FocusOnInput = this.I_TextBox;
      }
      else
      {
        const componentFactory = this.componentFactoryResolver.resolveComponentFactory(AlComponentChatReciveComponent);
        const componentRef: ComponentRef<AlComponentChatReciveComponent> = this.D_ChatCointainer.createComponent(componentFactory);
        componentRef.instance.TextValue = message;
        componentRef.instance.I_FocusOnInput = this.I_TextBox;
      }

      setTimeout(()=>{
        const element = this.sc.nativeElement;
        element.scrollTop = element.scrollHeight;
      }, 100);
    });
  }

  //Wysyła wiadomość do grupy //Oraz dodaje do swojego widoku 
  SendText()
  {
    if(this.I_TextBox.nativeElement.value != '')
    {
      let text = this.I_TextBox.nativeElement.textContent as string;
      
      //Sprawdza czy jest połączony z serwerem
      if(this.SharedSession.HubConnetion.state == "Connected")
      {
        this.SharedSession.HubConnetion?.invoke('SendMessageToGroup', text.trim().toString(), 0, 0, 0);
        
      }

      this.I_TextBox.nativeElement.value = '';

      
    }
  }

  @HostListener('document:keydown', ['$event'])
  handleKeyboardEvent(event: KeyboardEvent) {
    if(event.keyCode === 13)
    {
      event.preventDefault();
      this.SendText();
    }
  }
    
}

