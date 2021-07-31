import { Component, OnInit } from '@angular/core';
import { BookServicesService } from 'src/app/shared/book-services.service';
import { Section3ServicesService } from "src/app/shared/section3-services.service";
@Component({
  selector: 'app-section3',
  templateUrl: './section3.component.html',
  styleUrls: ['./section3.component.scss']
})
export class Section3Component implements OnInit {

  // constructor(public services:Section3ServicesService) { }

  // ngOnInit(): void {
  //   this.services.getSuggestBooks();

  // }

  books!:any;

  id!:number;
    constructor(public bservices:BookServicesService,public services:Section3ServicesService) { 
      this.books=bservices.books;
    }
  
    ngOnInit(): void {
      this.services.getSuggestBooks();
    }
  

  
  getbookbyId(id:number){
  
    this.bservices.getBookById(id);
    console.log(id);
  
      }
  


}
