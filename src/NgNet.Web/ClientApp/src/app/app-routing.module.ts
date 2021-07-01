import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { HomeComponent } from "./components/home/home.component";
import { AddEmployeeComponent } from "./components/add-employee/add-employee-component";
import { MasterComponent } from "./components/master/master.component";
import { EditEmployeeComponent } from './components/edit-employee/edit-employee-component';

const routes: Routes = [
  {
    path: "",
    component: MasterComponent,
    children: [{ path: "", component: HomeComponent },
    { path: "add-employee", component: AddEmployeeComponent },
    { path: "edit-employee", component: EditEmployeeComponent }]
  },
  {
    path: "home",
    component: MasterComponent,
    children: [{ path: "", component: HomeComponent }]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
