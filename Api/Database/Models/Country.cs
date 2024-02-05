using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.ViewModels
{
    public class Country : BaseModel
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public Country(int id, string name)
        {
            Id = id;
            CountryName = name;
        }
        public Country() { }
    }
}
