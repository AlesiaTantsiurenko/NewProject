using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject
{
    public class Address
    {
        private string _country;
        public Address(string country)
        {
            this._country = country;
        }
        public string Country
        {
            get => _country;
            set => _country = value;
        }
    }
}
