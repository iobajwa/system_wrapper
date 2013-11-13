using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemInterface
{
    public interface IActivator
    {
        object CreateInstance(Type type, params object[] args);
    }
}
