import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { UsuarioService } from '../services/usuarios/usuario.service';

@Injectable({

  providedIn: 'root'

})
export class GuardRoutes implements CanActivate {

  constructor(private router: Router, private usuarioService: UsuarioService) {

  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {

    if (this.usuarioService.usuario_autenticado()) {
      return true;
    }

    this.router.navigate(['/entrar'], { queryParams: { returnUrl: state.url } });
    return false;

  }

}
