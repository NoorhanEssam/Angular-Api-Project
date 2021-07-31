import { Component, OnInit } from '@angular/core';
import { BookServicesService } from 'src/app/shared/book-services.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  
  constructor(public serviceSearchBook:BookServicesService) { }
  title!:string;
  ngOnInit(): void {
  }
   
  Search(title:string){
    this.serviceSearchBook.getBookSearch(title);

  }


}
