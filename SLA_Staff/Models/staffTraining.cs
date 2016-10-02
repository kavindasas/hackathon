using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLA_Staff.Models
{
    public class staffTraining
    {
        int pkey;
        string id;
        string trainingDate;
        string trainigEnd;
        string desc;

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

        public string TrainingDate
        {
            get
            {
                return trainingDate;
            }

            set
            {
                trainingDate = value;
            }
        }

        public string TrainigEnd
        {
            get
            {
                return trainigEnd;
            }

            set
            {
                trainigEnd = value;
            }
        }

        public string Desc
        {
            get
            {
                return desc;
            }

            set
            {
                desc = value;
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

