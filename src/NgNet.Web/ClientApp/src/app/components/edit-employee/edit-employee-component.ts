import { Component, Injectable } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { EmployeeService } from 'src/app/services/Employee.service';
import { Router } from '@angular/router';

@Injectable()
@Component({
  selector: "app-edit-employee",
  templateUrl: "./edit-employee-component.html"
})
export class EditEmployeeComponent {
  EditEmployeeForm: FormGroup;

  constructor(private formBuilder: FormBuilder,private _empService: EmployeeService,private router: Router) {}

  ngOnInit() {
    let EmpId = parseInt(window.localStorage.getItem("editUserId"));
    if(!EmpId) {
      this.router.navigate(['home']);
      return;
    }

    this.EditEmployeeForm = this.formBuilder.group({
      Id:[],
      FirstName: ["", Validators.required],
      LastName: ["", Validators.required],
      Address: ["", Validators.required],
      Email: ["", [Validators.required, Validators.email]],
      Phone: ["", [Validators.required]]
    });
    
    if(EmpId){
      this._empService.getById(EmpId).subscribe((res)=>{
        this.EditEmployeeForm.setValue(res.Result);
      });
    }
  }

  // // convenience getter for easy access to form fields
   get f() {
      return this.EditEmployeeForm.controls;
   }

  onSubmit(form: any) {
    if (this.EditEmployeeForm.invalid) {
      return;
    }
    let data = this.EditEmployeeForm.value;
    this._empService.updateEmployee(data).subscribe(res => {
      if(res.Sccessful){
        this.router.navigate(['home'], res.Model);
      }
    });
  }
}