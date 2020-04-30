import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { TruncateModule } from 'ng2-truncate';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { MadeiraComponent } from './sysPage/madeiras/madeira/madeira.component';
import { LoginComponent } from './sysPage/usuarios/login/login.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MainNavComponent } from './main-nav/main-nav.component';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatCheckboxModule } from '@angular/material/checkbox';


import { MatBadgeModule,
  MatGridListModule,
  MatSelectModule,
  MatRadioModule,
  MatDatepickerModule,
  MatNativeDateModule,
  MatChipsModule,
  MatTooltipModule,
  MatTableModule,
  MatPaginatorModule,
  MatCardModule,
  MatSortModule,
  MatExpansionModule,
  MatAutocompleteModule,
  MatDialogModule,


} from '@angular/material';

import { TextMaskModule } from 'angular2-text-mask';


import { GuardRoutes } from './authorization/guard.routes';

import { UsuarioService } from './services/usuarios/usuario.service';
import { CadastroUsuarioComponent } from './sysPage/usuarios/cadastro-usuario/cadastro-usuario.component';
import { MadeiraService } from './services/madeiras/madeira.service';
import { MatMenuModule } from '@angular/material/menu';
import { PesquisaMadeiraComponent } from './sysPage/madeiras/madeira/pesquisa/pesquisa.madeira.component';
import { PesquisaEspecieMadeiraComponent } from './sysPage/madeiras/especie-madeira/pesquisa/pesquisa.especie-madeira.component';
import { CadastroEspecieMadeiraComponent } from './sysPage/madeiras/especie-madeira/cadastro/cadastro.especie-madeira.component';
import { PesquisaTipoMadeiraComponent } from './sysPage/madeiras/tipo-madeira/pesquisa/pesquisa.tipo-madeira.component';
import { CadastroTipoMadeiraComponent } from './sysPage/madeiras/tipo-madeira/cadastro/cadastro.tipo-madeira.component';
import { PesquisaControleMadeiraComponent } from './sysPage/madeiras/controle-madeira/pesquisa/pesquisa.controle-madeira.component';
import { CadastroControleMadeiraComponent } from './sysPage/madeiras/controle-madeira/cadastro/cadastro.controle-madeira.component';
import { PesquisaLoteComponent } from './sysPage/madeiras/lote/pesquisa/pesquisa.lote.component';
import { CadastroLoteComponent } from './sysPage/madeiras/lote/cadastro/cadastro.lote.component';
import { PesquisaFardoComponent } from './sysPage/madeiras/fardo/pesquisa/pesquisa.fardo.component';
import { CadastroFardoComponent } from './sysPage/madeiras/fardo/cadastro/cadastro.fardo.component';
import { PesquisaInsumoComponent } from './sysPage/insumos/insumo/pesquisa.insumo/pesquisa.insumo.component';
import { CadastroInsumoComponent } from './sysPage/insumos/insumo/cadastro.insumo/cadastro.insumo.component';
import { PesquisaTipoInsumoComponent } from './sysPage/insumos/tipo-insumo/pesquisa.tipo-insumo/pesquisa.tipo-insumo.component';
import { CadastroTipoInsumoComponent } from './sysPage/insumos/tipo-insumo/cadastro.tipo-insumo/cadastro.tipo-insumo.component';
import { PesquisaControleInsumoComponent } from './sysPage/insumos/controle-insumo/pesquisa.controle-insumo/pesquisa.controle-insumo.component';
import { CadastroControleInsumoComponent } from './sysPage/insumos/controle-insumo/cadastro.controle-insumo/cadastro.controle-insumo.component';
import { PesquisaEstoqueInsumoComponent } from './sysPage/insumos/estoque-insumo/pesquisa.estoque-insumo/pesquisa.estoque-insumo.component';
import { CadastroEstoqueInsumoComponent } from './sysPage/insumos/estoque-insumo/cadastro.estoque-insumo/cadastro.estoque-insumo.component';
import { PesquisaEmpresaComponent } from './sysPage/empresas/empresa/pesquisa.empresa/pesquisa.empresa.component';
import { CadastroEmpresaComponent } from './sysPage/empresas/empresa/cadastro.empresa/cadastro.empresa.component';
import { InsumoService } from './services/insumos/insumo.service';
import { ControleInsumoService } from './services/insumos/controleInsumo.service';
import { EstoqueInsumoService } from './services/insumos/estoqueInsumo.service';
import { ListaInsumoService } from './services/compras/listaInsumo.service';
import { TipoInsumoService } from './services/insumos/tipoInsumo.service';
import { ControleMadeiraService } from './services/madeiras/controleMadeira.service';
import { EspecieMadeiraService } from './services/madeiras/especieMadeira.service';
import { TipoMadeiraService } from './services/madeiras/tipoMadeira.service';
import { EmpresaService } from './services/empresas/empresa.service';
import { EnderecoService } from './services/cep/endereco.service';
import { PesquisaFornecedorComponent } from './sysPage/fornecedores/fornecedor/pesquisa.fornecedor/pesquisa.fornecedor.component';
import { CadastroFornecedorComponent } from './sysPage/fornecedores/fornecedor/cadastro.fornecedor/cadastro.fornecedor.component';
import { ContatoComponent } from './sysPage/dialog/contato/contato.component';



