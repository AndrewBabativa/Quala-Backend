import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateCandidateComponent } from './create-candidate/create-candidate.component';
import { CandidateListComponent } from './candidate-list/candidate-list.component';
import { UpdateCandidateComponent } from './update-candidate/update-candidate.component';

const routes: Routes = [
  { path: '', component: CandidateListComponent },
  { path: 'crear-candidato', component: CreateCandidateComponent },
  { path: 'app-candidate-list', component: CandidateListComponent },
  { path: 'editar-candidato/:id', component: UpdateCandidateComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
