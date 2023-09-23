import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListbikesComponent } from './listbikes.component';

describe('ListbikesComponent', () => {
  let component: ListbikesComponent;
  let fixture: ComponentFixture<ListbikesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ListbikesComponent]
    });
    fixture = TestBed.createComponent(ListbikesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
