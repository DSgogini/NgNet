import { Injectable } from "@angular/core";
import { SharedComponent } from "../shared/shared.component";
import { ConsHttpInterceptor } from "../interceptors/cons.interceptor";

@Injectable({
  providedIn: "root"
})
export class EmployeeService {
  constructor(private _http: ConsHttpInterceptor) {}

  public getList() {
    return this._http.get("api/employee/list");
  }

  public addEmployee(data: any) {
    return this._http.post("api/employee/add", data);
  }

  public removeEmployee(data: any) {
    let url = "api/employee/delete/" + data;
    return this._http.delete(url);
  }
  
  public updateEmployee(data:any){
    let url = "api/employee/edit/";
    return this._http.update(url,data);
  }

  public getById(id:any){
    let url = "api/employee/list/" + id;
    return this._http.get(url);
  }
}
