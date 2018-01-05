import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { catchError, map, tap } from 'rxjs/operators';

import { Make } from '../models/make';
import { Feature} from '../models/feature';

@Injectable()
export class MakeService {
    baseUrl: string;

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.baseUrl = baseUrl;
    }

    getMakes(): Observable<Make[]> {
        
        return this.http.get<Make[]>(this.baseUrl + 'api/makes')
            .pipe(
            tap(makes => console.log('fetched makes')),
            catchError(this.handleError('getMakes', []))
            );
    }

    getFeatures(): Observable<Feature[]> {
        return this.http.get<Feature[]>(this.baseUrl + 'api/features')
            .pipe(
            tap(makes => console.log('fetched features')),
            catchError(this.handleError('getFeatures', []))
            );
    }

    private handleError<T>(operation = 'operation', result?: T) {
        return (error: any): Observable<T> => {

            // TODO: send the error to remote logging infrastructure
            console.error(error); // log to console instead            

            // Let the app keep running by returning an empty result.
            return of(result as T);
        };
    }

}

