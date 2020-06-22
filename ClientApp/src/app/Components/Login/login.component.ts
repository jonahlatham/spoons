import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup } from "@angular/forms";
import { UserService } from "src/app/Services/user.service";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.scss"]
})
export class LoginComponent implements OnInit {
  loginFormGroup: FormGroup;
  constructor(private fb: FormBuilder, private userService: UserService) {
    this.loginFormGroup = this.fb.group({
      email: [""],
      password: [""]
    });
  }

  ngOnInit(): void {}

  Login() {
    debugger;
    const login = this.loginFormGroup.getRawValue();
    this.userService.Login(login.email, login.password).subscribe(response => {
      debugger;
      console.log(response.data);
    });
  }
}
