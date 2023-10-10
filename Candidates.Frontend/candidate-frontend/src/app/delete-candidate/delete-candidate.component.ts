import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-delete-candidate',
  templateUrl: './delete-candidate.component.html',
  styleUrls: ['./delete-candidate.component.scss']
})
export class DeleteCandidateComponent {
  constructor(
    @Inject(MAT_DIALOG_DATA) public data: { candidateName: string },
    private dialogRef: MatDialogRef<DeleteCandidateComponent>
  ) {}

  onCancelClick(): void {
    this.dialogRef.close('cancel');
  }

  onDeleteClick(): void {
    this.dialogRef.close('confirm');
  }
}