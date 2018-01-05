import { Component, OnChanges, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import { Make } from '../../models/make';
import { Model } from '../../models/Model';
import { Feature } from '../../models/feature';
import { MakeService } from '../../services/make.service';
import * as _ from 'underscore';

@Component({
    selector: 'vehicle',
    styleUrls: ['vehicle.css'],
    templateUrl: 'vehicle.component.html'
})
export class VehicleComponent implements OnInit {
    vehicleForm: FormGroup;
    makes: Make[] = [];
    models: Observable<Model[]>;
    features: Feature[];

    constructor(private fb: FormBuilder, private makeService: MakeService) {
        this.createForm();
        this.models = this.vehicleForm.controls['make'].valueChanges
            .map(make => this.makes!.find(({ makeId }) => makeId == make).models)
            .do(() => this.vehicleForm.controls['model'].setValue(''));       
    }

    ngOnInit() {
        this.makeService.getMakes().subscribe(makes => {
            this.makes = _.sortBy(makes, 'name');
        });
        this.makeService.getFeatures().subscribe(features => {
            this.features = features;
        });
    }

    createForm() {
        this.vehicleForm = this.fb.group({
            make: ['', Validators.required],
            model: ['', Validators.required],
            registered: ['false', Validators.required],
            features: this.fb.array([]),
            contactName: ['', Validators.required],
            contactPhone: ['', Validators.required],
            contactEmail: ['', Validators.required]
        });
    }

    onSubmit() { }

    onCheckChange(event) {
        const array: FormArray = this.vehicleForm.get('features') as FormArray;

        if (event.checked) {
            array.push(new FormControl(event.source.value));
        } else {
            let i: number = 0;
            array.controls.forEach((ctrl: FormControl) => {
                if (ctrl.value == event.source.value) {
                    array.removeAt(i);
                    return;
                }
                i++;
            });
        }
    }
   
}
