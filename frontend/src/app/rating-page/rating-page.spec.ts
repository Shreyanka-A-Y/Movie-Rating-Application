import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RatingPage } from './rating-page';

describe('RatingPage', () => {
  let component: RatingPage;
  let fixture: ComponentFixture<RatingPage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RatingPage],
    }).compileComponents();

    fixture = TestBed.createComponent(RatingPage);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
