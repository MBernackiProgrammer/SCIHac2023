import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AnkietaContainerComponent } from './ankieta-container.component';

describe('AnkietaContainerComponent', () => {
  let component: AnkietaContainerComponent;
  let fixture: ComponentFixture<AnkietaContainerComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AnkietaContainerComponent]
    });
    fixture = TestBed.createComponent(AnkietaContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
