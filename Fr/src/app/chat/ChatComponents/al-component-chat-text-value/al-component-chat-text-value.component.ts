import { AfterViewInit, Component, ElementRef, Input, ViewChild } from '@angular/core';

@Component({
  selector: 'app-al-component-chat-text-value',
  templateUrl: './al-component-chat-text-value.component.html',
  styleUrls: ['./al-component-chat-text-value.component.css']
})
export class AlComponentChatTextValueComponent {
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
