﻿using Entities;
using RepositoryContracts;
using ServiceContracts;
using ServiceContracts.DTO;
using ServiceLayer.Helpers;


namespace ServiceLayer
{
    public class PersonsAdderService : IPersonsAdderService
    {
        // Fields
        private readonly IPersonsRepository _personsRepository;

        // Constructors
        public PersonsAdderService(IPersonsRepository personsRepository)
        {
            _personsRepository = personsRepository;
        }

        // Methods
        public async Task<PersonResponse> AddPerson(PersonAddRequest? personAddRequest)
        {
            // personAddRequest parameter can't be null
            if (personAddRequest == null)
            {
                throw new ArgumentNullException(nameof(personAddRequest));
            }

            // Model Validations
            ValidationHelper.ModelValidation(personAddRequest);

            // To convert PersonAddRequest into Person type
            Person person = personAddRequest.ToPerson();

            // To generate the new PersonID
            person.PersonID = Guid.NewGuid();


            // add person object into list of persons
            // Regular Linq Query
            await _personsRepository.AddPerson(person);

            /*
            // Stored Procedure
            _db.ProcedureInsertPerson(person);
            */

            return person.ToPersonResponse();
        }
    }
}

