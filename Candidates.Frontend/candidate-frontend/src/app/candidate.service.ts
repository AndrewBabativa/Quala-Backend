import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Candidate } from './model/candidate.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CandidateService {
  private baseUrlQuery = 'https://localhost:44382/api/candidates/read'; 
  private baseUrlCommand = 'https://localhost:44382/api/candidates';
  constructor(private http: HttpClient) {}

  getAllCandidates(): Observable<Candidate[]> {
    return this.http.get<Candidate[]>(`${this.baseUrlQuery}`);
  }

  getCandidateById(id: number): Observable<Candidate> {
    return this.http.get<Candidate>(`${this.baseUrlQuery}/${id}`);
  }

  createCandidate(candidate: Candidate): Observable<Candidate> {
    console.log(candidate);
    return this.http.post<Candidate>(`${this.baseUrlCommand}`, candidate);
  }

  updateCandidate(candidate: Candidate): Observable<Candidate> {
    console.log(candidate);
    return this.http.put<Candidate>(`${this.baseUrlCommand}`, candidate);
  }

  deleteCandidate(command: Candidate): Observable<void> {
    return this.http.delete<void>(`${this.baseUrlCommand}`, { body: command });
  }
}
