using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicViewModel
{
    class Person : DynamicViewModel<Person>
    {
        public Person(Person model) : base(model)
        {
        }

        public Person(Func<Person> @delegate) : base(@delegate)
        {
        }
    }
}
