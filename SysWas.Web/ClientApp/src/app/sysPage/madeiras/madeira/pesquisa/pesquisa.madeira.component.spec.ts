import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PesquisaMadeiraComponent } from './pesquisa.madeira.component';

describe('PesquisaMadeiraComponent', () => {
  let component: PesquisaMadeiraComponent;
  let fixture: ComponentFixture<PesquisaMadeiraComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [PesquisaMadeiraComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PesquisaMadeiraComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
