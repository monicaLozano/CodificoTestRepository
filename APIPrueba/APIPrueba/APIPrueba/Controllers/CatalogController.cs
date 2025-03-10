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
        public IActionResult GetEmployees()
        {
            var employees = _getDBData.employees();
            return Ok(employees);
        }

        [HttpGet("Shippers")]
        public IActionResult GetShippers()
        {
            var shippers = _getDBData.GetShippers();
            return Ok(shippers);
        }

        [HttpGet("Products")]
        public IActionResult GetProducts()
        {
            var products = _getDBData.Products();
            return Ok(products);
        }
    }

}
