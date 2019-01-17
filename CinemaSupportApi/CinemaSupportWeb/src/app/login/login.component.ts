import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../auth/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  registrationForm: FormGroup;
  submitted = false;
  returnUrl: string;
  error: {};
  loginError: string;
  registationSuccessed: string;
  private toogleGuard: boolean = true;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private authService: AuthService
    ) { }

  ngOnInit() {
    this.loginForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
    this.registrationForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
      confirmpassword: ['', Validators.required]
    });

   // this.authService.logout();
  }

  get username() { return this.loginForm.get('username'); }
  get password() { return this.loginForm.get('password'); }

  get userNameRegistationForm() {return this.registrationForm.get('username')}
  get passwordRegistationForm() {return this.registrationForm.get('password')}
  get confirmpasswordRegistationForm() {return this.registrationForm.get('confirmpassword')}

  onSubmit() {
    this.submitted = true;
    this.authService.login(this.username.value, this.password.value).subscribe((data) => {
      if (!!window.sessionStorage.getItem('IS_LOGED_IN') && window.sessionStorage.getItem('IS_LOGED_IN') == 'true') {
          const redirect = this.authService.redirectUrl ? this.authService.redirectUrl : '/premiere';
          this.router.navigate([redirect]);
        } else {
          this.loginError = 'Username or password is incorrect.';
        }
      },
      error => this.error = error
    );
  }

  onSubmitRegistration() {
    this.submitted = true;
    this.authService.register(this.userNameRegistationForm.value, this.passwordRegistationForm.value, this.confirmpasswordRegistationForm.value).subscribe((data) => {
      if (this.authService.isRegistered) {
        this.registationSuccessed = 'Registration success';
      } else {
        this.loginError = 'Username or password is incorrect.';
      }
      },
      error => this.error = error
    );
  }

  public changeView() {
      this.toogleGuard = !this.toogleGuard;   
  }


}