import { Component, OnInit } from '@angular/core';
import { AuthorService } from 'src/app/shared/author.service';

@Component({
  selector: 'app-page-aut2',
  templateUrl: './page-aut2.component.html',
  styleUrls: ['./page-aut2.component.scss']
})
export class PageAut2Component implements OnInit {

  constructor(public services:AuthorService) { }

  ngOnInit(): void {
    this.services.getAllAuthors();

  }
}
