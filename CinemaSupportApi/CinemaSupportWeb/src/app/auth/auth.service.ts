import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { throwError } from 'rxjs';
import { map, catchError, subscribeOn } from 'rxjs/operators';

const TOKEN_KEY = 'AuthToken';
const isLoggedIn = false;
@Injectable({
  providedIn: 'root'
})
export class AuthService {

  serverUrl = 'http://localhost:52775/';
  errorData: {};

  isLoggedIn = false;
  isRegistered = false;

  constructor(private http: HttpClient) { }

  redirectUrl: string;

  login(username: string, password: string) {
    const options = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    }

    return this.http.post<any>(`api/accounts/login`, {user: username, password: password} )
    .pipe(map(user => {
        if (user && user.access_token) {
          window.sessionStorage.setItem('currentUser', user.userName);
          window.sessionStorage.removeItem(TOKEN_KEY);
          window.sessionStorage.setItem(TOKEN_KEY, user.access_token);
          window.sessionStorage.setItem('IS_LOGED_IN', JSON.stringify(true));
          //this.isLoggedIn = true;
        }
      }),
      catchError(this.handleError)
    );
  }

  register(username: string, password: string, confirmpassword: string) {

    return this.http.post<any>(`api/accounts/register`, {user: username, password: password, confirmpassword: confirmpassword} )
    .pipe(map((res: Response) => {
      this.isRegistered = true;
      if (res) {
        this.isRegistered = true;
        if (res.status === 200) {
          this.isRegistered = true;
        }
      }
    }),
      catchError(this.handleError)
    );
  }

  getAuthorizationToken() {
    const currentUser = window.sessionStorage.getItem(TOKEN_KEY);;
    return currentUser;
  }

  logout() {
    localStorage.removeItem('currentUser');
    window.sessionStorage.setItem('IS_LOGED_IN', 'false')
  }

  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {

      // A client-side or network error occurred. Handle it accordingly.

      console.error('An error occurred:', error.error.message);
    } else {

      // The backend returned an unsuccessful response code.

      // The response body may contain clues as to what went wrong.

      console.error(`Backend returned code ${error.status}, ` + `body was: ${error.error}`);
    }

    // return an observable with a user-facing error message

    this.errorData = {
      errorTitle: 'Oops! Request for document failed',
      errorDesc: 'Something bad happened. Please try again later.'
    };
    return throwError(this.errorData);
  }
}

// kod na rejestracje zostalo zrobic co jak ok zwroci
// return this.http.post<any>(`api/accounts/register`, {user: username, password: password, confirmpassword: password} )
//     .pipe(map(user => {
//         if (user && user.token) {
//           localStorage.setItem('currentUser', JSON.stringify(user));
//           this.isLoggedIn = true;
//         }
//       }),
//       catchError(this.handleError)
//     );