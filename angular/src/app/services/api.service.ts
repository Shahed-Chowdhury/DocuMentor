import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

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

  getRoles(){ return this.httpclient.get(`${this.Api_URL}/roles`)}
}
