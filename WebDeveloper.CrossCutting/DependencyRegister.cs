using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDeveloperTest.Data.Repositories;
using WebDeveloperTest.Domain.Repositories;

namespace WebDeveloper.CrossCutting
{
    public static class DependencyRegister
    {
        public static void Resolver(IKernel kernel)
        {
            ResolverRepository(kernel);
        }
        //public static void ResolverContext(IKernel kernel)
        //{
        //    kernel.Bind<LvcContext>().To<LvcContext>();
        //    kernel.Bind<LvcPublicoContext>().To<LvcPublicoContext>();
        //    kernel.Bind<LvcDapperContext>().To<LvcDapperContext>();
        //    kernel.Bind<LvcGerencialContext>().To<LvcGerencialContext>();
        //}
        //public static void ResolverService(IKernel kernel)
        //{
        //    kernel.Bind<IUsuarioService>().To<UsuarioService>();

        //}
        public static void ResolverRepository(IKernel kernel)
        {

            kernel.Bind<IEventRepository>().To<EventRepository>();
        }
    }
}
