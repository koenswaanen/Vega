import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Make } from '../../models/make';
import { MakeService } from '../../services/make.service';

@Component({
    selector: 'fetchdata',
    templateUrl: './fetchdata.component.html'
})
export class FetchDataComponent implements OnInit {
    public forecasts: WeatherForecast[];
    public makes: Make[];

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private makeService: MakeService) {
        http.get(baseUrl + 'api/SampleData/WeatherForecasts').subscribe(result => {           
            this.forecasts = result as WeatherForecast[];
        }, error => console.error(error));        
    }

    ngOnInit() {
        this.getMakes();
    }


    getMakes(): void {
        this.makeService.getMakes().subscribe(makes => {
            console.log(makes);
            this.makes = makes;
        });
    }
}

interface WeatherForecast {
    dateFormatted: string;
    temperatureC: number;
    temperatureF: number;
    summary: string;
}
