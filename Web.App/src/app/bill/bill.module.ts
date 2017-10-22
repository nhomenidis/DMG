import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Route } from '@angular/router';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';

import { BillListComponent } from './bill-list/bill-list.component';

import { BillService } from './bill.service';
import { AuthGuard } from '../auth/auth.guard';
import { PaymentComponent } from './payment/payment.component';
import { PaymentListComponent } from './payment-list/payment-list.component';
import { BillsToPayComponent } from './bills-to-pay/bills-to-pay.component';
import { CreditCardComponent } from './credit-card/credit-card.component';
import { PaymentOverviewComponent } from './payment-overview/payment-overview.component';

const routes: Route[] = [
  { path: 'bill', component: BillListComponent, canActivate: [AuthGuard] },
  { path: 'bill/payment', component: PaymentComponent, canActivate: [AuthGuard] }
]

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    HttpModule,
    FormsModule
  ],
  declarations: [
    BillListComponent,
    PaymentComponent,
    PaymentListComponent,
    BillsToPayComponent,
    CreditCardComponent,
    PaymentOverviewComponent
  ], providers: [
    BillService
  ]
})
export class BillModule { }
