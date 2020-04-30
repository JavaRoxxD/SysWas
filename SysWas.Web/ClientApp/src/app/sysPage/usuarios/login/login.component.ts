import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { templateJitUrl } from '@angular/compiler';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { Usuario } from '../../../model/usuarios/usuario';
import { UsuarioService } from '../../../services/usuarios/usuario.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']

})

export class LoginComponent implements OnInit {

  public usuario;
  public returnUrl: string;
  public mensagem: string;
  private ativar_spinner: boolean;

  constructor(private router: Router,
    private activatedRouter: ActivatedRoute,
    private usuarioService: UsuarioService) {


  }

  ngOnInit(): void {

    this.usuario = new Usuario();
    this.returnUrl = this.activatedRouter.snapshot.queryParams['returnUrl'];

  }


  entrar() {

    this.ativar_spinner = true;
    this.usuarioService.verificarUsuario(this.usuario)
      .subscribe(
        usuario_json => {

          this.usuarioService.usuario = usuario_json;
          // sessionStorage.setItem("usuario-autenticado", "1");
          console.log(usuario_json);


          if (this.returnUrl == null) {
            this.router.navigate(['/']);
          } else {
            this.router.navigate([this.returnUrl]);
          }

        },
        err => {
          this.ativar_spinner = false;
          console.log(err.error);
          this.mensagem = err.error;


        }
      );


    // if (this.usuario.email=="java-rox@hotmail.com" && this.usuario.senha=="123") {

    //  sessionStorage.setItem("usuario-autenticado", "1");


    //  if (this.returnUrl != "/entrar") {
    //    this.router.navigate(['/']);
    //  }
    //  else {

    // VAI SE FODER VOCÊS QUE FICARAM ME COBRANDO E PENSARAM QUE EU NÃO TRAMPAVA

    //    this.router.navigate([this.returnUrl]);

    //  }

  }


}


