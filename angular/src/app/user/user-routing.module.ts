import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserComponent } from './user.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { InviteUserComponent } from './invite-user/invite-user.component';
import { MailAdminComponent } from './mail-admin/mail-admin.component';

const routes: Routes = [
  { path: '', component: UserComponent},
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent},
  { path: 'invite-user', component: InviteUserComponent},
  { path: 'send-mail-admin', component: MailAdminComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
