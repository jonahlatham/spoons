import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from "@angular/forms";
import { UserService } from "src/app/Services/user.service";

@Component({
  selector: 'app-allRecipes',
  templateUrl: './allRecipes.component.html',
  styleUrls: ['./allRecipes.component.scss']
})
export class AllRecipesComponent implements OnInit {
  allRecipesFormGroup: FormGroup;
  constructor(private fb: FormBuilder, private userService: UserService) {
    this.allRecipesFormGroup = this.fb.group({
      search: [""],
    });
  }

  ngOnInit() {
  }

}
