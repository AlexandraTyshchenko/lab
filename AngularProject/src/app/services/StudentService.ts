import { HttpClient } from "@angular/common/http";
import { Student } from "../student";
import { Observable, Subject } from 'rxjs';
import { Injectable } from "@angular/core";
import { API_BASE_URL } from "src/config";
import { takeUntil } from 'rxjs/operators';

@Injectable({
    providedIn: 'root',
})
export class StudentService {
    private destroy$ = new Subject<void>();

    constructor(private http: HttpClient) {}

    getStudents(groupId: number, page: number, pageSize: number): Observable<Student[]> {
        return this.http.get<Student[]>(`${API_BASE_URL}/api/Students?groupId=${groupId}&page=${page}&pageSize=${pageSize}`)
            .pipe(takeUntil(this.destroy$));
    }

    ngOnDestroy(): void {
        this.destroy$.next();
        this.destroy$.complete();
    }
}
