import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NavComponent } from './nav/nav.component';
import { ListbikesComponent } from './components/bikes/listbikes/listbikes.component';
import { ListridersComponent } from './components/listriders/listriders.component';
import { ShowriderComponent } from './components/showrider/showrider.component';
import { EditRiderComponent } from './components/edit-rider/edit-rider.component';
import { ShowBikeComponent } from './components/showbike/showbike.component'
import { ToastrModule } from 'ngx-toastr';


@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    ListbikesComponent,
    ListridersComponent,
    ShowriderComponent,
    EditRiderComponent,
    ShowBikeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    ToastrModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
