using Autofac.Extras.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP
{
    public interface ICalculator
    {
        int add(int a, int b);
    }
    [Intercept(typeof(Logger))]
    public class Calculator : ICalculator
    {
        public virtual int add(int a, int b)
        {
            return a + b;
        }
    }
}
