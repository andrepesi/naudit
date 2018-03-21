using Ninject;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP
{
    public class NinjectConfig
    {

        public static IKernel Load()
        {
            return new StandardKernel(new NinjectSettings { LoadExtensions = true },new Module());
        }
    }
    public class Module : NinjectModule
    {

        public override void Load()
        {
            Kernel.Intercept(context => true).With<Logger>();
            Kernel.Intercept(context => true).With<ExceptionLogger>();
            Bind<ICalculator>().To<Calculator>();
            Bind<IPessoa>().To<Pessoa>();
            //Bind<TextWriter>().ToMethod(x=> Console.Out);

        }
    }
}
