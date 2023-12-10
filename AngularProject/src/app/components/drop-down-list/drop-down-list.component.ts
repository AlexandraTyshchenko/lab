
import { Component,EventEmitter,Input,Output } from '@angular/core';
import { MatSelectChange } from '@angular/material/select';
@Component({
  selector: 'app-drop-down-list',
  templateUrl: './drop-down-list.component.html',
  styleUrls: ['./drop-down-list.component.scss'],
  
})
export class DropDownListComponent {
  @Input() items: any[] = [];
  @Input() currentItem:string="";
  @Output() valueChanged: EventEmitter<any> = new EventEmitter<any>();
  onSelectionChange(event: MatSelectChange): void {
    const selectedValue = event.value;
    this.selectItem(selectedValue);
  }
  selectItem(item: any): void {
    this.valueChanged.emit(item);
  }
}
