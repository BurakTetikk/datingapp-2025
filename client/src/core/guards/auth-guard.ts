import { inject } from '@angular/core/primitives/di';
import { AccountService } from '../services/account-service';
import { CanActivateFn } from '@angular/router';
import { ToastService } from '../services/toast-service';

export const authGuard: CanActivateFn = () => {
  const accountService = inject(AccountService);
  const toast = inject(ToastService);

  if (accountService.currentUser()) {
    return true;
  } else {
    toast.error('You shall not pass! Please login first.');
    return false;
  }
};
