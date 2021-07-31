import { Injectable } from '@angular/core';
import { suggestBooks } from "../shared/model";
import { HttpClient } from "@angular/common/http";
@Injectable({
  providedIn: 'root'
})
export class Section3ServicesService {

  _url:string='http://localhost:4544/api/books/suggest';
 
  books!:suggestBooks[];
 
  constructor(private http:HttpClient) { }

   getSuggestBooks(){
     this.http.get(this._url).toPromise().then(res=>{
       this.books= res as suggestBooks[];
     })
   }






}
