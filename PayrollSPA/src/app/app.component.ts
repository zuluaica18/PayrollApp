import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { isDefined } from '@angular/compiler/src/util';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'PayrollSPA';
  employees: any[] = [];
 

  constructor(private http: HttpClient)
  {

  }

  chargeEmployee( id: string ) {
    if (id != '')
    {
      this.employees = [];
      this.http.get(`https://localhost:5001/api/Employees/${ id }`).
      subscribe((resp:any)=> {
        this.employees[0] = resp;
      });
    }
    else
    {
      this.http.get('https://localhost:5001/api/Employees').
      subscribe((resp:any)=> {
        this.employees = resp;
      });
    }
  }
}
