using BSTest.Data;
using BSTest.Framework.Context;
using BSTest.Framework.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSTest.Framework.Repository
{
    public class PostRepository : Repository<Post, int, BsTestContext>, IPostRepository
    {
        public PostRepository(BsTestContext context) : base(context) { }
    }
}
