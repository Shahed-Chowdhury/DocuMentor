import { ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';


import { UserRoutingModule } from './user-routing.module';
import { UserComponent } from './user.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { InviteUserComponent } from './invite-user/invite-user.component';
import { MailAdminComponent } from './mail-admin/mail-admin.component';
import { RoleComponent } from './role/role.component';


@NgModule({
  declarations: [
    UserComponent,
    LoginComponent,
    RegisterComponent,
    InviteUserComponent,
    MailAdminComponent,
    RoleComponent
  ],
  imports: [
    CommonModule,
    UserRoutingModule, 
    ReactiveFormsModule,
  ]
})
export class UserModule { }
