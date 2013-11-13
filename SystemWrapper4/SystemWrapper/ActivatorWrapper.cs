using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SystemInterface;

namespace SystemWrapper
{
    public class ActivatorWrapper : IActivator
    {
        public object CreateInstance(Type type, params object[] args)
        {
            return Activator.CreateInstance(type, args);
        }
    }
}
