import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs/Subscription';
import { SnotifyService } from 'ng-snotify';

import { Bill, User } from '../../appModel';

import { BillService } from '../bill.service';
import { LoaderService } from '../../shared/loader.service';
import { AuthService } from '../../auth/auth.service';

@Component({
  selector: 'app-bill-list',
  templateUrl: './bill-list.component.html',
  styleUrls: ['./bill-list.component.sass']
})
export class BillListComponent implements OnInit, OnDestroy {
  private subscriptions = new Array<Subscription>();
  billsForPay: Array<Bill>;
  user: User;

  bills = new Array<Bill>();

  constructor(
    private billService: BillService,
    private loader: LoaderService,
    private auth: AuthService,
    private notify: SnotifyService
  ) { }

  ngOnInit() {
    this.subscriptions.push(this.auth.user$
      .subscribe((user) => this.user = user));
    this.subscriptions.push(this.billService.billsToPay$
      .subscribe((res) => this.billsForPay = res));

    this.getBills();
  }

  ngOnDestroy() {
    this.subscriptions.forEach(subscription => subscription.unsubscribe());
  }

  getBills() {
    this.loader.show();
    this.billService.getBills(this.user.id).subscribe((res) => {
      this.bills = res;
      this.loader.hide();
    }, error => {
      this.loader.hide();
    });
  }

  addRemoveBill(i: number, id: string) {
    const index = this.billsForPay.findIndex(x => x.id === id);
    if (index > -1) {
      this.billsForPay.splice(index, 1);
      console.log(this.billsForPay);
      return;
    }
    this.billsForPay.push(this.bills[i]);
    console.log(this.billsForPay);
  }

  isOnPayList(id: string) {
    return this.billsForPay.findIndex(x => x.id === id) > -1;
  }
}
