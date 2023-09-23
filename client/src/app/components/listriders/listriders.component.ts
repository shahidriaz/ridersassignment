import { Component } from '@angular/core';
import { RiderService } from '../../__services/rider.service';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-listriders',
  templateUrl: './listriders.component.html',
  styleUrls: ['./listriders.component.css']
})
export class ListridersComponent {
  allRiders: any;
  constructor(private riderService: RiderService, private router: Router)
  {
    console.log("Constructor of all Riders");
  }
  ngOnInit() : void
  {
    console.log("ngInit of all Riders");
    this.riderService.getRiders().subscribe({
      next: (result)=>this.allRiders = result,
      error: (error) => console.log(error),
      complete:()=>console.log(this.allRiders)
    });
  }
  showDetails(id:number){
    this.router.navigate(["/view-rider/" + id] );
  }
  editRider(id:number)
  {
    this.router.navigate(["/edit-rider/" + id]);
  }
  deleteRider(id:number)
  {
    this.router.navigate(["/delete-rider/" + id]);
  }
  createRider()
  {
    this.router.navigate(["/create-rider/"]);
  }
}
