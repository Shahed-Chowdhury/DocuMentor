import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CreateUpdateRoleDTO, RoleDTO } from '../models/Role/role-dto';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private headers: HttpHeaders;
  Api_URL = "https://localhost:7131/api";

  constructor(private httpclient : HttpClient) { 
    this.headers = new HttpHeaders({
      "Content-Type": "application/json; charset=utf-8",
    });
  }

  getRoles(){ return this.httpclient.get<RoleDTO>(`${this.Api_URL}/roles`)}
  addRoles(data: CreateUpdateRoleDTO){ return this.httpclient.post(`${this.Api_URL}/roles`, data, {headers: this.headers })}
}
