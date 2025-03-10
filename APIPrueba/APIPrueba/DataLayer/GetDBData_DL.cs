using BusinessLogic;
using Dapper;
using DataObjects;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Net;

namespace DataLayer
{
    public class GetDBData_DL : IGetDBData_BL
    {
        private string _conn;
        public GetDBData_DL(string conn)
        {
            _conn = conn;
        }
        public int AddNewOrder(AddNewOrderParametersModel newOrder) 
        {
            int result = 0;

            try
            {
                using (IDbConnection db = new SqlConnection(_conn))
                {
                    db.Open();
                    result = db.Query<int>("ins_AddNewOrder", new
                    {
                        CustomerID = newOrder.CustomerID,
                        EmpID = newOrder.EmpID,
                        ShipperID = newOrder.ShipperID,
                        ShipName = newOrder.ShipName,
                        ShipAddress = newOrder.ShipAddress,
                        ShipCity = newOrder.ShipCity,
                        OrderDate = newOrder.OrderDate,
                        RequiredDate = newOrder.RequiredDate,
                        ShippedDate = newOrder.ShippedDate,
                        Freight = newOrder.Freight,
                        ShipCountry = newOrder.ShipCountry,
                        ProductID = newOrder.ProductID,
                        UnitPrice = newOrder.UnitPrice,
                        Qty = newOrder.Qty,
                        Discount = newOrder.Discount
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    db.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("It was not possible insert value,  " + ex.Message);
            }

            return result;
        }
        public List<ClientOrdersModel> ClientOrders(int customerID)
        {
            List<ClientOrdersModel> result = new List<ClientOrdersModel>();
            try
            {
                using (IDbConnection db = new SqlConnection(_conn))
                {
                    db.Open();
                    result = db.Query<ClientOrdersModel>("sel_GetClientOrders", new{ CustomerID = customerID }, commandType: CommandType.StoredProcedure).ToList();
                    db.Close();
                }
            }
            catch (Exception ex) 
            {
                throw new Exception("It was not possible insert value,  " + ex.Message);
            }
            return result;
        }
        public List<EmployeesModel> employees()
        {
            List<EmployeesModel> result = new List<EmployeesModel>();
            try
            {
                using (IDbConnection db = new SqlConnection(_conn))
                {
                    db.Open();
                    result = db.Query<EmployeesModel>("sel_GetEmployees", commandType: CommandType.StoredProcedure).ToList();
                    db.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("It was not possible insert value,  " + ex.Message);
            }
            return result;
        }
        public List<ProductsModel> Products() 
        {
            List<ProductsModel> result = new List<ProductsModel>();
            try
            {
                using (IDbConnection db = new SqlConnection(_conn))
                {
                    db.Open();
                    result = db.Query<ProductsModel>("sel_GetProducts", commandType: CommandType.StoredProcedure).ToList();
                    db.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("It was not possible insert value,  " + ex.Message);
            }
            return result;
        }

        public List<SalesDatePredictionModel> DatePrediction()
        {
            List<SalesDatePredictionModel> result = new List<SalesDatePredictionModel>();
            try
            {
                using (IDbConnection db = new SqlConnection(_conn))
                {
                    db.Open();
                    result = db.Query<SalesDatePredictionModel>("sel_GetSalesDatePrediction", commandType: CommandType.StoredProcedure).ToList();
                    db.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("It was not possible insert value,  " + ex.Message);
            }
            return result;
        }
        public List<ShippersModel> GetShippers()
        {
            List<ShippersModel> result = new List<ShippersModel>();
            try
            {
                using (IDbConnection db = new SqlConnection(_conn))
                {
                    db.Open();
                    result = db.Query<ShippersModel>("sel_GetShippers", commandType: CommandType.StoredProcedure).ToList();
                    db.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("It was not possible insert value,  " + ex.Message);
            }
            return result;
        }
    }
}
