import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AccountService } from 'src/app/account/services/account.service';
import { SessionService } from 'src/app/shared/session.service';

@Component({
  selector: 'app-user-settings',
  templateUrl: './user-settings.component.html',
  styleUrls: ['./user-settings.component.scss']
})
export class UserSettingsComponent implements OnInit {
  searchvalue: string = "";
  loadComponent: boolean = false;

  constructor(
    private readonly _accountService: AccountService,
    private readonly _sessionService: SessionService,
  ) { }

  ngOnInit(): void {
  }

  public onSearch(input: string): void {
    this.loadComponent = false;
    if(Number(input)) {
      this._accountService.getUserById(Number(input), async () => {
        await console.log("success"), this.loadComponent = true;
      });
    }
    else {
      console.log("not a number")
    }

  }
}
