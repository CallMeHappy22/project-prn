using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateEvent
{
    public delegate void MyDelegate(object sender, EventArgs e);
    public class Person
    {
        public static event MyDelegate myEvent;
        private string name;

        public string Name { get => name;
            set { this.name = value;
               OnNameChanged(EventArgs.Empty);
            }

        }

        public Person(string name)
        {
            this.name = name;

        }

        public Person()
        {
        }
        public virtual void OnNameChanged(EventArgs args)
        {
            if (myEvent != null) { 
            myEvent(this, args);
            }

        }
    }
}
