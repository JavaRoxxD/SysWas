import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MadeiraComponent } from './madeira.component';

describe('MadeiraComponent', () => {
  let component: MadeiraComponent;
  let fixture: ComponentFixture<MadeiraComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MadeiraComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MadeiraComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
