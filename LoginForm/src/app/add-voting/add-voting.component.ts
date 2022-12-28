import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-voting',
  templateUrl: './add-voting.component.html',
  styleUrls: ['./add-voting.component.scss']
})
export class AddVotingComponent implements OnInit {

  nameControl = this.formBuilder.control<string>('', [ Validators.required]);
  alternativesListControl = this.formBuilder.array([]);

  form: FormGroup = this.formBuilder.group({
    'email': this.nameControl,
    'alternativesList': this.alternativesListControl
  });

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit(): void {
  }

  submit() {
  }

}
