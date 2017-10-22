import { Injectable, OnInit } from '@angular/core';
import { Observable, BehaviorSubject } from 'rxjs/Rx';

import { environment } from '../../environments/environment';

import { Bill, User } from '../appModel';

import { AuthService } from '../auth/auth.service';

@Injectable()
export class BillService implements OnInit {
  private billUrl = environment.api + 'bill';

  private billsToPaySubject$ = new BehaviorSubject<Bill[]>(new Array<Bill>());
  billsToPay$ = this.billsToPaySubject$.asObservable();

  get billsToPay(): Bill[] {
    return this.billsToPaySubject$.getValue();
  }

  set billsToPay(value: Bill[]) {
    this.billsToPaySubject$.next(value);
  }

  constructor(
    private auth: AuthService
  ) { }

  ngOnInit() {

  }

  getBills(id: string): Observable<Array<Bill>> {
    return this.auth.get(this.billUrl + '/bills/' + id)
      .map((res: Response) => res.json())
      .catch((error: string) => Observable.throw(error || 'Server error'));
  }
}
