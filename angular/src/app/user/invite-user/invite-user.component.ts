import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl, AbstractControl } from '@angular/forms';
import CustomValidators from 'src/app/shared/CustomValidators';

@Component({
  selector: 'app-invite-user',
  templateUrl: './invite-user.component.html',
  styleUrls: ['./invite-user.component.css']
})
export class InviteUserComponent implements OnInit {

  inviteUserForm!: FormGroup
  valid: boolean = true

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.InviteUserFormBuilder()
  }

  InviteUserFormBuilder(){
    this.inviteUserForm = this.fb.group({
      email: [null, [Validators.required]], 
      message: [null]
    }, {validators: CustomValidators.emailValidationFn})
  }

  get Email(){
    return this.inviteUserForm.get('email') as FormControl
  }

  get Message(){
    return this.inviteUserForm.get('message') as FormControl
  }

  onSubmit(){
    if(this.inviteUserForm.invalid){
      this.valid = false
      return
    }else{
      this.valid = true
      console.log(this.inviteUserForm)
    }
  }

  resetForm(){
    this.inviteUserForm.reset();
    this.valid = true
  }
}
