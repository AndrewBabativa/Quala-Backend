export interface Candidate {
    idCandidate: number;
    name: string;
    surname: string;
    birthday: Date;
    email: string;
    insertDate: Date;
    modifyDate: Date;
    candidateExperiences: CandidateExperience[];
  }
  
  export interface CandidateExperience {
    idCandidateExperience: number;
    company: string;
    job: string;
    description: string;
    salary: number;
    beginDate: Date;
    endDate: Date;
    insertDate: Date;
    modifyDate: Date;
    idCandidate: number;
  }
  