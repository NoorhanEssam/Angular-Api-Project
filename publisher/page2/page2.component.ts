import { Component, OnInit } from '@angular/core';
import { PublisherServicesService } from 'src/app/shared/publisher-services.service';

@Component({
  selector: 'app-page2',
  templateUrl: './page2.component.html',
  styleUrls: ['./page2.component.scss']
})
export class Page2Component implements OnInit {

  constructor(public services:PublisherServicesService) { }

  ngOnInit(): void {
    this.services. getAllPublishers();
  }
}
