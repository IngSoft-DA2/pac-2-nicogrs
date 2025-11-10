import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { signal } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class ReflectionService {
  private baseUrl = 'https://localhost:7152/api/importers';
  importers = signal<string[]>([]);
  
  constructor(private http: HttpClient) {}

  getImporters(): Observable<string[]> {
    return this.http.get<string[]>(this.baseUrl);
  }
}