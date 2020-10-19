using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Basket.Helper
{
    public interface IReader<T>
    {
        Assembly Assembly { get; set; }
        T Read(string jsonName);
    }
}
