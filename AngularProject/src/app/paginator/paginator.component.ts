
import {Component,Input } from '@angular/core';

@Component({
    selector: 'app-paginator',
    templateUrl: './paginator.component.html',
    styleUrls:['./paginator.component.scss']
    
})
export class PaginatorComponent {
    p: number = 1;
    pageSize=10;
    @Input() length:number=10;

}