import { Component } from '@angular/core';

import { Route, Router } from '@angular/router';
import { BikeService } from 'src/app/__services/bike.service';

@Component({
  selector: 'app-listbikes',
  templateUrl: './listbikes.component.html',
  styleUrls: ['./listbikes.component.css']
})
export class ListbikesComponent {
  allBikes: any;
  constructor(private bikeService: BikeService, private router: Router)
  {
   
  }
  ngOnInit() : void
  {
    console.log("Ng Init of Show Bike");
    this.bikeService.getBikes().subscribe({
      next: (result)=>this.allBikes = result,
      error: (error) => console.log(error),
      complete:()=>console.log(this.allBikes)
    });
  }
  showDetails(id:number){
    this.router.navigate(["/view-bike/" + id] );
  }
  editRider(id:number)
  {
    this.router.navigate(["/edit-bike/" + id]);
  }
  deleteRider(id:number)
  {
    this.router.navigate(["/delete-bike/" + id]);
  }
  createRider()
  {
    this.router.navigate(["/create-bike/"]);
  }
}
