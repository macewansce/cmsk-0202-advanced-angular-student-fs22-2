import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Person } from '../models/person.model';
import { PersonService } from '../services/person.service';
import { GenderTypeService } from '../services/gender-type.service';
import { GenderType } from '../models/gender-type.model';

@Component({
  selector: 'app-person-list',
  templateUrl: './person-list.component.html',
  styleUrls: ['./person-list.component.scss'],
})
export class PersonListComponent implements OnInit {
  persons: Person[] = []; // Array to hold list of persons
  genderTypes: GenderType[] = [];
  color = 'yellow'
  
  constructor(
    private personService: PersonService,
    private genderTypeService: GenderTypeService,
    private router: Router
  ) {}

  ngOnInit() {
    // Fetch persons on component initialization
    this.personService.getPersons().subscribe((data) => {
      this.persons = data;
    });

    this.genderTypeService.getGenderTypes().subscribe((data) => {
      this.genderTypes = data;
    });
  }

  // Navigate to person details component
  viewPerson(personId: string) {
    this.router.navigate(['/person', personId]);
  }

  // Navigate to new person form
  addPerson() {
    this.router.navigate(['/person']);
  }

  getGenderTypeName(id: number): string {

    const genderType = this.genderTypes.find((x) => x.genderTypeId == id)

    if(genderType) {
      return genderType.name;
    }

    throw `Unable to find GenderType by the given Id: ${id}`;
  } 
}
