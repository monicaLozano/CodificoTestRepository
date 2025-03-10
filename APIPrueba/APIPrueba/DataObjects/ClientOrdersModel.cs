using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class ClientOrdersModel
    {
        int OrderID { get; set; }
        DateTime RequiredDate { get; set; }
        DateTime ShippedDate { get; set; }
        string ShipName { get; set; }
        string ShipAddress { get; set; }
        string ShipCity { get; set; }
    }
}
