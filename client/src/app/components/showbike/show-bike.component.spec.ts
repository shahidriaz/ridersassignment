import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowBikeComponent } from './showbike.component';

describe('ShowBikeComponent', () => {
  let component: ShowBikeComponent;
  let fixture: ComponentFixture<ShowBikeComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ShowBikeComponent]
    });
    fixture = TestBed.createComponent(ShowBikeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
