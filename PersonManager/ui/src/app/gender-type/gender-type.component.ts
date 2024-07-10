import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { GenderType } from '../models/gender-type.model';
import { GenderTypeService } from '../services/gender-type.service';


@Component({
  selector: 'app-gender-type',
  templateUrl: './gender-type.component.html',
  styleUrls: ['./gender-type.component.scss']
})
export class GenderTypeComponent implements OnInit {
  genderType: GenderType = {
    genderTypeId: 0,
    name: '',
    dateCreated: new Date(),
    isDeleted: false
  }; 

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private genderTypeService: GenderTypeService
  ) { }

  ngOnInit() {
    const id = this.route.snapshot.paramMap?.get('id'); // Get genderType id from route
    if (id) {
      // Fetch genderType details if id exists
      this.genderTypeService.getGenderType(id).subscribe(data => {
        this.genderType = data;
        console.log(this.genderType)
      });
    }
  }

  // Save genderType details
  saveGenderType() {
    if (this.genderType.genderTypeId) {
      this.genderTypeService.updateGenderType(this.genderType).subscribe(() => this.goBack());
    } else {
      this.genderTypeService.addGenderType(this.genderType).subscribe(() => this.goBack());
    }
  }

  // Delete genderType
  deleteGenderType() {
    if (this.genderType.genderTypeId) {
      this.genderTypeService.deleteGenderType(this.genderType.genderTypeId).subscribe(() => this.goBack());
    }
  }

  // Navigate back to genderTypes list
  goBack() {
    this.router.navigate(['/gender-types']);
  }
}