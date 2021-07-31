import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { User } from '../shared/model';
// import {RegistServicesService  } from '../shared/regist-services.service';
// import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  // user:User;
  // constructor(private RegistServicesService:RegistServicesService, private toastr: ToastrService) { }
  constructor() { }

  ngOnInit():void {
    // this.resetForm();
  }

  // resetForm(form?: NgForm) {
  //   if (form != null)
  //     form.reset();
  //   this.user = {
  //     userName: '',
  //     Password: '',
  //     confirmPassword: '',
  //     Email: ''
     
  //   }
  // }
  userModel = new User("","","","");
  // OnSubmit(form: NgForm) {
  //   this.RegistServicesService.registerUser(form.value)
  //     .subscribe((data: any) => {
  //       if (data.Succeeded == true) {
  //         // this.resetForm(form);
  //         this.toastr.success('User registration successful');
  //       }
  //       else
  //         this.toastr.error(data.Errors[0]);
  //     });
  // }
 

}
