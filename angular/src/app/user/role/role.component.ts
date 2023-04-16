import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-role',
  templateUrl: './role.component.html',
  styleUrls: ['./role.component.css']
})
export class RoleComponent implements OnInit {

  roles: any

  constructor(private apiservice: ApiService) { }

  ngOnInit(): void {
    this.getAllRoles()
  }

  getAllRoles(){
    this.apiservice.getRoles().subscribe(res => {
      this.roles = res
      this.roles = this.roles.data
      console.log(this.roles);
    })
  }

}