@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    MadeiraComponent,
    LoginComponent,
    MainNavComponent,
    CadastroUsuarioComponent,
    ContatoComponent,
    PesquisaMadeiraComponent,
    PesquisaEspecieMadeiraComponent,
    CadastroEspecieMadeiraComponent,
    PesquisaTipoMadeiraComponent,
    CadastroTipoMadeiraComponent,
    PesquisaControleMadeiraComponent,
    CadastroControleMadeiraComponent,
    PesquisaLoteComponent,
    CadastroLoteComponent,
    PesquisaFardoComponent,
    CadastroFardoComponent,
    PesquisaInsumoComponent,
    CadastroInsumoComponent,
    PesquisaTipoInsumoComponent,
    CadastroTipoInsumoComponent,
    PesquisaControleInsumoComponent,
    CadastroControleInsumoComponent,
    PesquisaEstoqueInsumoComponent,
    CadastroEstoqueInsumoComponent,
    PesquisaEmpresaComponent,
    CadastroEmpresaComponent,
    PesquisaFornecedorComponent,
    CadastroFornecedorComponent,




  ],

  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    TextMaskModule,
    TruncateModule,
    RouterModule.forRoot([

      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'madeira', component: MadeiraComponent },
      { path: 'pesquisa-madeira', component: PesquisaMadeiraComponent },


      { path: 'entrar', component: LoginComponent },
      { path: 'cadastro-usuario', component: CadastroUsuarioComponent },
      { path: 'pesquisa-especie-madeira', component: PesquisaEspecieMadeiraComponent },
      { path: 'cadastro-especie-madeira', component: CadastroEspecieMadeiraComponent },
      { path: 'pesquisa-tipo-madeira', component: PesquisaTipoMadeiraComponent },
      { path: 'cadastro-tipo-madeira', component: CadastroTipoMadeiraComponent },
      { path: 'pesquisa-controle-madeira', component: PesquisaControleMadeiraComponent },
      { path: 'cadastro-controle-madeira', component: CadastroControleMadeiraComponent },
      { path: 'pesquisa-lote', component: PesquisaLoteComponent },
      { path: 'cadastro-lote', component: CadastroLoteComponent },
      { path: 'pesquisa-fardo', component: PesquisaFardoComponent },
      { path: 'cadastro-fardo', component: CadastroFardoComponent },
      { path: 'pesquisa-insumo', component: PesquisaInsumoComponent },
      { path: 'cadastro-insumo', component: CadastroInsumoComponent },
      { path: 'pesquisa-tipo-insumo', component: PesquisaTipoInsumoComponent },
      { path: 'cadastro-tipo-insumo', component: CadastroTipoInsumoComponent },
      { path: 'pesquisa-controle-insumo', component: PesquisaControleInsumoComponent },
      { path: 'cadastro-controle-insumo', component: CadastroControleInsumoComponent },
      { path: 'pesquisa-estoque-insumo', component: PesquisaEstoqueInsumoComponent },
      { path: 'cadastro-estoque-insumo', component: CadastroEstoqueInsumoComponent },
      { path: 'pesquisa-empresa', component: PesquisaEmpresaComponent },
      { path: 'cadastro-empresa', component: CadastroEmpresaComponent },
      { path: 'pesquisa-fornecedor', component: PesquisaFornecedorComponent },
      { path: 'cadastro-fornecedor', component: CadastroFornecedorComponent },

      //{ path: 'pesquisa-', component: Pesquisa---Component },
      //{ path: 'cadastro-', component: Cadastro---Component },






    ]),
    BrowserAnimationsModule,
    LayoutModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    MatFormFieldModule,
    MatInputModule,
    MatCheckboxModule,
    MatBadgeModule,
    MatGridListModule,
    MatSelectModule,
    MatRadioModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatChipsModule,
    MatTooltipModule,
    MatTableModule,
    MatPaginatorModule,
    MatCardModule,
    MatMenuModule,
    ReactiveFormsModule,
    MatSortModule,
    MatTableModule,
    MatExpansionModule,
    MatAutocompleteModule,
    MatDialogModule,



  ],
  exports: [
    MatMenuModule,

  ],

  entryComponents: [ContatoComponent],

  providers:
    [UsuarioService, EnderecoService,
    MadeiraService, ControleMadeiraService, EspecieMadeiraService, TipoMadeiraService,
    InsumoService, ControleInsumoService, EstoqueInsumoService, TipoInsumoService,
      EmpresaService,],

  bootstrap: [AppComponent],


})
export class AppModule { }





// { path: 'madeira', component: MadeiraComponent, canActivate: [GuardRoutes] },
