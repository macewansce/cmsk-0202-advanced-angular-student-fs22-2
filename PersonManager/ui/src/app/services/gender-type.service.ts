import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { v4 as uuidv4 } from 'uuid';
import { GenderType } from "../models/gender-type.model";




@Injectable({
  providedIn: "root",
})
export class GenderTypeService {
  private url = "https://localhost:7007/api/GenderTypes"; // URL to the JSON server

  constructor(private http: HttpClient) {}

  // Fetch the list of genderTypes
  getGenderTypes(): Observable<GenderType[]> {
    return this.http.get<GenderType[]>(this.url);
  }

  // Fetch a single genderType by id
  getGenderType(id: string): Observable<GenderType> {
    return this.http.get<GenderType>(`${this.url}/${id}`);
  }

  // Add a new genderType
  addGenderType(genderType: GenderType): Observable<GenderType> {
    genderType.genderTypeId = 3; // The id is going incremented by our api
    return this.http.post<GenderType>(this.url, genderType);
  }

  // Update an existing genderType
  updateGenderType(genderType: GenderType): Observable<GenderType> {
    return this.http.put<GenderType>(`${this.url}/${genderType.genderTypeId}`, genderType);
  }

  // Delete a genderType by id
  deleteGenderType(id: number): Observable<void> {
    return this.http.delete<void>(`${this.url}/${id}`);
  }
}