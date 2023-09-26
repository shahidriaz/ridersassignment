import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListsimsComponent } from './listsims.component';

describe('ListsimsComponent', () => {
  let component: ListsimsComponent;
  let fixture: ComponentFixture<ListsimsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ListsimsComponent]
    });
    fixture = TestBed.createComponent(ListsimsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
