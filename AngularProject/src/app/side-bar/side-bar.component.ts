import { Component } from '@angular/core';

@Component({
  selector: 'app-side-bar',
  templateUrl: './side-bar.component.html',
  styleUrls: ['./side-bar.component.scss']
})
export class  SideBarComponent {
  toggle: boolean= false;
  activeButton:string ="btn1";
  changeToggle() {
    this.toggle = !this.toggle;
  }
  setActive (buttonName:string){
    this.activeButton = buttonName;
    this.toggle=false;
  }
  isActive(buttonName:string){
    return this.activeButton === buttonName;
  }
}
