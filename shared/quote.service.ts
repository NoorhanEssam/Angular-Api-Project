import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import {  } from "src/app/shared/quote.service";
import { quotes } from './model';

@Injectable({
  providedIn: 'root'
})
export class QuoteService {

  
  Quotes!:any;
  _url='http://localhost:4544/api/Quotes';
  constructor(private http:HttpClient) { }

  getAllQuotes(){
    this.http.get(this._url).toPromise().then(res=>{this. Quotes=res as  quotes[]});
  }
}
