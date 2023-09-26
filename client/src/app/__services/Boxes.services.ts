import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BoxesService {
  baseUrl = "https://localhost:7158/api";
  constructor(private http: HttpClient) { 

  }
  getBoxes()
  {
    return this.http.get(this.baseUrl+"/Boxes");
  }
  getBoxesById(id:number)
  {
    return this.http.get(this.baseUrl+"/Boxes/" + id);
  }
  deleteBoxes(id:number)
  {
    return this.http.delete(this.baseUrl+"/Boxes/" + id);
  }
  updateBoxes(id:number, data:string)
  {
    console.info(data);
    return this.http.put(this.baseUrl + "/Boxes/" + id, data);
  }
  createBoxes(data:string)
  {
    console.log("From Boxes Service");
    console.log(data);
    return this.http.post(this.baseUrl + "/Boxes/", data);
  }
}
