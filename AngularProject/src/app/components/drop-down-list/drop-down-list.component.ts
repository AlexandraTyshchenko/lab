import { Component,EventEmitter,Input,Output } from '@angular/core';
import { BasicItem } from 'src/app/interfaces/basic-item';
@Component({
  selector: 'app-drop-down-list',
  templateUrl: './drop-down-list.component.html',
  styleUrls: ['./drop-down-list.component.scss']
})
export class DropDownListComponent {
  @Input() items: BasicItem[] = [];
  @Input() currentItem:string="";
  @Output() valueChanged: EventEmitter<BasicItem> = new EventEmitter<BasicItem>();
  selectItem(item:BasicItem){
    this.currentItem=item.name;
    this.valueChanged.emit(item);
  }
}
