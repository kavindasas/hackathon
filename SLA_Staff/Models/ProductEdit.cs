using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLA_Staff.Models
{
    public class ProductEdit
    {
        int ID;
        string Name;
        int qty;
        int price;

        public int ID1
        {
            get
            {
                return ID;
            }

            set
            {
                ID = value;
            }
        }

        public string Name1
        {
            get
            {
                return Name;
            }

            set
            {
                Name = value;
            }
        }

        public int Qty
        {
            get
            {
                return qty;
            }

            set
            {
                qty = value;
            }
        }

        public int Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }


       
    }
}