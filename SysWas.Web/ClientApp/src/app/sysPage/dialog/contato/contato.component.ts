import { Component, OnInit, ViewChild, Inject } from '@angular/core';

import { Validators, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { MatInput, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { stringify } from '@angular/compiler/src/util';
import { ContatoService } from '../../../services/utilitarios/contato.service';
import { Contato } from '../../../model/utilitarios/contato';





@Component({
  selector: 'app-contato',
  templateUrl: './contato.component.html',
  styleUrls: ['./contato.component.css']
})
export class ContatoComponent implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<ContatoComponent>,
    @Inject(MAT_DIALOG_DATA) public contato: Contato,
    private contatoService: ContatoService,
    private router: Router
  ) { }

  //public contato: Contato;

  public mensagem: string;
  private ativar_spinner: boolean;
  public arquivoSelecionado: File;

  nomeFc = new FormControl('', [Validators.required]);
  cargoFc = new FormControl('', [Validators.required]);
  celularFc = new FormControl('', [Validators.required]);
  emailFc = new FormControl('', [Validators.required]);

  public maskCel = ['(', /[0-9]/, /\d/, ')', /\d/, /\d/, /\d/, /\d/, /\d/, '-', /\d/, /\d/, /\d/, /\d/]


  ngOnInit() {

    let contatoSession = sessionStorage.getItem('contatoSession');

    if (contatoSession) {


      this.contato = JSON.parse(contatoSession);

      this.nomeFc.setValue(this.contato.nome);
      this.cargoFc.setValue(this.contato.cargo);
      this.celularFc.setValue(this.contato.telefone);
      this.emailFc.setValue(this.contato.email);


    } else {

      this.contato = new Contato();
      
    }

  }

  teste() {
    this.contato.nome = this.nomeFc.value;
    this.contato.cargo = this.cargoFc.value;
    this.contato.email = this.emailFc.value;
    this.contato.telefone = this.celularFc.value;

    this.dialogRef.close(this.contato);

  }

  cadastrar() {

    this.ativarEspera();
    this.contatoService.cadastrar(this.contato)
      .subscribe(

        contato => {


          this.desativarEspera();
         

        },
        e => {

          this.mensagem = e.error;
          this.desativarEspera();
        }

      );

  }

  public onClickCancel() {

    this.dialogRef.close(false);

  }

  public ativarEspera() {
    this.ativar_spinner = true;
  }

  public desativarEspera() {
    this.ativar_spinner = false;
  }


}
