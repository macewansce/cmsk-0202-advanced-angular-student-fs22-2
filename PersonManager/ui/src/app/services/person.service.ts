import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { v4 as uuidv4 } from 'uuid';
import { Person } from "../models/person.model";



@Injectable({
  providedIn: "root",
})
export class PersonService {
  private url = "http://localhost:3000/persons"; // URL to the JSON server

  constructor(private http: HttpClient) {}

  // Fetch the list of persons
  getPersons(): Observable<Person[]> {
    return this.http.get<Person[]>(this.url);
  }

  // Fetch a single person by id
  getPerson(id: string): Observable<Person> {
    return this.http.get<Person>(`${this.url}/${id}`);
  }

  // Add a new person
  addPerson(person: Person): Observable<Person> {
    person.id = uuidv4(); // Generate GUID
    return this.http.post<Person>(this.url, person);
  }

  // Update an existing person
  updatePerson(person: Person): Observable<Person> {
    return this.http.put<Person>(`${this.url}/${person.id}`, person);
  }

  // Delete a person by id
  deletePerson(id: string): Observable<void> {
    return this.http.delete<void>(`${this.url}/${id}`);
  }
}