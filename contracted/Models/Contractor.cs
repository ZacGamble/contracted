namespace contracted.Models
{
    public class Contractor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }

    public class CompanyContractorContractorViewModel : Contractor
    {
        public int CompanyContractorId { get; set; }
    }
}