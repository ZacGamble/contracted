using System.Collections.Generic;
using contracted.Models;
using contracted.Repositories;

namespace contracted.Services
{
    public class ContractorsService
    {
        private readonly ContractorsRepository _repo;

        public ContractorsService(ContractorsRepository repo)
        {
            _repo = repo;
        }

        internal Contractor Create(Contractor contractor)
        {
            Contractor newContractor = _repo.Create(contractor);
            return newContractor;
        }

        internal List<Contractor> Get()
        {
            return _repo.Get();
        }

        internal Contractor Get(int id)
        {
            Contractor foundContractor = _repo.Get(id);
            if (foundContractor == null)
            {
                throw new System.Exception("Invalid ID");
            }
            return foundContractor;
        }

        internal Contractor Edit(Contractor contractor)
        {
            Contractor original = Get(contractor.Id);
            original.Name = contractor.Name ?? original.Name;
            original.Type = contractor.Type ?? original.Type;

            _repo.Edit(original);
            return original;
        }

        internal void Delete(int id)
        {
            Contractor foundContractor = Get(id);
            _repo.Delete(id);
        }
    }
}