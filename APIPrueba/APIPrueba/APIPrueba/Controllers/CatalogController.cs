using BusinessLogic;
using DataLayer;
using DataObjects;
using EncryptDecrypt;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Api.Controllers;

namespace APIPrueba.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly ILogger<CatalogController> _logger;
        private readonly ConnectionStrings _conn;
        private readonly IGetDBData_BL _getDBData;
        private ISecurity_BL _security;
        private string _connString { get; set; }

        public CatalogController(ILogger<CatalogController> logger, ConnectionStrings conn)
        {
            _logger = logger;
            _conn = conn;
            _security = new Security();
            string encriptValue = _security.EncryptLongData("Connection string to encrypt");
            if (_conn.ConnectionType == "1")
            {
                _connString = _security.DecryptLongData(_conn.DevConnection);
            }
            if (_conn.ConnectionType == "2")
            {
                _connString = _security.DecryptLongData(_conn.ProdConnection);
            }
            _getDBData = new GetDBData_DL(_connString);
        }

        [HttpGet("Employees")]
        public async Task<IEnumerable<EmployeesModel>> GetEmployees()
        {
            List<EmployeesModel> employees = _getDBData.employees();
            return employees;
        }

        [HttpGet("Shippers")]
        public async Task<IEnumerable<ShippersModel>> GetShippers()
        {
            List<ShippersModel> shippers = _getDBData.GetShippers();
            return shippers;
        }

        [HttpGet("Products")]
        public async Task<IEnumerable<ProductsModel>> GetProducts()
        {
            List<ProductsModel> products = _getDBData.Products();
            return products;
        }
    }

}
