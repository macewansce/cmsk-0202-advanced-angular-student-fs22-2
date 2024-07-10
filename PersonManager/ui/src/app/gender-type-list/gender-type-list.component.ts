import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { GenderType } from '../models/gender-type.model';
import { GenderTypeService } from '../services/gender-type.service';

@Component({
  selector: 'app-gender-type-list',
  templateUrl: './gender-type-list.component.html',
  styleUrls: ['./gender-type-list.component.scss'],
})
export class GenderTypeListComponent implements OnInit {
  genderTypes: GenderType[] = []; 

  constructor(private genderTypeService: GenderTypeService, private router: Router) {}

  ngOnInit() {

    this.genderTypeService.getGenderTypes().subscribe((data) => {
      this.genderTypes = data;
    });
  }


  viewGenderType(id: number) {
    this.router.navigate(['/gender-type', id]);
  }


  addGenderType() {
    this.router.navigate(['/gender-type']);
  }
}
