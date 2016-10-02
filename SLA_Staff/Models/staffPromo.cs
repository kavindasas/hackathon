using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLA_Staff.Models
{
    public class staffPromo
    {
        int pkey;
        string id;
        string date;
        string promoFrom;
        string promoTo;

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }

        public string PromoFrom
        {
            get
            {
                return promoFrom;
            }

            set
            {
                promoFrom = value;
            }
        }

        public string PromoTo
        {
            get
            {
                return promoTo;
            }

            set
            {
                promoTo = value;
            }
        }

        public int Pkey
        {
            get
            {
                return pkey;
            }

            set
            {
                pkey = value;
            }
        }
    }
}

