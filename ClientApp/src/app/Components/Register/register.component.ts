import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup } from "@angular/forms";
import { UserService } from "src/app/Services/user.service";

@Component({
  selector: "app-register",
  templateUrl: "./register.component.html",
  styleUrls: ["./register.component.scss"]
})
export class RegisterComponent implements OnInit {
  registerFormGroup: FormGroup;
  constructor(private fb: FormBuilder, private userService: UserService) {
    this.registerFormGroup = this.fb.group({
      username: [""],
      email: [""],
      password: [""]
    });
  }

  ngOnInit() {}

  register() {
    const register = this.registerFormGroup.getRawValue();
    this.userService
      .Register(register.username, register.email, register.password)
      .subscribe(response => {
        console.log(response.data);
      });
  }
}
