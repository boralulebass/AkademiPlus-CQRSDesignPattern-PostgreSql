using CQRSAkademiPlusPostgres.CQRSPattern.Queries;
using CQRSAkademiPlusPostgres.CQRSPattern.Results;
using CQRSAkademiPlusPostgres.DAL;

namespace CQRSAkademiPlusPostgres.CQRSPattern.Handlers
{
    public class GetEmployeeUpdateQueryHandler
    {
        private readonly Context _context;

        public GetEmployeeUpdateQueryHandler(Context context)
        {
            _context = context;
        }
        public GetEmployeeUpdateQueryResult Handle(GetEmployeeUpdateQuery query)
        {
            var VALUES = _context.Employees.Find(query.Id);
            return new GetEmployeeUpdateQueryResult
            {
                EmployeeAge = VALUES.EmployeeAge,
                EmployeeName = VALUES.EmployeeName,
                EmployeeCity = VALUES.EmployeeCity,
                EmployeeID = VALUES.EmployeeID,
                EmployeeSalary = VALUES.EmployeeSalary,
                EmployeeSurname = VALUES.EmployeeSurname,
                EmployeeTitle = VALUES.EmployeeTitle,
            };
        }
    }
}
