import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CandidateListComponent } from './candidate-list/candidate-list.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { CandidateService } from './candidate.service';
import { HttpClientModule } from '@angular/common/http';
import { CreateCandidateComponent } from './create-candidate/create-candidate.component';
import { ReactiveFormsModule } from '@angular/forms';
import { UpdateCandidateComponent } from './update-candidate/update-candidate.component';
import { DeleteCandidateComponent } from './delete-candidate/delete-candidate.component';
import { MatDialogModule } from '@angular/material/dialog';

@NgModule({
  declarations: [AppComponent, CandidateListComponent, CreateCandidateComponent, UpdateCandidateComponent, DeleteCandidateComponent],
  imports: [
    MatSlideToggleModule,
    BrowserModule,
    ReactiveFormsModule, 
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatDialogModule,
  ],
  providers: [
    CandidateService, 
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
