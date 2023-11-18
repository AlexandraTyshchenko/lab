
import {Component,EventEmitter,Input, Output } from '@angular/core';

@Component({
    selector: 'app-paginator',
    templateUrl: './paginator.component.html',
    styleUrls:['./paginator.component.scss']
    
})
export class PaginatorComponent {
    @Output() pageChange: EventEmitter<number> = new EventEmitter<number>();
    handleChildValue($event:any){
        this.pageChange.emit($event.pageIndex + 1);
    }
    pageSize=10;
    @Input() length:number=10;

}