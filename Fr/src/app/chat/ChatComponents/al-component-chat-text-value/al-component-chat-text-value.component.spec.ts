import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AlComponentChatTextValueComponent } from './al-component-chat-text-value.component';

describe('AlComponentChatTextValueComponent', () => {
  let component: AlComponentChatTextValueComponent;
  let fixture: ComponentFixture<AlComponentChatTextValueComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AlComponentChatTextValueComponent]
    });
    fixture = TestBed.createComponent(AlComponentChatTextValueComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
