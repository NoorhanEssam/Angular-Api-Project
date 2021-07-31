import { Component, OnInit } from '@angular/core';
import { AuthorService } from "src/app/shared/author.service";
@Component({
  selector: 'app-athour-list',
  templateUrl: './athour-list.component.html',
  styleUrls: ['./athour-list.component.scss']
})
export class AthourListComponent implements OnInit {

  constructor(public services:AuthorService) { }

  ngOnInit(): void {
    this.services.getAllAuthors();

  }
}
