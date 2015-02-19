namespace CarrotCake.Web.Api
{
    using System.Web.Http;
    using Data.Dapper;
    using Microsoft.Practices.Unity;
    using Unity.WebApi;
    using Data;
    using Data.Ef;
    using Data.Sql;

    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // You can only enable one of the following injections:

            // To enable Native SQL as the ORM, uncomment this line
            //container.RegisterType<IDataContextFactory, SqlDataContextFactory>();

            // To enable Dapper as the ORM, uncomment this line
            //container.RegisterType<IDataContextFactory, DapperDataContextFactory>();

            // To enable EF6 as the ORM, uncomment this line
            container.RegisterType<IDataContextFactory, EFDataContextFactory>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}