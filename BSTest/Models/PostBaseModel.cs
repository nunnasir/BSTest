using Autofac;
using BSTest.Framework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSTest.Models
{
    public class PostBaseModel: IDisposable
    {
        protected readonly IPostService _postService;
        public PostBaseModel(IPostService postService)
        {
            _postService = postService;
        }
        public PostBaseModel()
        {
            _postService = Startup.AutofacContainer.Resolve<IPostService>();
        }
        public void Dispose()
        {
            _postService?.Dispose();
        }
    }
}
