import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';

@Injectable({
  providedIn: 'root'
})
export class SharedSessionService {

  public HubConnetion!:HubConnection;

  constructor() 
  {
    this.HubConnetion = new HubConnectionBuilder().withUrl('http://api.hackathon.authdevs.com/chat', { withCredentials: false }).build();
    this.HubConnetion.start();
  }

  public ConnectWithSession()
  {
    let inter = setInterval(()=>{
      console.log(this.HubConnetion?.state)

      if(this.HubConnetion?.state == "Connected")
      {
        this.HubConnetion.invoke('JoinChatSession');
        clearInterval(inter);
      }
      
    }, 200);
  }
}
