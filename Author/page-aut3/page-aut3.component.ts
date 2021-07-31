import { Component, OnInit } from '@angular/core';
import { AuthorService } from 'src/app/shared/author.service';

@Component({
  selector: 'app-page-aut3',
  templateUrl: './page-aut3.component.html',
  styleUrls: ['./page-aut3.component.scss']
})
export class PageAUt3Component implements OnInit {

  constructor(public services:AuthorService) { }

  ngOnInit(): void {
    this.services.getAllAuthors();

  }

}
