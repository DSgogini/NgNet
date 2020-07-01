import { Injectable } from "@angular/core";
import {
  HttpInterceptor,
  HttpHandler,
  HttpRequest,
  HttpEvent,
  HttpResponse,
  HttpErrorResponse,
  HttpClient
} from "@angular/common/http";
import { Observable, throwError } from "rxjs";
import { map, catchError, timeout } from "rxjs/operators";
import { SharedComponent } from "../shared/shared.component";

@Injectable({
  providedIn: "root"
})
export class ConsHttpInterceptor implements HttpInterceptor {
  constructor(private http: HttpClient) {}

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    // Perform Token Verification here....

    if (!req.headers.has("Content-Type")) {
      req = req.clone({
        setHeaders: {
          "Content-Type": "application/json"
        }
      });
    }
    req = req.clone({
      headers: req.headers.set("Accept", "application/json")
    });

    // Implement here Loader service Before handling next event...

    return next.handle(req).pipe(
      map((event: HttpEvent<any>) => {
        if (event instanceof HttpResponse) {
        }
        return event;
      }),
      catchError((error: HttpErrorResponse) => {
        console.error(error);
        return throwError(error);
      })
    );
  }

  public get(url: string, options?: any): Observable<any> {
    url = SharedComponent.API_BASE_URL + url;
    return this.http.get(url, options).pipe();
  }

  public post(url: string, body: any, options?: any): Observable<any> {
    url = SharedComponent.API_BASE_URL + url;
    return this.http.post(url, body, options).pipe();
  }

  public delete(url: string,options?: any): Observable<any> {
    url = SharedComponent.API_BASE_URL + url;
    return this.http.delete(url, options).pipe();
  }

  public update(url: string, body:any, options?: any): Observable<any> {
    url = SharedComponent.API_BASE_URL + url;
    return this.http.put(url,body, options).pipe();
  }
}
