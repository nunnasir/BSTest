using BSTest.Data;
using BSTest.Framework.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSTest.Framework.UnitOfWorks
{
    public interface IBsTestUnitOfWork : IUnitOfWork
    {
        IPostRepository PostRepository { get; set; }
        ICommentRepository CommentRepository { get; set; }
    }
}
