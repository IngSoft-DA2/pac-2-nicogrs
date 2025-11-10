import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';

let accessCount = 0; // contador en memoria

export const ReflectionGuard: CanActivateFn = (route, state) => {
  const router = inject(Router);
  accessCount++;
  console.log(`Acceso número ${accessCount}`);

  if (accessCount > 20) {
    alert('Has superado el límite de accesos a /reflection.');
    router.navigateByUrl('/');
    return false;
  }

  return true;
};