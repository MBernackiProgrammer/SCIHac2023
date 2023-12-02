import { AfterViewInit, Component, ElementRef, ViewChild } from '@angular/core';

@Component({
  selector: 'app-al-component-chat-recive',
  templateUrl: './al-component-chat-recive.component.html',
  styleUrls: ['./al-component-chat-recive.component.css']
})
export class AlComponentChatReciveComponent {
  TextValue = "";
  MarginTop = 0;
  UserName = "";
  MessegeID = 0;

  AnswerTo = 0;
  AnswerToMessage = "";

  I_FocusOnInput!:ElementRef;

  @ViewChild('D_Answer')D_Answer!:ElementRef;
  
  ngAfterViewInit(): void {
    if(this.AnswerTo == -1)
    {
      this.D_Answer.nativeElement.style.display = "none";
    }

    if(this.AnswerToMessage.length > 30)
    {
      let x= this.AnswerToMessage; 
      this.AnswerToMessage =  x.substring(0, 30) + "...";
    }
  }
}
