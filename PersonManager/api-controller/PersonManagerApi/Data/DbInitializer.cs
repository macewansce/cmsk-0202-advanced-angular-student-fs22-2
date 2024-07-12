﻿using PersonManagerApi.Models;

namespace PersonManagerApi.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            _ = context.Database.EnsureCreated();

            if (context.GenderTypes.Any())
            {
                return; // DB has been seeded
            };

            GenderType[] genderTypes = new GenderType[]
            {
                new GenderType{Name="Male", DateCreated=DateTime.Now, IsDeleted=false},
                new GenderType{Name="Female", DateCreated=DateTime.Now, IsDeleted=false},
            };
            foreach (GenderType genderType in genderTypes)
            {
                _ = context.GenderTypes.Add(genderType);
            }
            _ = context.SaveChanges();

            Person[] persons = new Person[]
            {
                new Person{PersonId="02b0c37a-6890-434f-9b95-70526aeb4eea", FirstName="Hammad", LastName="Tawfig", DateOfBirth=DateTime.Now.AddYears(-40), Email="tawfigh2@macewan.ca", Phone=int.Parse("7809876543"), GenderTypeId=genderTypes.Single(ct => ct.Name == "Male").GenderTypeId },
                new Person{PersonId="49d981d2-4f8b-456b-bd25-509d59393d6c", FirstName="August", LastName="Tawfig", DateOfBirth=DateTime.Now.AddYears(-35), Email="tawfigh2@macewan.ca", Phone=int.Parse("7809876543"), GenderTypeId=genderTypes.Single(ct => ct.Name == "Female").GenderTypeId }
            };

            foreach (Person person in persons)
            {
                _ = context.Persons.Add(person);
            }
            _ = context.SaveChanges();



        }
    }
}
