import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegistContainerComponent } from './regist-container.component';

describe('RegistContainerComponent', () => {
  let component: RegistContainerComponent;
  let fixture: ComponentFixture<RegistContainerComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [RegistContainerComponent]
    });
    fixture = TestBed.createComponent(RegistContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
