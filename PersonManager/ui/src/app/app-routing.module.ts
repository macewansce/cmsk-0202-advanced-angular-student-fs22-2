import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PersonListComponent } from './person-list/person-list.component';
import { PersonComponent } from './person/person.component';
import { GenderTypeListComponent } from './gender-type-list/gender-type-list.component';
import { GenderTypeComponent } from './gender-type/gender-type.component';

const routes: Routes = [
  { path: 'persons', component: PersonListComponent },
  { path: 'person/:personId', component: PersonComponent },
  { path: "person", component: PersonComponent },
  { path: 'gender-types', component: GenderTypeListComponent },
  { path: 'gender-type/:id', component: GenderTypeComponent },
  { path: "gender-type", component: GenderTypeComponent },
  { path: '', redirectTo: '/persons', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
