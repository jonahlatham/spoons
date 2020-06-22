import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable({
  providedIn: "root"
})
export class UserService {
  constructor(private http: HttpClient) {}

  public Register(
    username: string,
    email: string,
    password: string
  ): Observable<any> {
    const body = { username, email, password };
    return this.http.post<any>("/authentication/register", body);
  }

  public Login(email: string, password: string): Observable<any> {
    const body = { email, password };
    return this.http.post<any>("/authentication/login", body);
  }
}
