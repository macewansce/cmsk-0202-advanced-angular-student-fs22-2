// Person model interface
export interface Person {
    personId: string; 
    firstName: string; 
    lastName: string; 
    dateOfBirth: Date;
    email: string; 
    phone: number;
    genderTypeId: number
    isDeleted: boolean,
    dateCreated: Date, 
  }
