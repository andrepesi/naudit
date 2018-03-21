//using Castle.DynamicProxy;
using Ninject.Extensions.Interception;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP
{
    public class Logger : IInterceptor
    {
        TextWriter writer;
        public Logger()
        {
            this.writer = Console.Out;
      }
        public void Intercept(IInvocation invocation)
        {
            var name = $"{invocation.Request.Method.DeclaringType}.{invocation.Request.Method.Name}";
            var args = string.Join(", ", invocation.Request.Arguments.Select(a => (a ?? "").ToString())); writer.WriteLine($"Calling: {name}");
                    writer.WriteLine($"Args: {args}");
            var watch = System.Diagnostics.Stopwatch.StartNew();
                    invocation.Proceed(); //Intercepted method is executed here.
                    watch.Stop();
            var executionTime = watch.ElapsedMilliseconds;

            writer.WriteLine($"Done: result was {invocation.ReturnValue}");
            writer.WriteLine($"Execution Time: {executionTime} ms.");
            writer.WriteLine();
        }
    }
}
