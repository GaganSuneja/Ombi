﻿import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs/Subject';
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/distinctUntilChanged';
import 'rxjs/add/operator/map';
import "rxjs/add/operator/takeUntil";

import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/distinctUntilChanged';
import 'rxjs/add/operator/map';

import { RequestService } from '../services/request.service';
import { IdentityService } from '../services/identity.service';

import { ITvRequests, IChildRequests } from '../interfaces/IRequestModel';

@Component({
    selector: 'tv-requests',
    templateUrl: './tvrequests.component.html'
})
export class TvRequestsComponent implements OnInit, OnDestroy {
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
                this.requestService.searchTvRequests(this.searchText)
                    .takeUntil(this.subscriptions)
                    .subscribe(m => this.tvRequests = m);
            });
    }


    private subscriptions = new Subject<void>();

    tvRequests: ITvRequests[];

    searchChanged = new Subject<string>();
    searchText: string;

    isAdmin: boolean;

    private currentlyLoaded: number;
    private amountToLoad: number;

    public showChildDialogue = false; // This is for the child modal popup
    public selectedSeason: ITvRequests;


    ngOnInit() {
        this.amountToLoad = 5;
        this.currentlyLoaded = 5;
        this.loadInit();
    }



    public loadMore() {
        this.requestService.getTvRequests(this.amountToLoad, this.currentlyLoaded + 1)
            .takeUntil(this.subscriptions)
            .subscribe(x => {
                this.tvRequests.push.apply(this.tvRequests, x);
                this.currentlyLoaded = this.currentlyLoaded + this.amountToLoad;
            });
    }

    public search(text: any) {
        this.searchChanged.next(text.target.value);
    }

    public removeRequest(request: ITvRequests) {
        this.requestService.removeTvRequest(request);
        this.removeRequestFromUi(request);
    }

    public changeAvailability(request: IChildRequests, available: boolean) {
        request.available = available;

        //this.updateRequest(request);
    }

    public approve(request: IChildRequests) {
        request.approved = true;
        request.denied = false;
        //this.updateRequest(request);
    }

    public deny(request: IChildRequests) {
        request.approved = false;
        request.denied = true;
        //this.updateRequest(request);
    }

    public approveSeasonRequest(request: IChildRequests) {
        request.approved = true;
        request.denied = false;
        this.requestService.updateTvRequest(this.selectedSeason)
            .subscribe();
    }

    public denySeasonRequest(request: IChildRequests) {
        request.approved = false;
        request.denied = true;
        this.requestService.updateTvRequest(this.selectedSeason)
            .subscribe();
    }

    public showChildren(request: ITvRequests) {
        this.selectedSeason = request;
        this.showChildDialogue = true;
    }

    //private updateRequest(request: ITvRequests) {
    //    this.requestService.updateTvRequest(request)
    //        .takeUntil(this.subscriptions)
    //        .subscribe(x => request = x);
    //}

    private loadInit() {
        this.requestService.getTvRequests(this.amountToLoad, 0)
            .takeUntil(this.subscriptions)
            .subscribe(x => {
                this.tvRequests = x;
            });
        this.isAdmin = this.identityService.hasRole("Admin");
    }

    private resetSearch() {
        this.currentlyLoaded = 5;
        this.loadInit();
    }

    private removeRequestFromUi(key: ITvRequests) {
        var index = this.tvRequests.indexOf(key, 0);
        if (index > -1) {
            this.tvRequests.splice(index, 1);
        }
    }

    ngOnDestroy(): void {
        this.subscriptions.next();
        this.subscriptions.complete();
    }
}