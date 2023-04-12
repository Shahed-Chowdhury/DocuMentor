import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl, AbstractControl } from '@angular/forms';

@Component({
  selector: 'app-mail-admin',
  templateUrl: './mail-admin.component.html',
  styleUrls: ['./mail-admin.component.css']
})
export class MailAdminComponent implements OnInit {

  mailForm!: FormGroup

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.mailFormBuilder()
  }

  mailFormBuilder(){
    this.mailForm = this.fb.group({
      email: [null, [Validators.required]],
      message: [null]
    }, {validators: [this.emailValidationFn]})
  }

  get Email(){
    return this.mailForm.get('email') as FormControl
  }

  get Message(){
    return this.mailForm.get('message') as FormControl
  }

  emailValidationFn(control: AbstractControl){
    let validEmailPattern = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/
    return validEmailPattern.test(control.get('email')?.value) === true ? null: { notmatched: true}
  }


  submitMailForm(){
    console.log(this.mailForm);
  }


}
