using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP
{
    public interface IPessoa
    {
        void Cadastrar();
        Pessoa Buscar();
    }
    public class Pessoa : IPessoa
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public Pessoa Buscar()
        {
            return new Pessoa
            {
                Nome = "Andre",
                Sobrenome = "Pereira Silva"
            };
        }

        public void Cadastrar()
        {
            throw new Exception("Testando");
        }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
