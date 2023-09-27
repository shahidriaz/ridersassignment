import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ListridersComponent } from './components/listriders/listriders.component';
import { ListbikesComponent } from './components/bikes/listbikes/listbikes.component';
import { ShowriderComponent } from './components/showrider/showrider.component';
import { EditRiderComponent } from './components/edit-rider/edit-rider.component';
import { ShowBikeComponent } from './components/showbike/showbike.component';


const routes: Routes = [
  {path:'', component: ListridersComponent},
  {path:'riders', component: ListridersComponent},
  {path:'bikes', component: ListbikesComponent},
  {path: 'view-rider/:id', component: ShowriderComponent},
  {path: 'edit-rider/:id', component: ShowriderComponent},
  {path: 'delete-rider/:id', component: ShowriderComponent},
  {path: 'create-rider', component: ShowriderComponent},
  
  {path: 'view-bike/:id', component: ShowBikeComponent},
  {path: 'edit-bike/:id', component: ShowBikeComponent},
  {path: 'delete-bike/:id', component: ShowBikeComponent},
  {path: 'create-bike', component: ShowBikeComponent},
  
  

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
