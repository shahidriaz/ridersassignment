import { Injectable } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {
  baseUrl = "https://localhost:7158/api";
  constructor(private http: HttpClient) { }
  getEmployees()
  {
    return this.http.get(this.baseUrl+"/employees");
  }
  getEmployeesById(id:number)
  {
    return this.http.get(this.baseUrl+"/employees/" + id);
  }
  deleteEmployees(id:number)
  {
    return this.http.delete(this.baseUrl+"/employees/" + id);
  }
  updateEmployees(id:number, data:string)
  {
    console.log("selected Id of Bike in Service is " + id);
    console.log("data to update " + data);
    return this.http.put(this.baseUrl + "/employees/" + id, data);
  }
  createEmployees(data:string)
  {
    return this.http.post(this.baseUrl + "/employees/", data);
  }
}
