using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateEvent
{
    public class TestEvent
    {
        private Person person;

        public TestEvent()
        {
        }

        public TestEvent(Person person)
        {
            this.person = person;
            Person.myEvent += new MyDelegate(NameChange);
        }

        public  void NameChange(object sender, EventArgs e)
        {
            Console.WriteLine("Name of person has changed!");
        }
    }
}
