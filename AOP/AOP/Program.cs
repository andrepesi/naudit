using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = NinjectConfig.Load();
            ICalculator calculator = kernel.Get<ICalculator>();
            IPessoa pessoa = kernel.Get<IPessoa>();
            // var binding = new Bind<ICalculator>().;

            // var b = new ContainerBuilder();
            // b.Register(i => new Logger(Console.Out));
            // b.RegisterType<Calculator>().As<ICalculator>();
            ////.EnableInterfaceInterceptors().InterceptedBy(typeof(Logger));
            // var container = b.Build();
            // // var proxyGenerator = new ProxyGenerator();

            // var calc = container.Resolve<Calculator>();

            // //var proxyGenerator = new ProxyGenerator();
            // //proxyGenerator.
            // ICalculator calculator = new Calculator();

            // //var proxy = proxyGenerator.CreateInterfaceProxyWithTarget(
            // //    calculator,
            // //    ProxyGenerationOptions.Default,
            // //    new Logger(Console.Out));

            calculator.add(1, 2);

            pessoa.Buscar();

            pessoa.Cadastrar();
            
            // Console.ReadKey();
        }
    }
}
