import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { VotingService } from '../services/voting.service';

@Component({
  selector: 'app-add-voting',
  templateUrl: './add-voting.component.html',
  styleUrls: ['./add-voting.component.scss']
})
export class AddVotingComponent implements OnInit {
  public votingForm: FormGroup;

  constructor(
    private cdr: ChangeDetectorRef,
    private formBuilder: FormBuilder,
    private votingService: VotingService
  ) { 
    this.votingForm = this.formBuilder.group({  
      name: '',  
      alternativesList: this.formBuilder.array([]) 
    }); 
    
    this.addNewAlternative();
  }

  ngOnInit(): void {
  }

  ngAfterViewChecked(){
    this.cdr.detectChanges();
 }

  get votingName() : FormControl {  
    return this.votingForm.get("name") as FormControl  
  } 

  get alternativesList() : FormArray {  
    return this.votingForm.get("alternativesList") as FormArray  
  }  

  public addNewAlternative() {  
    this.alternativesList.push(this.newAlternative());  
  } 
  
  public removeAlternative(index: number) {
    this.alternativesList.removeAt(index);
  }

  public submit() {
    const formData = {
      'name' : this.votingName.value,
      'alternatives' : this.alternativesList.controls.map(control => control.value)
    };

    console.error(formData);

    this.votingService.add(formData);
  }

  private newAlternative(): FormGroup {  
    return this.formBuilder.group({  
      name: ''
    })  
  }  

}
