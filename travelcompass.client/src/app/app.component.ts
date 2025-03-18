import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { CategoryClient } from './Services/TravelCompassClient';

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
name:string=""

  constructor(private clinet:CategoryClient) {}

  ngOnInit() {
    const host = window.location.hostname;
const subdomain = host.split('.')[0]; // Extract "site-name" from "site-name.127.0.0.1"
this.getData(subdomain);
  }

  getData(subdomain:string){

    this.clinet.getCategory(subdomain).subscribe(data=>{
      this.name=data.name as string
      console.log(data.name)
    })
  }

  title = 'travelcompass.client';
}
