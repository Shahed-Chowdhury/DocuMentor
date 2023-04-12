import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl, AbstractControl } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm!: FormGroup
  valid: boolean = true

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.loginFormBuilder()
  }

  loginFormBuilder(){
    this.loginForm = this.fb.group({
      email: [null, [Validators.required]],
      password: [null, [Validators.required]],
    },
    {validators: [this.emailValidationFn]})
  }

  get Email(){
    return this.loginForm.get('email') as FormControl
  }

  get Password(){
    return this.loginForm.get('password') as FormControl
  }

  emailValidationFn(control: AbstractControl){
    let validEmailPattern = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/
    return validEmailPattern.test(control.get('email')?.value) === true ? null: { notmatched: true}
  }

  LoginFormOnSubmit(){
    if(this.loginForm.valid){
      console.log(this.loginForm);
      this.valid = true
    }else{
      this.valid = false
    }
  }

  ClearLoginForm(){
    this.loginForm.reset()
  }
}
