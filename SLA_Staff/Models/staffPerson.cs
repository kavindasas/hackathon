using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLA_Staff.Models
{
    public class staffPerson
    {
        string id;
        string name;
        string Pname;
        string costC;
        string designation;
        string grade;
        string companyJoined;
        string deptJoined;
        staffPromo promotions;
        staffTraining trainings;
        string NoPay;
        string availability;

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

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Pname1
        {
            get
            {
                return Pname;
            }

            set
            {
                Pname = value;
            }
        }

        public string CostC
        {
            get
            {
                return costC;
            }

            set
            {
                costC = value;
            }
        }

        public string Designation
        {
            get
            {
                return designation;
            }

            set
            {
                designation = value;
            }
        }

        public string Grade
        {
            get
            {
                return grade;
            }

            set
            {
                grade = value;
            }
        }

        public string CompanyJoined
        {
            get
            {
                return companyJoined;
            }

            set
            {
                companyJoined = value;
            }
        }

        public string DeptJoined
        {
            get
            {
                return deptJoined;
            }

            set
            {
                deptJoined = value;
            }
        }

        public string NoPay1
        {
            get
            {
                return NoPay;
            }

            set
            {
                NoPay = value;
            }
        }

        public string Availability
        {
            get
            {
                return availability;
            }

            set
            {
                availability = value;
            }
        }

        public staffPromo Promotions
        {
            get
            {
                return promotions;
            }

            set
            {
                promotions = value;
            }
        }

        public staffTraining Trainings
        {
            get
            {
                return trainings;
            }

            set
            {
                trainings = value;
            }
        }

    }
}

