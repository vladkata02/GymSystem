import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-home-info',
  templateUrl: './home-info.component.html',
  styleUrls: ['./home-info.component.scss']
})
export class WelcomeMessageComponent {

  @Input() isLoggedIn = false;

  constructor() { }

}
