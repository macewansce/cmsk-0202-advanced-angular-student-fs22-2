// Person model interface
export interface Person {
    id: string; // Unique identifier for each person
    name: string; // Name of the person
    age: number; // Age of the person
    email: string; // Email address of the person
    phone: string; // Phone number of the person
    dateOfBirth: Date;
    genderTypeId: number
    dateCreated: Date,
    isDeleted: boolean,
  }