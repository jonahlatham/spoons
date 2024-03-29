import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { LoginComponent } from "./Components/login/login.component";
import { RegisterComponent } from "./Components/Register/register.component";
import { HomeComponent } from "./Components/Home/home.component";
import { AddNewComponent } from "./Components/AddNew/addNew.component";
import { AllRecipesComponent } from "./Components/AllRecipes/allRecipes.component";
import { RecipeSelectedComponent } from './Components/RecipeSelected/recipeSelected.component';

const routes: Routes = [
  { path: "login", component: LoginComponent },
  { path: "register", component: RegisterComponent },
  { path: "home", component: HomeComponent },
  { path: "add", component: AddNewComponent },
  { path: "allRecipes", component: AllRecipesComponent },
  { path: "recipeSelected", component: RecipeSelectedComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
