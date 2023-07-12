﻿using ServiceContracts.DTO;

namespace ServiceContracts
{
    public interface IPersonsGetterService
    {
        Task<List<PersonResponse>> GetAllPersons();

        Task<PersonResponse?> GetPersonByPersonID(Guid? personID);

        Task<List<PersonResponse>> GetFilteredPersons(string searchBy, string? searchString);

        Task<MemoryStream> GetPersonsCSV();

        Task<MemoryStream> GetPersonsExcel();
    }
}
