import { Component, Injectable } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { EmployeeService } from 'src/app/services/Employee.service';
import { Router } from '@angular/router';

@Injectable()
@Component({
  selector: "app-add-employee",
  templateUrl: "./add-employee-component.html"
})
export class AddEmployeeComponent {
  AddEmployeeForm: FormGroup;

  constructor(private formBuilder: FormBuilder,private _empService: EmployeeService,private router: Router) {}

  ngOnInit() {
    this.AddEmployeeForm = this.formBuilder.group({
      FirstName: ["", Validators.required],
      LastName: ["", Validators.required],
      Address: ["", Validators.required],
      Email: ["", [Validators.required, Validators.email]],
      Phone: ["", [Validators.required]]
    });
  }

  // convenience getter for easy access to form fields
  get f() {
    return this.AddEmployeeForm.controls;
  }

  onSubmit() {
    if (this.AddEmployeeForm.invalid) {
      return;
    }

    this._empService.addEmployee(this.AddEmployeeForm.value).subscribe(res => {
      if(res.Sccessful){
        this.router.navigate(['home'], res.Model);
      }
    });
  }
}
