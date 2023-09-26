import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class simcardsService {
  baseUrl = "https://localhost:7158/api";
  constructor(private http: HttpClient) { 

  }
  getsimcard()
  {
    return this.http.get(this.baseUrl+"/listsimcards");
  }
  getsimcardById(id:number)
  {
    return this.http.get(this.baseUrl+"/listsimcards/" + id);
  }
  deletesimcards(id:number)
  {
    return this.http.delete(this.baseUrl+"/listsimcards/" + id);
  }
  updatesimcards(id:number, data:string)
  {
    console.info(data);
    return this.http.put(this.baseUrl + "/listsimcards/" + id, data);
  }
  createsimcards(data:string)
  {
    console.log("From listsimcards Service");
    console.log(data);
    return this.http.post(this.baseUrl + "/listsimcards/", data);
  }
}
