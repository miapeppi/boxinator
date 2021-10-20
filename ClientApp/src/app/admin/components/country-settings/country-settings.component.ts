import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormArray, Validators } from '@angular/forms';
import { Country } from 'src/app/login/models/country.model';
import { CountryService } from 'src/app/login/services/country.service';
import { SessionService } from 'src/app/shared/session.service';
import { Zone } from '../../models/zone.model';
import { ZoneService } from '../../services/zone.service';

@Component({
  selector: 'app-country-settings',
  templateUrl: './country-settings.component.html',
  styleUrls: ['./country-settings.component.scss'],
})
export class CountrySettingsComponent implements OnInit {

  private _countries: Country[] = [];
  private _zones: Zone[] = [];
  private _selectedZoneId = 1;
  private _settingsForm: any;
  private _zonesSelect: any;
  private _countryForm: any;
  private _countriesFormArray: FormArray | any;
  private _selectedCountry: any = {
    id: 0,
    name: '',
    zoneId: 0,
  };
  private _selectedZone: Zone = {
    id: 0,
    name: '',
    countryMultiplier: 0,
  };

  constructor(
    private readonly zoneService: ZoneService,
    private readonly countryService: CountryService,
    private readonly sessionService: SessionService
  ) {


    this._settingsForm = new FormGroup({
      zoneSelect: this._zonesSelect = new FormControl(1, []),
      countriesFormArray: this._countriesFormArray = new FormArray([]),
    });
  }

  ngOnInit(): void {
    // this.zoneService.fetchZoneCountriesToSession(this._selectedZoneId, async () => {
    //   this._countries = this.sessionService.countries!;
    // });
    this.zoneService.fetchZonesToSession(async () => {
      this._zones = this.sessionService.zones!;
      this._selectedZoneId = this._zones[0].id
    });

  }



  onChanges() {


    console.log("Loaded countries for id: " + this._selectedZoneId, this._countries)
    this.setCountriesForm();
  }

  countrySave(editedCountry: any) {
    console.table(editedCountry)
    const countryFormArray = this._countriesFormArray as FormArray;

    // const country: Country = {
    //   id: countryFormArray.at(i).get('countryName')?.value,
    //   name: countryFormArray.at(i).get('countryName')?.value,
    //   zoneId: 0,
    //   zoneName: '',
    //   countryMultiplier: 0
    // }
  }

  setCountriesForm() {
    this._countriesFormArray = new FormArray([]);

    this._countries.forEach((country) => {
      if (country.zoneId === this._selectedZone.id) {
        console.log("Populating form with country: ", country)
        //New form group & add to form array
        const countryForm = new FormGroup({
            countryId: new FormControl(country.id),
            countryName: new FormControl(country.name, [Validators.required]),
            countryZoneId: new FormControl(country.zoneId),
            countryZoneName: new FormControl(country.zoneName, [Validators.required]),
            countryMultiplier: new FormControl(country.countryMultiplier),
        });
        // console.log("Country Form: ", countryForm)

        this._countriesFormArray.push(new FormArray([]))
        // this._countriesFormArray.push(countryForm)
      }
    });
    console.table(this._settingsForm)
  }

  get zones() {
    return this._zones;
  }
  get selectedZone() {
    return this._selectedZone;
  }
  get countries() {
    return this._countries;
  }
  // get countriesFormArray() {
  //   return this._settingsForm.get("countriesFormArray") as FormArray;
  // }
  get countriesFormArray() {
    return this._countriesFormArray as FormArray;
  }
  get settingsForm() {
    return this._settingsForm;
  }
  get selectedCountry() {
    return this._selectedCountry;
  }
}
