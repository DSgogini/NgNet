import browser from 'browser-detect';
import { Component, OnInit } from '@angular/core';

import { environment as env } from '../../environments/environment';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  animations: []
})
export class AppComponent implements OnInit {
  isProd = env.production;
  envName = env.envName;
  version = env.versions.app;
  year = new Date().getFullYear();
  logo = require('../../assets/logo.png');
  languages = ['en', 'de', 'sk', 'fr', 'es', 'pt-br', 'zh-cn', 'he'];
  navigation = [
    { link: 'feature-list', label: 'feature-list' },
    { link: 'examples', label: 'examples' }
  ];
  navigationSideMenu = [...this.navigation];

  constructor() {}

  ngOnInit(): void {}
}
