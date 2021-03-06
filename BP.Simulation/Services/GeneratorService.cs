﻿using BP.Simulation.Models;
using System;

namespace BP.Simulation.Services
{
    public class GeneratorService
    {
        private readonly NamesLists _namesLists;

        public GeneratorService(NamesLists namesLists)
        {
            _namesLists = namesLists;
        }

        public Customer GenerateCustomer()
        {
            Random rnd = new Random();
            bool isMale = rnd.NextDouble() > 0.5;
            Customer result = new Customer
            {
                FirstName = GenerateFirstName(isMale, rnd),
                Surname = GenerateSurname(isMale, rnd),
                PhoneNumber = GeneratePhoneNumber(rnd)
            };
            result.Email = GenerateEmail(result.FirstName, result.Surname);
            result.Username = GenerateUsername(result.FirstName, result.Surname);
            result.Password = GeneratePassword(result.FirstName, result.Surname);
        
            return result;
        }

        public string GeneratePassword(string firstName, string surname)
        {
            return $"{firstName}+{surname}@123";
        }

        public string GenerateUsername(string firstName, string surname)
        {
            return $"{firstName[0]}.{surname}".ToLower();
        }

        private string GenerateSurname(bool isMale, Random rnd)
        {
            if (isMale)
            {
                return _namesLists.SurnamesMale[rnd.Next(_namesLists.SurnamesMale.Length)];
            }
            else
            {
                return _namesLists.SurnamesFemale[rnd.Next(_namesLists.SurnamesFemale.Length)];
            }
        }

        private string GenerateFirstName(bool isMale, Random rnd)
        {
            if (isMale)
            {
                return _namesLists.FirstNamesMale[rnd.Next(_namesLists.FirstNamesMale.Length)];
            }
            else
            {
                return _namesLists.FirstNamesFemale[rnd.Next(_namesLists.FirstNamesFemale.Length)];
            }
        }

        private string GeneratePhoneNumber(Random rnd)
        {
            return rnd.Next(100000000, 999999999).ToString();
        }

        private string GenerateEmail(string firstName, string surname)
        {
            return $"{firstName[0]}.{surname}@gmail.com".ToLower();
        }
    }
}
