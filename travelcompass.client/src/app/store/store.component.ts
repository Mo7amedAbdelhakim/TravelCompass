import { Component, OnInit } from '@angular/core';
import { CategoryClient } from '../Services/TravelCompassClient';

@Component({
  selector: 'app-store',
  templateUrl: './store.component.html',
  styleUrls: ['./store.component.css']
})
export class StoreComponent implements OnInit {
name:string | undefined;
  constructor(private clinet:CategoryClient) { }

  ngOnInit(): void {
    this.getSubDomain();
  }
  getData(subdomain:string){
    this.clinet.getCategory(subdomain).subscribe(data=>{
      this.name=data.name
    })
  }
getSubDomain(){
  const host = window.location.hostname;
const subdomain = host.split('.')[0]; // Extract "site-name" from "site-name.127.0.0.1"
console.log(subdomain);
}
}
