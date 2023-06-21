namespace CQRSAkademiPlusPostgres.CQRSPattern.Queries
{
    public class GetEmployeeUpdateQuery
    {
        public GetEmployeeUpdateQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
