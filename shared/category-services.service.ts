import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Book, category } from "../shared/model";
@Injectable({
  providedIn: 'root'
})
export class CategoryServicesService {

  _url:string='http://localhost:4544/api/Categories';
  url_Search='http://localhost:4544/api/Books/list'
  categories!:any;
  book!:Book;
  books!: Book[];

  constructor(private http:HttpClient) { }

  getAllCategories(){
    this.http.get(this._url).toPromise().then(res=>{this.categories=res as category[]},err=>{console.log(err)})
  }
  
  getBook(title:string){
    this.http.get(this.url_Search+'/'+title).toPromise().then(
      res=>{
        this.books=res as Book[];
      }
    )
  }
}
