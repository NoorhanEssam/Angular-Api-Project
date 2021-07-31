import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import {  } from "src/app/shared/publisher-services.service";
import { publishers } from './model';
@Injectable({
  providedIn: 'root'
})
export class PublisherServicesService {

  publishers!:any;
  _url='http://localhost:4544/api/Publishers';
  constructor(private http:HttpClient) { }

  getAllPublishers(){
    this.http.get(this._url).toPromise().then(res=>{this.publishers=res as publishers[]});
  }
}
