using System.Collections.Generic;
using System.Data;
using System.Linq;
using contracted.Models;
using Dapper;

namespace contracted.Repositories
{
    public class JobsRepository
    {
        private readonly IDbConnection _db;

        public JobsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Job Create(Job newJob)
        {
            string sql = @"
           INSERT INTO jobs
           (contractorId, companyId, rate)
           VALUES
           (@ContractorId, @CompanyId, @Rate);
           SELECT LAST_INSERT_ID();
           ";
            newJob.Id = _db.ExecuteScalar<int>(sql, newJob);
            return newJob;
        }

        internal Job Get(int id)
        {
            string sql = "SELECT * FROM jobs WHERE id = @id";
            return _db.QueryFirstOrDefault<Job>(sql, new { id });
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM jobs WHERE id = @id LIMIT 1";
            _db.Execute(sql, new { id });
        }

        internal List<CompanyContractorContractorViewModel> GetContractors(int companyId)
        {
            string sql = @"
            SELECT
            contract.*,
            cccvm.id AS jobId
            FROM jobs cccvm
            JOIN contractors contract ON cccvm.contractorId = contract.id
            WHERE cccvm.companyId = @companyId
            ";
            return _db.Query<CompanyContractorContractorViewModel>(sql, new { companyId }).ToList();
        }
    }
}