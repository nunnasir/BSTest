using Autofac;
using BSTest.Framework.Context;
using BSTest.Framework.Repository;
using BSTest.Framework.Services;
using BSTest.Framework.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSTest.Framework.Modules
{
    public class BsTestModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public BsTestModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BsTestContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<BsTestUnitOfWork>().As<IBsTestUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<PostRepository>().As<IPostRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CommentRepository>().As<ICommentRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<PostService>().As<IPostService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CommentService>().As<ICommentService>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
