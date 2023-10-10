import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl, FormArray   } from '@angular/forms';
import { CandidateService } from '../candidate.service'; 
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-candidate',
  templateUrl: './create-candidate.component.html',
  styleUrls: ['./create-candidate.component.scss']
})
export class CreateCandidateComponent implements OnInit {
  candidateForm: FormGroup = new FormGroup({
    name: new FormControl('', [Validators.required, Validators.maxLength(50)]),
    surname: new FormControl('', [Validators.required, Validators.maxLength(150)]),
    birthday: new FormControl('', Validators.required),
    email: new FormControl('', [Validators.required, Validators.email, Validators.maxLength(250)])
  });

  constructor(private fb: FormBuilder, 
    private candidateService: CandidateService, 
    private router: Router) {}

  ngOnInit(): void {
    this.candidateForm = this.fb.group({
      name: ['', [Validators.required, Validators.maxLength(50)]],
      surname: ['', [Validators.required, Validators.maxLength(150)]],
      birthday: ['', Validators.required],
      email: ['', [Validators.required, Validators.email, Validators.maxLength(250)]],
      candidateExperiences: this.fb.array([])
    });
  }

  addExperience() {
    const experienceFormGroup = this.fb.group({
      company: ['', Validators.required],
      job: ['', Validators.required],
      description: [''],
      salary: [''],
      beginDate: [''],
      endDate: ['']
    });
    this.experiences.push(experienceFormGroup);
  }

  get experiences() {
    return this.candidateForm.get('candidateExperiences') as FormArray;
  }

  createCandidate() {
    const formData = this.candidateForm.value;
    try {
      const createdCandidate$ = this.candidateService.createCandidate(formData);
      createdCandidate$.subscribe((createdCandidate) => {
        console.log('Candidato creado:', createdCandidate);
        this.router.navigate(['/app-candidate-list']);
      }, (error) => {
        console.error('Error al crear el candidato:', error);
      });
    } catch (error) {
      console.error('Error en la solicitud:', error);
    }
  }
}
