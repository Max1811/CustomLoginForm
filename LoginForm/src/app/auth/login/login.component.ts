import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AccountService } from 'src/app/services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  public loginForm: FormGroup;
  public loading = false;
  public submitted = false;
  public returnUrl: string;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private accountService: AccountService) { }

  ngOnInit(): void {

    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  get form() { return this.loginForm.controls; }

  public async onSubmit(): Promise<void> {
    if(this.loginForm.invalid) {
      return;
    }

    this.submitted = true;

    this.loading = true;

    const result = await this.accountService.login(this.form.username.value, this.form.password.value);

    this.loading = false;

    //this.auth.service.login(this.form.username.value, this.form.password.value)
          //.pipe(first())
          //.subscribe(
            //data => {
                //this.router.navigate([this.returnUrl]);
            }//,
            //error => {
                //this.alertService.error(error);
                //this.loading = false;
            //});
  //}

}
