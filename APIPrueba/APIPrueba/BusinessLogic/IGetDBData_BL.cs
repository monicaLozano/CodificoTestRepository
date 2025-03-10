using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface IGetDBData_BL
    {
        int AddNewOrder(AddNewOrderParametersModel newOrder);
        List<ClientOrdersModel> ClientOrders(int customerID);
        List<EmployeesModel> employees();
        List<ProductsModel> Products();
        List<SalesDatePredictionModel> DatePrediction();
        List<ShippersModel> GetShippers();
    }
}
