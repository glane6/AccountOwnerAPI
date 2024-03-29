﻿using System;
using System.Collections.Generic;
using Entities.ExtendedModels;
using Entities.Models;
namespace Contracts
{
    public interface IOwnerRepository : IRepositoryBase<Owner>
    {
        IEnumerable<Owner> GetAllOwners();
        Owner GetOwnerById(Guid ownerID);
        OwnerExtended GetOwnerWithDetails(Guid ownerID);
    }
    
}
