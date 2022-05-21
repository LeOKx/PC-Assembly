import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { catchError, of } from 'rxjs';
import { UserForRegistrationDto } from 'src/app/interface/user/userForRegistrationDto';
import { PasswordConfirmationValidatorService } from 'src/app/shared/custom-validators/password-confirmation-validator.service';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';

@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.css']
})
export class RegisterUserComponent implements OnInit {
  public registerForm: FormGroup;
  public errorMessage: string = '';
  public showError: boolean;

  constructor(private _authService: AuthenticationService, private _passConfValidator: PasswordConfirmationValidatorService, private _router: Router) { }

  ngOnInit(): void {
    this.registerForm = new FormGroup({
      firstName: new FormControl('',[Validators.required, Validators.minLength(2), Validators.maxLength(50)]),
      lastName: new FormControl('',[Validators.required, Validators.minLength(2), Validators.maxLength(50)]),
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required]),
      confirm: new FormControl('')
    });
    this.registerForm.get('confirm').setValidators([Validators.required,
      this._passConfValidator.validateConfirmPassword(this.registerForm.get('password'))]);
  }

  public hasError = (controlName: string, errorName: string) => {
    return this.registerForm.controls[controlName].hasError(errorName)
  }
  public registerUser = () => {
    if(!this.registerForm.valid){
      return;
    }
    this.showError = false;
    const formValues = this.registerForm.value;
    const user: UserForRegistrationDto = {
      firstName: formValues.firstName,
      lastName: formValues.lastName,
      email: formValues.email,
      password: formValues.password,
      confirmPassword: formValues.confirm
    };
    this._authService.registerUser("accounts/registration", user)
    .pipe(
      catchError((error: string) => {
        this.errorMessage = error;
        this.showError = true;
        return of();
    }
    ))
    .subscribe(() => {
      this._router.navigate(["/authentication/login"]);
    }
    )
  }
}