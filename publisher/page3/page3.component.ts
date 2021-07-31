import { Component, OnInit } from '@angular/core';
import { PublisherServicesService } from 'src/app/shared/publisher-services.service';

@Component({
  selector: 'app-page3',
  templateUrl: './page3.component.html',
  styleUrls: ['./page3.component.scss']
})
export class Page3Component implements OnInit {

  constructor(public services:PublisherServicesService) { }

  ngOnInit(): void {
    this.services. getAllPublishers();
  }
}
