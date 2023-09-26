import { Component } from '@angular/core';
import { SimService } from '../../__services/sim.service';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-listsims',
  templateUrl: './listsims.component.html',
  styleUrls: ['./listsims.component.css']
})
export class ListsimsComponent {
  allSims: any;
  constructor(private simService: SimService, private router: Router)
  {
    console.log("Constructor of all Sims");
  }
  ngOnInit() : void
  {
    console.log("ngInit of all Sims");
    this.simService.getSims().subscribe({
      next: (result)=>this.allSims = result,
      error: (error) => console.log(error),
      complete:()=>console.log(this.allSims)
    });
  }
  showDetails(id:number){
    this.router.navigate(["/view-sim/" + id] );
  }
  editSim(id:number)
  {
    this.router.navigate(["/edit-sim/" + id]);
  }
  deleteSim(id:number)
  {
    this.router.navigate(["/delete-sim/" + id]);
  }
  createSim()
  {
    this.router.navigate(["/create-sim/"]);
  }
}
