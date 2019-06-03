using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDeveloper.CrossCutting;

namespace WebDeveloperTest.IoC
{
    public class DependenceResolver
    {
        public static void Resolver(IKernel kernel)
        {
            DependencyRegister.Resolver(kernel);
        }
    }
}
