import { Component, OnInit, Input } from '@angular/core';

import { Bill, User } from '../../appModel';
@Component({
  selector: 'app-bills-to-pay',
  templateUrl: './bills-to-pay.component.html',
  styleUrls: ['./bills-to-pay.component.sass']
})
export class BillsToPayComponent implements OnInit {
  @Input() bills = new Array<Bill>();
  constructor() { }

  ngOnInit() {
  }

}
