using CQRSAkademiPlusPostgres.CQRSPattern.Queries;
using CQRSAkademiPlusPostgres.CQRSPattern.Results;
using CQRSAkademiPlusPostgres.DAL;

namespace CQRSAkademiPlusPostgres.CQRSPattern.Handlers
{
    public class GetEmployeeByIDQueryHandler
    {
        private readonly Context _context;

        public GetEmployeeByIDQueryHandler(Context context)
        {
            _context = context;
        }
        public GetEmployeeByIDQueryResult Handle(GetEmployeeByIDQuery query)
        {
            var values = _context.Employees.Find(query.Id);
            return new GetEmployeeByIDQueryResult
            {
                EmployeeCity = values.EmployeeCity,
                EmployeeID = values.EmployeeID,
                EmployeeName = values.EmployeeName,
                EmployeeSurname = values.EmployeeSurname,
            };
        }
    }
}
