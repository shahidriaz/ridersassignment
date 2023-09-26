import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowEmployeesComponent } from './showemployees.component';

describe('ShowEmployeesComponent', () => {
  let component: ShowEmployeesComponent;
  let fixture: ComponentFixture<ShowEmployeesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ShowEmployeesComponent]
    });
    fixture = TestBed.createComponent(ShowEmployeesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
