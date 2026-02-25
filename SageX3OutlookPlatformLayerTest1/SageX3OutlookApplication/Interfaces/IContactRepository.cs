using SageX3OutlookDomain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SageX3OutlookDomain.Persistence.Repositories;

public interface IContactRepository
{
    // 1. Returns a specific Contact by ID
    Task<Contact?> GetByIdAsync(Guid id);

    // 2. Adds a single Contact
    Task AddAsync(Contact entity);

    // 3. Adds multiple Contacts at once
    Task AddRangeAsync(List<Contact> contacts);

    // 4. Retrieves all Contacts
    Task<IEnumerable<Contact>> GetAllAsync();

    // 5. FIXED: Changed from 'object' to 'Contact' so the Service can see its properties
    Task UpdateAsync(Contact entity);
}

