import { HttpClient } from "@angular/common/http";
import { Observable,Subject } from "rxjs";
import { Injectable } from "@angular/core";
import { API_BASE_URL } from "src/config";
import { takeUntil } from 'rxjs/operators';

@Injectable({
    providedIn: 'root',
}) 
export class GroupService{
   private destroy$ = new Subject<void>();
    constructor(private http: HttpClient) {}
    GetGroups():Observable<any>{
      return  this.http.get(`${API_BASE_URL}/api/Group`)
      .pipe(takeUntil(this.destroy$))
    }
    ngOnDestroy(): void {
      this.destroy$.next();
      this.destroy$.complete();
  }
}