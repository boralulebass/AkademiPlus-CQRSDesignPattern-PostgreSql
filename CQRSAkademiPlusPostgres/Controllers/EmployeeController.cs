using CQRSAkademiPlusPostgres.CQRSPattern.Commands;
using CQRSAkademiPlusPostgres.CQRSPattern.Handlers;
using CQRSAkademiPlusPostgres.CQRSPattern.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CQRSAkademiPlusPostgres.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly GetEmployeeQueryHandler _getEmployeeQueryHandler;
        private readonly GetEmployeeByIDQueryHandler _getEmployeeByIDQueryHandler;
        private readonly CreateEmployeeCommandHandler _createEmployeeCommandHandler;
        private readonly RemoveEmployeeCommandHandler _removeEmployeeCommandHandler;
        private readonly GetEmployeeUpdateQueryHandler _getEmployeeUpdateQueryHandler;
        private readonly UpdateEmployeeCommandHandler _updateEmployeeCommandHandler;

        public EmployeeController(GetEmployeeQueryHandler getEmployeeQueryHandler, GetEmployeeByIDQueryHandler getEmployeeByIDQueryHandler, CreateEmployeeCommandHandler createEmployeeCommandHandler, RemoveEmployeeCommandHandler removeEmployeeCommandHandler, GetEmployeeUpdateQueryHandler getEmployeeUpdateQueryHandler, UpdateEmployeeCommandHandler updateEmployeeCommandHandler)
        {
            _getEmployeeQueryHandler = getEmployeeQueryHandler;
            _getEmployeeByIDQueryHandler = getEmployeeByIDQueryHandler;
            _createEmployeeCommandHandler = createEmployeeCommandHandler;
            _removeEmployeeCommandHandler = removeEmployeeCommandHandler;
            _getEmployeeUpdateQueryHandler = getEmployeeUpdateQueryHandler;
            _updateEmployeeCommandHandler = updateEmployeeCommandHandler;
        }

        public IActionResult Index()
        {
            var values = _getEmployeeQueryHandler.Handle();
            return View(values);
        }
        public IActionResult DetailEmployee(int id)
        {
            var values = _getEmployeeByIDQueryHandler.Handle(new GetEmployeeByIDQuery(id));
            return View(values);
        }
        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddEmployee(CreateEmployeeCommand command)
        {
            _createEmployeeCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteEmployee(int id)
        {
            _removeEmployeeCommandHandler.Handle(new RemoveEmployeeCommand(id));
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateEmployee(int id)
        {
           var values = _getEmployeeUpdateQueryHandler.Handle(new GetEmployeeUpdateQuery(id));
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateEmployee(UpdateEmployeeCommand command)
        {
            _updateEmployeeCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }
    }
}
