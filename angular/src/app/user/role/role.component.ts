import { RoleDTO, CreateUpdateRoleDTO } from './../../models/Role/role-dto';
import { Component, OnInit, inject } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-role',
  templateUrl: './role.component.html',
  styleUrls: ['./role.component.css']
})
export class RoleComponent implements OnInit {

  roles: RoleDTO = {status: "", data: []}
  apiservice = inject(ApiService)
  fb = inject(FormBuilder) // dependency injection
  roleForm!: FormGroup

  constructor() { }

  ngOnInit(): void {
    this.getAllRoles()
    this.roleFormBuilder()
  }

  getAllRoles(){
    this.apiservice.getRoles().subscribe((res) => {
      this.roles = res
    })
  }

  roleFormBuilder(){
    this.roleForm = this.fb.group({
      name: [null, [Validators.required]]
    })
  }

  get Name(){
    return this.roleForm.get('name') as FormControl
  }

  addRole(){
    var role: CreateUpdateRoleDTO = {name: ''}
    role.name = this.Name.value
    this.apiservice.addRoles(role).subscribe(res => {
      this.getAllRoles()
    })
  }

  deleteRole(id: string){
    console.log(id);
  }

}



