using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDeveloper.CrossCutting
{

    public class InstanceResolver
    {
        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }

        private static StandardKernel _kernel;

        public static StandardKernel Kernel
        {
            get
            {
                if (_kernel == null)
                    Resolver();

                return _kernel;
            }
        }

        private static void Resolver()
        {
            _kernel = new StandardKernel();
            DependencyRegister.Resolver(_kernel);

        }
    }
}
