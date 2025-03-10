// SalesDatePrediction.Api/Controllers/OrdersController.cs
using BusinessLogic;
using DataLayer;
using DataObjects;
using EncryptDecrypt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SalesDatePrediction.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly ConnectionStrings _conn;
        private readonly IGetDBData_BL _getDBData;
        private ISecurity_BL _security;
        private string _connString { get; set; }
        public OrdersController(ILogger<OrdersController> logger, ConnectionStrings conn)
        {

            _logger = logger;
            _conn = conn;
            
            _security = new Security();
            string s1 = _security.EncryptLongData("Server=DIEGOTORRES\\LOCALSERVERSQLSE;Database=StoreSample;User Id=testuser;Password=monica123;Encrypt=False;TrustServerCertificate=True");
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

        // 1. Listar clientes con fecha de última orden y fecha de posible orden
        [HttpGet("SalesPrediction")]
        public async Task<IEnumerable<SalesDatePredictionModel>> GetSalesPrediction()
        {
            _logger.LogInformation("Obteniendo predicción de ventas.");
            List<SalesDatePredictionModel> result = _getDBData.DatePrediction();
            return result;
        }

        // 2. Listar órdenes por cliente
        [HttpGet("ClientOrders/{customerId}")]
        public async Task<IEnumerable<ClientOrdersModel>> GetClientOrders(int customerId)
        {
            _logger.LogInformation($"Obteniendo órdenes para cliente {customerId}");
            List<ClientOrdersModel> result = _getDBData.ClientOrders(customerId);
            return result;
        }

        // 3. Crear nueva orden con un producto
        [HttpPost("NewOrder")]
        public async Task<IActionResult> AddNewOrder([FromBody] AddNewOrderParametersModel request)
        {
            _logger.LogInformation("Intentando crear una nueva orden.");
            try
            {
                var newOrderId = _getDBData.AddNewOrder(request);
                _logger.LogInformation($"Orden 0creada con ID: {newOrderId}");
                return Ok(new { OrderID = newOrderId });
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error al crear la nueva orden.");
                return BadRequest( "Ha ocurrido un error al crear la orden: " + ex.Message);
            }
        }
    }
}
