import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { Pesquisa.LoteComponent } from './pesquisa.lote.component';

describe('Pesquisa.LoteComponent', () => {
  let component: Pesquisa.LoteComponent;
  let fixture: ComponentFixture<Pesquisa.LoteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ Pesquisa.LoteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Pesquisa.LoteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
