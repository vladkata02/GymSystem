import { ValidatorFn } from "@angular/forms";

export function appEmailValidator(): ValidatorFn {
  const re = new RegExp(/^[\w.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]{2,})+$/);
  return (control) => {
    return (control.value === '' || re.test(control.value)) ? null : { appEmailValidator: true };
  };
}
