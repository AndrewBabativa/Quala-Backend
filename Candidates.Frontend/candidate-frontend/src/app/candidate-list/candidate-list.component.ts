import { Component, OnInit } from '@angular/core';
import { CandidateService } from '../candidate.service'; 
import { Candidate } from '../model/candidate.model';
import { MatDialog } from '@angular/material/dialog';
import { DeleteCandidateComponent } from '../delete-candidate/delete-candidate.component';


@Component({
  selector: '  ',
  templateUrl: './candidate-list.component.html',
  styleUrls: ['./candidate-list.component.scss']
})
export class CandidateListComponent implements OnInit {
  candidates: Candidate[] = []; 
  constructor(private candidateService: CandidateService, private dialog: MatDialog) {}
  ngOnInit(): void {
    this.candidateService.getAllCandidates().subscribe(
      (data) => {
        this.candidates = data;
      },
      (error) => {
        console.error('Error al obtener candidatos:', error);
      }
    );
  }
  
  getCandidates(): void {
    this.candidateService.getAllCandidates().subscribe((candidates: Candidate[]) => { 
      this.candidates = candidates;
    });
  }

  showDeleteConfirmation(candidate: Candidate) {
    const dialogRef = this.dialog.open(DeleteCandidateComponent, {
      data: { candidateName: candidate.name }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result === 'confirm') {
        this.candidateService.deleteCandidate(candidate).subscribe(() => {
          this.getCandidates();
        });
      }
    });
  }
}
