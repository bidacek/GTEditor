using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLib
{
	interface IOriginator
	{
		IMemento GetMemento();
		IMemento SetMemento(IMemento memento);
	}


	class IMemento { }
}
