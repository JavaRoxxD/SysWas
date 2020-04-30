import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { Router } from '@angular/router';
import { UsuarioService } from '../services/usuarios/usuario.service';

@Component({
  selector: 'app-main-nav',
  templateUrl: './main-nav.component.html',
  styleUrls: ['./main-nav.component.css']
})
export class MainNavComponent {





  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

  constructor(private breakpointObserver: BreakpointObserver,
    private router: Router, private usuarioService: UsuarioService) { }




  otherTheme = false;

  changeTheme() {
    this.otherTheme = !this.otherTheme;
  }

  public usuarioLogado(): boolean {

    return this.usuarioService.usuario_autenticado();

  }

  sair() {

    this.usuarioService.limpar_session();
    this.router.navigate(['/entrar']);

  }


  get usuario() {

    console.log(this.usuarioService.usuario);

    return this.usuarioService.usuario;
  }

}
