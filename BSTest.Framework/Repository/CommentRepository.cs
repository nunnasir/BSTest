using BSTest.Data;
using BSTest.Framework.Context;
using BSTest.Framework.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSTest.Framework.Repository
{
    public class CommentRepository : Repository<Comment, int, BsTestContext>, ICommentRepository
    {
        public CommentRepository(BsTestContext context) : base(context) { }
    }
}
