using System;
using System.Collections.Generic;
using contracted.Models;
using contracted.Repositories;

namespace contracted.Services
{
    public class JobsService
    {
        private readonly JobsRepository _repo;

        public JobsService(JobsRepository repo)
        {
            _repo = repo;
        }

        internal Job Create(Job newJob)
        {
            return _repo.Create(newJob);
        }

        internal Job Get(int id)
        {
            Job found = _repo.Get(id);
            if (found == null)
            {
                throw new Exception("Invalid Id");
            }
            return found;
        }

        internal void Delete(int id)
        {
            Get(id);
            _repo.Delete(id);
        }

        internal List<CompanyContractorContractorViewModel> GetContractors(int companyId)
        {
            List<CompanyContractorContractorViewModel> contractors = _repo.GetContractors(companyId);
            return contractors;
        }
    }
}