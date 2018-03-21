using Ninject.Extensions.Interception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP
{
    public class ExceptionLogger : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                Context c = new Context();
                Log log = new Log();
                var logs = c.Logs.ToList();
                var sb = new StringBuilder();
                log.Source = $"{invocation.Request.Target.GetType().Name}.{invocation.Request.Method.Name}";

                //sb.AppendFormat("Executing {0}.{1} (", invocation.Request.Target.GetType().Name, invocation.Request.Method.Name);
                var parameters = invocation.Request.Method.GetParameters();
                //string param = parameters.Select(x => new { value = $"{x.Name}={}"  });
                for (int i = 0; i < invocation.Request.Arguments.Length; ++i)
                {
                    sb.AppendFormat("{0}={1},", parameters[i].Name, invocation.Request.Arguments[i]);
                }
                sb.Clear();
                log.Result = sb.ToString();
                log.Data = DateTime.Now;

                sb.AppendFormat(") {0} caught: {1})", e.GetType().Name, e.Message);
                log.Result = e.StackTrace;
                log.Message = sb.ToString();
                //_logFactory.Error(sb.ToString());
                c.Logs.Add(log);
                c.SaveChanges();
               // throw e;
            }
        }
    }
}
