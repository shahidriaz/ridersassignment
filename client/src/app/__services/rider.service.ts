import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class RiderService {
  baseUrl = "https://localhost:7158/api";
  constructor(private http: HttpClient) { 

  }
  getRiders()
  {
    return this.http.get(this.baseUrl+"/rider");
  }
  getRiderById(id:number)
  {
    return this.http.get(this.baseUrl+"/rider/" + id);
  }
  deleteRider(id:number)
  {
    return this.http.delete(this.baseUrl+"/rider/" + id);
  }
  updateRider(id:number, data:string)
  {
    console.info(data);
    return this.http.put(this.baseUrl + "/rider/" + id, data);
  }
  createRider(data:string)
  {
    console.log("From Rider Service");
    console.log(data);
    return this.http.post(this.baseUrl + "/rider/", data);
  }
}
