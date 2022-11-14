using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject
{
    public class Human
    {
        private string _name;
        private int _age;
        private Address _address;
        public Human(string name, int age, Address address)
        {
            this._name = name;
            this._age = age;
            this._address = address;
        }
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public int Age
        {
            get => _age;
            set => _age = value;
        }
        public String Country
        {
            get => _address.Country;
            set => _address.Country = value;
        }
    }
}
