import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup } from "@angular/forms";
import { UserService } from "src/app/Services/user.service";

@Component({
  selector: "app-addNew",
  templateUrl: "./addNew.component.html",
  styleUrls: ["./addNew.component.scss"]
})
export class AddNewComponent implements OnInit {
  addNewFormGroup: FormGroup;
  constructor(private fb: FormBuilder, private userService: UserService) {
    this.addNewFormGroup = this.fb.group({
      title: [""],
      instructions: [""],
      quantity: [""],
      ingredient: [""]
    });
  }

  formatLabel(value: number) {
    if (value >= 480) {
      return Math.round(value / 4800);
    }
    return value;
  }

  ngOnInit() {}
}
