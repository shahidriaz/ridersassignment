import { Component } from '@angular/core';
import { ActivatedRoute, Router, UrlSegment } from '@angular/router';
import { RiderService } from 'src/app/__services/rider.service';
import {FormGroup, FormControl, FormsModule} from '@angular/forms'
import { formatDate } from '@angular/common' 



@Component({
  selector: 'app-showrider',
  templateUrl: './showrider.component.html',
  styleUrls: ['./showrider.component.css']
})
export class ShowriderComponent {
  currentRider:any;
  isenable: boolean = false;
  isNew: boolean = false;
  myForm: FormGroup = new FormGroup({});
  formMode: string = "";
  riderForm: FormGroup = new FormGroup({});
  selectedRiderId: number = 0;
  constructor(private riderService: RiderService, 
    private router: Router, private route: ActivatedRoute)
  {
    console.log("Constructor of all Riders");
  }
  ngOnInit() : void
  {
    
    this.enabledisableField(this.route.snapshot.url);
    if(this.route.snapshot.params['id'] != null)
    {
      this.riderService.getRiderById(this.route.snapshot.params['id']).subscribe({
        next: res => { 
          this.currentRider = res;
          this.selectedRiderId =this.route.snapshot.params['id'];
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
  if(this.currentRider != null)
  {
    console.log("Logging Current Rider");
    console.info(this.currentRider);
    this.riderForm = new FormGroup(
    {
      name: new FormControl(this.currentRider.name),
      email: new FormControl(this.currentRider.email),
      companyNumber: new FormControl(this.currentRider.companyNumber),
      personalNumber: new FormControl(this.currentRider.personalNumber),
      emirateId: new FormControl(this.currentRider.emirateId),
      passportNumber: new FormControl(this.currentRider.passportNumber), 
      licensenumber: new FormControl(this.currentRider.licenseNumber),
      rriderid: new FormControl(this.currentRider.rriderId),
      emissuedate: new FormControl(formatDate(this.currentRider.emIssuedate,'yyyy-MM-dd','en')),
      emexpiredate: new FormControl(formatDate(this.currentRider.emExpiredate,'yyyy-MM-dd','en')),
      labourCard: new FormControl(this.currentRider.labourCard),
      lbissuedate: new FormControl(formatDate(this.currentRider.lbIssuedate,'yyyy-MM-dd','en')),
      lbExpiredate: new FormControl(formatDate(this.currentRider.lbExpiredate,'yyyy-MM-dd','en'))
    });
    
  }
  else
  {
    this.currentRider = {};
    this.riderForm = new FormGroup(
      {
        name: new FormControl(""),
        email: new FormControl(""),
        companyNumber: new FormControl(""),
        personalNumber: new FormControl(""),
        emirateId: new FormControl(""),
        passportNumber: new FormControl(""), 
        licensenumber: new FormControl(""),
        rriderid: new FormControl(""),
        emissuedate: new FormControl(""),
        emexpiredate: new FormControl(""),
        labourCard: new FormControl(""),
        lbissuedate: new FormControl(""),
        lbExpiredate: new FormControl("")
      });
  }
}

  BackToRiderListing()
  {
    this.router.navigate(["/riders"]);
  }
  editRider(id:number)
  {
    this.router.navigate(["/edit-rider/" + id]);
  }
  enabledisableField(url:UrlSegment[]){
    if(url[0].path.includes("edit-rider"))
    {
      this.isenable = true;
    }
    else if(url[0].path.includes("create-rider"))
    {
      this.isenable = true;
      this.isNew = true;
    }
    else{
      this.isenable = false;
    }
  }
  submitRider()
  {
    this.formMode= this.getMode(this.route.snapshot.url);
    if(this.formMode.toLowerCase() == "delete")
    {
      // get the rider id
      this.riderService.deleteRider(this.selectedRiderId).subscribe({
        next: res=> console.log("Rider deleted successfully!"),
        error: error=>console.log(error),
        complete: ()=>console.log("Done")
      });

    }
    else if(this.formMode.toLowerCase() == "edit")
    {
      // get the rider id
      console.log("Selected Rider is " + this.selectedRiderId);
      // console.log("Updated values " + this.riderForm.value);
      this.riderService.updateRider(this.selectedRiderId, this.riderForm.value).subscribe({
        next: res=> console.log(res),
        error: error=>console.log(error),
        complete: ()=>console.log("Done")
      });
    }
    else if(this.formMode.toLowerCase() == "create")
    {
      // get the rider id
      console.log("Updated values " + this.riderForm.value);
      this.riderService.createRider(this.riderForm.value).subscribe({
        next: res=> console.log(res),
        error: error=>console.log(error),
        complete: ()=>console.log("Done")
      });
    }
      console.log(this.formMode);
      console.log(this.riderForm.value);
  }
  getMode(url: UrlSegment[]) : string
  {
    if(url[0].path.includes("edit-rider"))
    {
      return "Edit";
    }
    else if(url[0].path.includes("delete-rider") || url[0].path.includes("view-rider"))
    {
      return "Delete";
    }
    else if(url[0].path.includes("create-rider"))
    {
      return "create";
    }
    return "";
  }
}
