import { Component, OnInit } from '@angular/core';
import { EmployeeService } from 'src/app/services/Employee.service';
import { Employee } from 'src/app/model/Employee';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ViewChild } from '@angular/core';
import { ModalService } from 'src/app/services/modal.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  @ViewChild('frame', { static: false }) modalHolder: any;
  data: Employee[];
  editField: string;
  AddEmployeeForm: FormGroup;

  constructor(private _empService: EmployeeService, private router: Router) {
  
   }

  ngOnInit() {
    this.GetAllData();
  }

  GetAllData(){
    this._empService.getList().subscribe(res => {
        this.data = res.employees;
    });
  }

  SaveEmployee(form:any){
    if(this.AddEmployeeForm.invalid){}

    var data = {
      FirstName: this.AddEmployeeForm.get('FirstName'),
      LastName : this.AddEmployeeForm.get('LastName'),
      Email:this.AddEmployeeForm.get('Email'),
      Phone:this.AddEmployeeForm.get('Phone'),
      Address:this.AddEmployeeForm.get('Address')
    };
    
    this._empService.addEmployee(data).subscribe((res)=>{
      console.log(res);
    });
  }

  editEmployee(item:any) {
    window.localStorage.removeItem("editUserId");
    window.localStorage.setItem("editUserId", item.Id);
    this.router.navigate(['edit-employee']);
  }

  remove(item: any) {
    this._empService.removeEmployee(item.Id).subscribe(res => {
     if(res.Sccessful){
       this.GetAllData();
     }
    });
  }

  ShowModal() {
    this.router.navigate(['add-employee']);
  }
}
