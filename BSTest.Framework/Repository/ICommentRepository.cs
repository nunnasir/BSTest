using BSTest.Data;
using BSTest.Framework.Context;
using BSTest.Framework.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSTest.Framework.Repository
{
    public interface ICommentRepository : IRepository<Comment, int, BsTestContext>
    {

    }
}
