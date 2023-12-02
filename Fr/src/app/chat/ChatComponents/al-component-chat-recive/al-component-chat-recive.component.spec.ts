import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AlComponentChatReciveComponent } from './al-component-chat-recive.component';

describe('AlComponentChatReciveComponent', () => {
  let component: AlComponentChatReciveComponent;
  let fixture: ComponentFixture<AlComponentChatReciveComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AlComponentChatReciveComponent]
    });
    fixture = TestBed.createComponent(AlComponentChatReciveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
