import { Injectable } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class BikeService {
  baseUrl = "https://localhost:7158/api";
  constructor(private http: HttpClient) { }
  getBikes()
  {
    return this.http.get(this.baseUrl+"/bike");
  }
  getBikeById(id:number)
  {
    return this.http.get(this.baseUrl+"/bike/" + id);
  }
  deleteBike(id:number)
  {
    return this.http.delete(this.baseUrl+"/bike/" + id);
  }
  updateBike(id:number, data:string)
  {
    console.log("selected Id of Bike in Service is " + id);
    console.log("data to update " + data);
    return this.http.put(this.baseUrl + "/bike/" + id, data);
  }
  createBike(data:string)
  {
    return this.http.post(this.baseUrl + "/bike/", data);
  }
}
