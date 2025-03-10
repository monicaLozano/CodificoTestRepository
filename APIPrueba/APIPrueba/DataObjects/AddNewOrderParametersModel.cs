namespace DataObjects
{
    public class AddNewOrderParametersModel
    {
        public int CustomerID { get; set; }
        public int EmpID {  get; set; } 
        public int ShipperID {  get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public double Freight { get; set; }
        public string ShipCountry { get; set; }
        public int ProductID { get; set; }
        public double UnitPrice {  get; set; }
        public int Qty {  get; set; }
        public double Discount {  get; set; }
    }
}
