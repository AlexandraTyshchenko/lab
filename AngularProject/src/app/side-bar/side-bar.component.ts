import { Component } from '@angular/core';

@Component({
  selector: 'app-side-bar',
  templateUrl: './side-bar.component.html',
  styleUrls: ['./side-bar.component.scss']
})
export class  SideBarComponent {
  toggle: boolean= false;
  activeButton:string ="btn2";
  changeToggle() {
    this.toggle = !this.toggle;
  }
  setActive (buttonName:string){
    this.activeButton = buttonName;
    this.toggle=false;//ховаємо навбар
  }
  isActive(buttonName:string){
    return this.activeButton === buttonName;
  }
}
