import { Component, OnInit } from '@angular/core';
import { CategoryClient } from '../Services/TravelCompassClient';

@Component({
  selector: 'app-store',
  templateUrl: './store.component.html',
  styleUrls: ['./store.component.css']
})
export class StoreComponent implements OnInit {
name:string | undefined;
  constructor() { }

  ngOnInit(): void {

  }


}
