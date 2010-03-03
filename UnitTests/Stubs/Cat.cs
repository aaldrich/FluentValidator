using System.Collections.Generic;

namespace Validation.UnitTests.Stubs
{
    public class Cat
    {
        public long id { get; set; }
        public string name { get; set; }
        public IList<Cat> kittens { get; set; }
        //public Cat mother { get; set; }
    }
}