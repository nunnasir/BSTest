using Autofac;
using BSTest.Framework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSTest.Models
{
    public class CommentBaseModel : IDisposable
    {
        protected readonly ICommentService _commentService;
        public CommentBaseModel(ICommentService commentService)
        {
            _commentService = commentService;
        }
        public CommentBaseModel()
        {
            _commentService = Startup.AutofacContainer.Resolve<ICommentService>();
        }
        public void Dispose()
        {
            _commentService?.Dispose();
        }
    }
}
