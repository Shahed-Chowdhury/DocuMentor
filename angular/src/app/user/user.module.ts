import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserRoutingModule } from './user-routing.module';
import { UserComponent } from './user.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { InviteUserComponent } from './invite-user/invite-user.component';
import { MailAdminComponent } from './mail-admin/mail-admin.component';


@NgModule({
  declarations: [
    UserComponent,
    LoginComponent,
    RegisterComponent,
    InviteUserComponent,
    MailAdminComponent
  ],
  imports: [
    CommonModule,
    UserRoutingModule
  ]
})
export class UserModule { }
