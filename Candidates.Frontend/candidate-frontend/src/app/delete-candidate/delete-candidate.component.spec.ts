import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteCandidateComponent } from './delete-candidate.component';

describe('DeleteCandidateComponent', () => {
  let component: DeleteCandidateComponent;
  let fixture: ComponentFixture<DeleteCandidateComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DeleteCandidateComponent]
    });
    fixture = TestBed.createComponent(DeleteCandidateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
