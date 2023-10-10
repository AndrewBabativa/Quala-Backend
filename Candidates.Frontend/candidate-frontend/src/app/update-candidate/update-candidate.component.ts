import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormArray } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CandidateService } from '../candidate.service';
import { Candidate, CandidateExperience } from '../model/candidate.model';

@Component({
  selector: 'app-update-candidate',
  templateUrl: './update-candidate.component.html',
  styleUrls: ['./update-candidate.component.scss']
})
export class UpdateCandidateComponent implements OnInit {
  candidateForm: FormGroup;
  candidate: Candidate = {
    idCandidate: 0,
    name: '',
    surname: '',
    birthday: new Date(),
    email: '',
    insertDate: new Date(),
    modifyDate: new Date(),
    candidateExperiences: [] 
  };
  experiences: FormArray;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private candidateService: CandidateService,
    private router: Router
  ) {
    this.candidateForm = this.fb.group({
      IdCandidate: 0,
      name: ['', [Validators.required, Validators.maxLength(50)]],
      surname: ['', [Validators.required, Validators.maxLength(150)]],
      birthday: ['', Validators.required],
      email: ['', [Validators.required, Validators.email, Validators.maxLength(250)]],
      candidateExperiences: this.fb.array([]) 
    });
    this.experiences = this.candidateForm.get('candidateExperiences') as FormArray;
  }

  ngOnInit(): void {
    this.initializeForm();
    this.loadCandidate();
  }

  initializeForm() {
    this.candidateForm = this.fb.group({
      name: ['', [Validators.required, Validators.maxLength(50)]],
      surname: ['', [Validators.required, Validators.maxLength(150)]],
      birthday: ['', Validators.required],
      email: ['', [Validators.required, Validators.email, Validators.maxLength(250)]],
      candidateExperiences: this.fb.array([]) 
    });
    this.experiences = this.candidateForm.get('candidateExperiences') as FormArray;
  }

  loadCandidate() {
    const idParam = this.route.snapshot.paramMap.get('id');
  
    if (idParam !== null) {
      const candidateId = +idParam; 
  
      if (!isNaN(candidateId)) {
        this.candidateService.getCandidateById(candidateId).subscribe(
          (loadedCandidate) => {
            this.candidate = loadedCandidate;
            this.populateForm();
          },
          (error) => {
            console.error('Error al cargar el candidato:', error);
          }
        );
      } else {
        console.error('El parámetro "id" no es un número válido.');
      }
    } else {
      console.error('El parámetro "id" no está presente en la URL.');
    }
  }

  populateForm() {
    this.candidateForm.patchValue({
      name: this.candidate.name,
      surname: this.candidate.surname,
      birthday: this.candidate.birthday,
      email: this.candidate.email
    });

    this.experiences.clear(); 

    this.candidate.candidateExperiences.forEach((experience) => {
      this.experiences.push(this.createExperienceFormGroup(experience));
    });
  }

  createExperienceFormGroup(experience: CandidateExperience): FormGroup {
    return this.fb.group({
      company: [experience.company, Validators.required],
      job: [experience.job, Validators.required],
      description: [experience.description],
      salary: [experience.salary],
      beginDate: [experience.beginDate],
      endDate: [experience.endDate]
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

  saveCandidate() {
    const formData = this.candidateForm.value;
    formData.idCandidate = this.route.snapshot.paramMap.get('id');
    try {
      const updateCandidate$ = this.candidateService.updateCandidate(formData);
      updateCandidate$.subscribe((updateCandidate) => {
        console.log('Candidato actualizado:', updateCandidate);
        this.router.navigate(['/app-candidate-list']);
      }, (error) => {
        console.error('Error al crear el candidato:', error);
      });
    } catch (error) {
      console.error('Error en la solicitud:', error);
    }
  }
}
