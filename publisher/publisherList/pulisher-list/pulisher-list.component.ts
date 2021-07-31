import { Component, OnInit } from '@angular/core';
import { PublisherServicesService } from 'src/app/shared/publisher-services.service';

@Component({
  selector: 'app-pulisher-list',
  templateUrl: './pulisher-list.component.html',
  styleUrls: ['./pulisher-list.component.scss']
})
export class PulisherListComponent implements OnInit {

  constructor(public services:PublisherServicesService) { }

  ngOnInit(): void {
    this.services. getAllPublishers();
  }

}
