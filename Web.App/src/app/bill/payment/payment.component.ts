import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs/Subscription';
import { SnotifyService } from 'ng-snotify';

import { Bill, User, CreditCard } from '../../appModel';

import { BillService } from '../bill.service';
import { LoaderService } from '../../shared/loader.service';
import { AuthService } from '../../auth/auth.service';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.sass']
})
export class PaymentComponent implements OnInit, OnDestroy {
  private subscriptions = new Array<Subscription>();
  billsForPay: Array<Bill>;
  creditCard = new CreditCard();
  user: User;
  step = 1;

  constructor(
    private billService: BillService,
    private loader: LoaderService,
    private auth: AuthService,
    private notify: SnotifyService
  ) { }


  previousStep() {
    this.step = this.step === 0 ? this.step : this.step - 1;
  }

  nextStep() {
    this.step = this.step === 2 ? this.step : this.step + 1;
  }

  ngOnDestroy() {
    this.subscriptions.forEach(subscription => subscription.unsubscribe());
  }

  ngOnInit() {
    this.subscriptions.push(this.auth.user$
      .subscribe((user) => this.user = user));
    this.subscriptions.push(this.billService.billsToPay$
      .subscribe((res) => this.billsForPay = res));
  }

}
