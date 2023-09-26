import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeesService } from 'src/app/__services/employees.service';

@Component({
  selector: 'app-edit-employees',
  templateUrl: './edit-employees.component.html',
  styleUrls: ['./edit-employees.component.css']
})
export class EmployeesComponent {
  currentEmployees:any;
  constructor(private employeesService: EmployeesService, 
    private router: Router, private route: ActivatedRoute)
  {
    console.log("Constructor of all Riders");
  }
  ngOnInit() : void
  {
    
    this.employeesService.getEmployeesById(this.route.snapshot.params['id']).subscribe({
      next: res => { this.currentEmployees = res},
      error: (error)=>{console.log(error)},
      complete: ()=>console.log("Done")
    });
  }
  BackToEmployeesListing()
  {
    this.router.navigate(["/employees"]);
  }
  editRider()
  {
    this.router.navigate(["/employees"]);
  }

}
