using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.AX.Models {
    public class PersonViewModel {
        public IEnumerable<Person> People { get; set; }
        public Person Person { get; set; }
    }
}