import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RiderService } from 'src/app/__services/rider.service';

@Component({
  selector: 'app-edit-rider',
  templateUrl: './edit-rider.component.html',
  styleUrls: ['./edit-rider.component.css']
})
export class EditRiderComponent {
  currentRider:any;
  constructor(private riderService: RiderService, 
    private router: Router, private route: ActivatedRoute)
  {
    console.log("Constructor of all Riders");
  }
  ngOnInit() : void
  {
    
    this.riderService.getRiderById(this.route.snapshot.params['id']).subscribe({
      next: res => { this.currentRider = res},
      error: (error)=>{console.log(error)},
      complete: ()=>console.log("Done")
    });
  }
  BackToRiderListing()
  {
    this.router.navigate(["/riders"]);
  }
  editRider()
  {
    this.router.navigate(["/riders"]);
  }

}
