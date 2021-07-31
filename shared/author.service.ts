import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { author } from "../shared/model";

@Injectable({
  providedIn: 'root'
})
export class AuthorService {

  authors!:any[];
  _url:string='http://localhost:4544/api/Authors';
  constructor(private http:HttpClient) { }

  getAllAuthors(){
    this.http.get(this._url).toPromise().then(
      res=>{
        this.authors=res as author[];
      }
    )
  }
}
