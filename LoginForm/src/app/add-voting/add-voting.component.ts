import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-add-voting',
  templateUrl: './add-voting.component.html',
  styleUrls: ['./add-voting.component.scss']
})
export class AddVotingComponent implements OnInit {
  public votingForm: FormGroup;

  constructor(private formBuilder: FormBuilder) { 
    this.votingForm = this.formBuilder.group({  
      name: '',  
      alternativesList: this.formBuilder.array([]) 
    }); 
    
    this.addQuantity();
  }

  ngOnInit(): void {
  }

  get alternativesList() : FormArray {  
    return this.votingForm.get("alternativesList") as FormArray  
  }  

  public addQuantity() {  
    this.alternativesList.push(this.newAlternative());  
  }  

  private newAlternative(): FormGroup {  
    return this.formBuilder.group({  
      name: ''
    })  
  }  

  submit() {
  }

}
