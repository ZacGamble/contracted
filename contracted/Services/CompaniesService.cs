using System.Collections.Generic;
using contracted.Models;
using contracted.Repositories;

namespace contracted.Services
{
    public class CompaniesService
    {
        private readonly CompaniesRepository _repo;

        public CompaniesService(CompaniesRepository repo)
        {
            _repo = repo;
        }

        internal List<Company> Get()
        {
            return _repo.Get();
        }

        internal Company Get(int id)
        {
            Company foundCompany = _repo.Get(id);
            if (foundCompany == null)
            {
                throw new System.Exception("Invalid ID");
            }
            return foundCompany;
        }

        internal Company Create(Company company)
        {
            Company newCompany = _repo.Create(company);
            return newCompany;
        }

        internal Company Edit(Company company)
        {
            Company original = Get(company.Id);
            original.Name = company.Name ?? original.Name;
            _repo.Edit(original);
            return original;
        }

        internal void Delete(int id)
        {
            Company foundCompany = Get(id);
            _repo.Delete(id);
        }
    }
}