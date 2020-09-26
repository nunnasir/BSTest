using BSTest.Data;
using BSTest.Framework.Context;
using BSTest.Framework.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSTest.Framework.UnitOfWorks
{
    public class BsTestUnitOfWork : UnitOfWork, IBsTestUnitOfWork
    {
        public IPostRepository PostRepository { get; set; }
        public ICommentRepository CommentRepository { get; set; }

        public BsTestUnitOfWork(BsTestContext dbContext,
            IPostRepository postRepository,
            ICommentRepository commentRepository)
            : base(dbContext)
        {
            PostRepository = postRepository;
            CommentRepository = commentRepository;
        }
    }
}
