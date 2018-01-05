import {Model } from './model'

export interface Make {
    makeId: number;
    name: string;
    models: Model[];
}