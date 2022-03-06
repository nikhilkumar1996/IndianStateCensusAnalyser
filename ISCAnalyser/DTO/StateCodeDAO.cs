using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCAnalyser.POCO
{
    public class StateCodeDAO
    {
        public int serialNumber;
        public string stateName;
        public int tin;
        public string stateCode;

        public StateCodeDAO(string srnum, string sname, string tin, string scode)
        {
            this.serialNumber = Convert.ToInt32(srnum);
            this.stateName = sname;
            this.tin = Convert.ToInt32(tin);
            this.stateCode = scode;
        }

    }
}