using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP
{
    public class LogWritter : TextWriter
    {
        public override Encoding Encoding
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
