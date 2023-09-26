import { Component } from '@angular/core';
import { ActivatedRoute, Router, UrlSegment } from '@angular/router';
import { EmployeesService } from 'src/app/__services/employees.service';
import {FormGroup, FormControl, FormsModule} from '@angular/forms'
import { formatDate } from '@angular/common' 
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-show-employees',
  templateUrl: './showemployees.component.html',
  styleUrls: ['./showemployees.component.css']
})
export class ShowEmployeesComponent {
  currentBike:any;
  isenable: boolean = false;
  isNew: boolean = false;
  myForm: FormGroup = new FormGroup({});
  formMode: string = "";
  employeesForm: FormGroup = new FormGroup({});
  selectedEmployeesId: number = 0;
  constructor(private employeesService: EmployeesService, 
    private router: Router, private route: ActivatedRoute, private toaster: ToastrService)
  {
    
  }
  ngOnInit() : void
  {
    
    this.enabledisableField(this.route.snapshot.url);
    if(this.route.snapshot.params['id'] != null)
    {
      this.employeesService.getEmployeesById(this.route.snapshot.params['id']).subscribe({
        next: res => { 
          this.currentBike = res;
          this.selectedEmployeesId =this.route.snapshot.params['id'];
          this.InitilizeForm();
        },
        error: (error)=>{console.log(error)},
        complete: ()=>console.log("Done")
      });
    }
    else
    {
      console.log("Create mode");
      this.InitilizeForm();
    }
  }

InitilizeForm()
{
  if(this.currentBike != null)
  {
    this.employeesForm = new FormGroup(
    {
      bikeName: new FormControl(this.currentBike.bikeName),
      bikeColor: new FormControl(this.currentBike.bikeColor),
      bikeModel: new FormControl(this.currentBike.bikeModel),
      bikeChasis: new FormControl(this.currentBike.bikeChasis),
      bikeNumber: new FormControl(this.currentBike.bikeNumber),
      mulkiyaNumber: new FormControl(this.currentBike.mulkiyaNumber),
      issueCity: new FormControl(this.currentBike.issueCity),
      issueDate: new FormControl(formatDate(this.currentBike.issueDate,'yyyy-MM-dd','en')),
      expireDate:new FormControl(formatDate(this.currentBike.expireDate,'yyyy-MM-dd','en')),
      bikeOwner: new FormControl(this.currentBike.bikeOwner),

    });
  }
  else
  {
    this.currentBike = {};
    this.employeesForm = new FormGroup(
      {
        bikeName: new FormControl(""),
        bikeColor: new FormControl(""),
        bikeModel: new FormControl(""),
        bikeChasis: new FormControl(""),
        bikeNumber: new FormControl(""),
        mulkiyaNumber: new FormControl(""),
        issueCity: new FormControl(""),
        issueDate: new FormControl(""),
        expireDate: new FormControl(""),
        bikeOwner: new FormControl(""),
      });
  }
}
  BackToEmployeesListing()
  {
    this.router.navigate(["/employees"]);
  }
  editBike(id:number)
  {
    this.router.navigate(["/edit-employees/" + id]);
  }
  enabledisableField(url:UrlSegment[]){
    if(url[0].path.includes("edit-employees"))
    {
      this.isenable = true;
    }
    else if(url[0].path.includes("create-employees"))
    {
      this.isenable = true;
      this.isNew = true;
    }
    else{
      this.isenable = false;
    }
  }
  submitEmployees()
  {
    this.formMode= this.getMode(this.route.snapshot.url);
    if(this.formMode.toLowerCase() == "delete")
    {
      // get the Employees id
      this.employeesService.deleteEmployees(this.selectedEmployeesId).subscribe({
        next: res=> {
          this.toaster.success("Employees deleted successfully!");
          setTimeout(()=>this.BackToEmployeesListing(), 3000);
        }, 
        error: error=>console.log(error),
        complete: ()=>console.log("Done")
      });

    }
    else if(this.formMode.toLowerCase() == "edit")
    {
      // get the bike id
      console.log("Selected Employees is " + this.selectedEmployeesId);
      console.log("Updated values " + this.employeesForm.value);
      this.employeesService.updateEmployees(this.selectedEmployeesId, this.employeesForm.value).subscribe({
        next: res=> 
        {
          this.toaster.success("Employees updated successfully");
          setTimeout(()=>this.BackToEmployeesListing(), 3000)
        },
        error: error=>console.log(error),
        complete: ()=>console.log("Done")
      });
    }
    else if(this.formMode.toLowerCase() == "create")
    {
      // get the rider id
      console.log("Updated values " + this.employeesForm.value);
      this.employeesService.createEmployees(this.employeesForm.value).subscribe({
        next: res=> {
          this.toaster.success("Employees added successfully");
          setTimeout(()=>this.BackToEmployeesListing,3000);
        },
        error: error=>console.log(error),
        complete: ()=>console.log("Done")
      });
    }
      console.log(this.formMode);
      console.log(this.employeesForm.value);
  }
  getMode(url: UrlSegment[]) : string
  {
    if(url[0].path.includes("edit-employees"))
    {
      return "Edit";
    }
    else if(url[0].path.includes("delete-employees") || url[0].path.includes("view-employees"))
    {
      return "Delete";
    }
    else if(url[0].path.includes("create-employees"))
    {
      return "create";
    }
    return "";
  }
}
