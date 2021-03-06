﻿import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs/Subject';
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/distinctUntilChanged';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/takeUntil';


import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/distinctUntilChanged';
import 'rxjs/add/operator/map';

import { RequestService } from '../services/request.service';
import { IdentityService } from '../services/identity.service';

import { IMovieRequests } from '../interfaces/IRequestModel';

@Component({
    selector: 'movie-requests',
    templateUrl: './movierequests.component.html'
})
export class MovieRequestsComponent implements OnInit, OnDestroy {
    constructor(private requestService: RequestService, private identityService: IdentityService) {
        this.searchChanged
            .debounceTime(600) // Wait Xms afterthe last event before emitting last event
            .distinctUntilChanged() // only emit if value is different from previous value
            .takeUntil(this.subscriptions)
            .subscribe(x => {
                this.searchText = x as string;
                if (this.searchText === "") {
                    this.resetSearch();
                    return;
                }
                this.requestService.searchMovieRequests(this.searchText)
                    .takeUntil(this.subscriptions)
                    .subscribe(m => this.movieRequests = m);
            });
    }

    movieRequests: IMovieRequests[];

    searchChanged: Subject<string> = new Subject<string>();
    searchText: string;

    isAdmin: boolean;

    private currentlyLoaded: number;
    private amountToLoad: number;


    private subscriptions = new Subject<void>();

    ngOnInit() {
        this.amountToLoad = 5;
        this.currentlyLoaded = 5;
        this.loadInit();
    }



    loadMore() {
        this.loadRequests(this.amountToLoad, this.currentlyLoaded);
    }

    search(text: any) {
        this.searchChanged.next(text.target.value);
    }

    removeRequest(request: IMovieRequests) {
        this.requestService.removeMovieRequest(request);
        this.removeRequestFromUi(request);
        this.loadRequests(1, this.currentlyLoaded);
    }

    changeAvailability(request: IMovieRequests, available: boolean) {
        request.available = available;

        this.updateRequest(request);
    }

    approve(request: IMovieRequests) {
        request.approved = true;
        request.denied = false;
        this.updateRequest(request);
    }

    deny(request: IMovieRequests) {
        request.approved = false;
        request.denied = true;
        this.updateRequest(request);
    }

    private loadRequests(amountToLoad: number, currentlyLoaded: number) {
        this.requestService.getMovieRequests(amountToLoad, currentlyLoaded + 1)
            .takeUntil(this.subscriptions)
            .subscribe(x => {
                this.movieRequests.push.apply(this.movieRequests, x);
                this.currentlyLoaded = currentlyLoaded + amountToLoad;
            });
    }

    private updateRequest(request: IMovieRequests) {
        this.requestService.updateMovieRequest(request)
            .takeUntil(this.subscriptions)
            .subscribe(x => request = x);
    }

    private loadInit() {
        this.requestService.getMovieRequests(this.amountToLoad, 0)
            .takeUntil(this.subscriptions)
            .subscribe(x => this.movieRequests = x);
        this.isAdmin = this.identityService.hasRole("Admin");
    }

    private resetSearch() {
        this.currentlyLoaded = 5;
        this.loadInit();
    }

    private removeRequestFromUi(key: IMovieRequests) {
        var index = this.movieRequests.indexOf(key, 0);
        if (index > -1) {
            this.movieRequests.splice(index, 1);
        }
    }

    ngOnDestroy(): void {
        this.subscriptions.next();
        this.subscriptions.complete();
    }
}