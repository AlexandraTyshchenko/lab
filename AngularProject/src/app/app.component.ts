import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  toggleSidenav() {
    this.opened = !this.opened;
    console.log(this.opened );
  }
  activeButton:string ="btn1";
  
  setActive (buttonName:string){
    this.activeButton = buttonName;
    this.opened=false;
  }
  isActive(buttonName:string){
    return this.activeButton === buttonName;
  }
  opened=false;
  title = 'AngularProject';
}
