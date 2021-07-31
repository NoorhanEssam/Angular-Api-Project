import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Book, publishers } from "src/app/shared/model";
@Injectable({
  providedIn: 'root'
})
export class BookServicesService {

  book!:Book;
  books!: Book[];
  _url:string='http://localhost:4544/api/Books';
  readonly PhotoUrl = "http://localhost:4544/uploads/";
  readonly BookUrl = "http://localhost:4544/uploads/";
  url_Search='http://localhost:4544/api/Books/Search'
  url_Getbook='http://localhost:4544/api/book'
  
  url_category='http://localhost:4544/api/books/Category/';
  publisher!:publishers;
constructor(private http:HttpClient) 
{
     
}

UploadPhoto(val:any){
  return this.http.post('http://localhost:4544/api/Books/SaveFile',val);
}

UploadBook(val:any){
  return this.http.post('http://localhost:4544/api/Books/SaveBook',val);
}


getAllBooks(){
this.http.get(this._url).toPromise().then(
  res=>{
    this.books=res as Book[];
  }
)
}

  postBook(){
    return this.http.post(this._url,this.book);
  }
  

  getBookSearch(title:string){
    this.http.get(this.url_Search+'/'+title).toPromise().then(
      res=>{
        this.books=res as Book[];
      }
    )
  }





  getBookById(id:number){
    this.http.get(this.url_Getbook+'/'+id).toPromise().then(
      res=>{
        this.book=res as Book;
      }
    )
  }

  public getPDF(id:number): Observable<Blob> {   
    //const options = { responseType: 'blob' }; there is no use of this
        let uri = 'http://localhost:4544/api/books/download/';
        // this.http refers to HttpClient. Note here that you cannot use the generic get<Blob> as it does not compile: instead you "choose" the appropriate API in this way.
        return this.http.get(uri+id, { responseType: 'blob' });
    }

    getPublisher(){
      this.http.get('http://localhost:4544/api/Publishers/'+this.book.publisherId).toPromise().then(res=>{this.publisher=res as publishers });
    }
  
    getBookByCategory(id:number){
      this.http.get(this.url_category+'/'+id).toPromise().then(
        res=>{
          this.books=res as Book[];
        }
      )
    }
  

}
