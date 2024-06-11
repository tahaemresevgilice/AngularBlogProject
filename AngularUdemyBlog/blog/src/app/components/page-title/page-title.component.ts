import { Component, Input, OnInit } from '@angular/core';
import { title } from 'node:process';

@Component({
  selector: 'app-page-title',
  templateUrl: './page-title.component.html',
  styleUrl: './page-title.component.css'
})
export class PageTitleComponent implements OnInit {
@Input() title:string;
  constructor() {}

  ngOnInit() {

  }
}
