import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Person } from '../models/person.model';
import { PersonService } from '../services/person.service';
import { GenderTypeService } from '../services/gender-type.service';
import { GenderType } from '../models/gender-type.model';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.scss'],
})
export class PersonComponent implements OnInit {
  person: Person = {
    id: '',
    name: '',
    age: 0,
    email: '',
    phone: '',
    dateOfBirth: new Date(),
    genderTypeId: 0,
    dateCreated: new Date(),
    isDeleted: false,
  };

  genderTypes: GenderType[] = [];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private personService: PersonService,
    private genderTypeService: GenderTypeService
  ) {}

  ngOnInit() {
    const id = this.route.snapshot.paramMap?.get('id'); // Get person id from route
    if (id) {
      // Fetch person details if id exists
      this.personService.getPerson(id).subscribe((data) => {
        this.person = data;
      });
    }

    this.genderTypeService.getGenderTypes().subscribe((data) => {
      this.genderTypes = data;
      console.log(data);
    });
  }

  // Save person details
  savePerson() {
    if (this.person.id) {
      this.personService
        .updatePerson(this.person)
        .subscribe(() => this.goBack());
    } else {
      this.personService.addPerson(this.person).subscribe(() => this.goBack());
    }
  }

  // Delete person
  deletePerson() {
    if (this.person.id) {
      this.personService
        .deletePerson(this.person.id)
        .subscribe(() => this.goBack());
    }
  }

  // Navigate back to persons list
  goBack() {
    this.router.navigate(['/persons']);
  }
}
