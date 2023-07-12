﻿using ContactsManager.Core.Domain.Entities;
using ContactsManager.Core.Domain.RepositoryContracts;
using ContactsManager.Core.DTO;
using ContactsManager.Core.Exceptions;
using ContactsManager.Core.Helpers;
using ContactsManager.Core.ServiceContracts;

namespace ContactsManager.Core.Services
{
    public class PersonsUpdaterService : IPersonsUpdaterService
    {
        // Fields
        private readonly IPersonsRepository _personsRepository;

        // Constructors
        public PersonsUpdaterService(IPersonsRepository personsRepository)
        {
            _personsRepository = personsRepository;
        }

        // Methods
        public async Task<PersonResponse> UpdatePerson(PersonUpdateRequest? personUpdateRequest)
        {
            // personUpdateRequest can't be null
            if (personUpdateRequest == null)
            {
                throw new ArgumentNullException(nameof(PersonUpdateRequest));
            }

            // Model Validation
            ValidationHelper.ModelValidation(personUpdateRequest);

            // Get matching Person from List<Person> based on PersonID
            // Regular Linq Query
            Person? matchingPerson = await _personsRepository.GetPersonByPersonID(personUpdateRequest.PersonID);

            if (matchingPerson == null)
            {
                throw new InvalidPersonIdException("Invalid PersonID");  // Custom Exception Class
                //throw new ArgumentException("Invalid PersonID");
            }

            // Update all details
            // Regular Linq Query
            var presonUpdated = await _personsRepository.UpdatePerson(personUpdateRequest.ToPerson());

            /*
            // Stored Procedure
            _db.ProcedureUpdatePerson(personUpdateRequest.ToPerson());
            */

            return presonUpdated.ToPersonResponse();
        }
    }
}
