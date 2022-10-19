import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AccountService } from 'src/app/services/account.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.scss']
})
export class SignUpComponent implements OnInit {

  public signUpForm: FormGroup;
  public loading = false;
  public submitted = false;
  public returnUrl: string;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private accountService: AccountService) { }

  ngOnInit(): void {

    this.signUpForm = this.formBuilder.group({
      email: ['', Validators.required],
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  get form() { return this.signUpForm.controls; }

  public async onSubmit(): Promise<void> {
    if (this.signUpForm.invalid) {
      return;
    }

    this.loading = true;

    const result = await this.accountService.signUp(this.form.email.value, this.form.username.value, this.form.password.value);

    if (result) {
      this.router.navigate(["/"]);
    } else {
      this.signUpForm.reset();
    }

    this.submitted = true;
    this.loading = false;
  }
}
