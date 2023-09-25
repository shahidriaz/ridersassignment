import { Component } from '@angular/core';
import { ActivatedRoute, Router, UrlSegment } from '@angular/router';
import { BikeService } from 'src/app/__services/bike.service';
import {FormGroup, FormControl, FormsModule} from '@angular/forms'
import { formatDate } from '@angular/common' 

@Component({
  selector: 'app-show-bike',
  templateUrl: './showbike.component.html',
  styleUrls: ['./showbike.component.css']
})
export class ShowBikeComponent {
  currentBike:any;
  isenable: boolean = false;
  isNew: boolean = false;
  myForm: FormGroup = new FormGroup({});
  formMode: string = "";
  bikeForm: FormGroup = new FormGroup({});
  selectedBikeId: number = 0;
  constructor(private bikeService: BikeService, 
    private router: Router, private route: ActivatedRoute)
  {
    
  }
  ngOnInit() : void
  {
    
    this.enabledisableField(this.route.snapshot.url);
    if(this.route.snapshot.params['id'] != null)
    {
      this.bikeService.getBikeById(this.route.snapshot.params['id']).subscribe({
        next: res => { 
          this.currentBike = res;
          this.selectedBikeId =this.route.snapshot.params['id'];
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
    this.bikeForm = new FormGroup(
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
    this.bikeForm = new FormGroup(
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
  BackToBikeListing()
  {
    this.router.navigate(["/bikes"]);
  }
  editBike(id:number)
  {
    this.router.navigate(["/edit-bike/" + id]);
  }
  enabledisableField(url:UrlSegment[]){
    if(url[0].path.includes("edit-bike"))
    {
      this.isenable = true;
    }
    else if(url[0].path.includes("create-bike"))
    {
      this.isenable = true;
      this.isNew = true;
    }
    else{
      this.isenable = false;
    }
  }
  submitBike()
  {
    this.formMode= this.getMode(this.route.snapshot.url);
    if(this.formMode.toLowerCase() == "delete")
    {
      // get the Bike id
      this.bikeService.deleteBike(this.selectedBikeId).subscribe({
        next: res=> console.log("Bike deleted successfully!"),
        error: error=>console.log(error),
        complete: ()=>console.log("Done")
      });

    }
    else if(this.formMode.toLowerCase() == "edit")
    {
      // get the bike id
      console.log("Selected Bike is " + this.selectedBikeId);
      console.log("Updated values " + this.bikeForm.value);
      this.bikeService.updateBike(this.selectedBikeId, this.bikeForm.value).subscribe({
        next: res=> console.log(res),
        error: error=>console.log(error),
        complete: ()=>console.log("Done")
      });
    }
    else if(this.formMode.toLowerCase() == "create")
    {
      // get the rider id
      console.log("Updated values " + this.bikeForm.value);
      this.bikeService.createBike(this.bikeForm.value).subscribe({
        next: res=> console.log(res),
        error: error=>console.log(error),
        complete: ()=>console.log("Done")
      });
    }
      console.log(this.formMode);
      console.log(this.bikeForm.value);
  }
  getMode(url: UrlSegment[]) : string
  {
    if(url[0].path.includes("edit-bike"))
    {
      return "Edit";
    }
    else if(url[0].path.includes("delete-bike") || url[0].path.includes("view-bike"))
    {
      return "Delete";
    }
    else if(url[0].path.includes("create-bike"))
    {
      return "create";
    }
    return "";
  }
}
