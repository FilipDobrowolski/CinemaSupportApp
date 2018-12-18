import { Injectable } from "@angular/core";
import { Config } from "../app.config";
import { HttpClient } from '@angular/common/http';


@Injectable()
export class MyFavoritesService {

    constructor(private config: Config,
        private http: HttpClient) {

    }

    getData(){

    }

}