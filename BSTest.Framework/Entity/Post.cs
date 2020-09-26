using BSTest.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSTest.Framework.Entity
{
    public class Post : IEntity<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string User { get; set; }
        public DateTime Created_at { get; set; }
        public IList<Comment> Comments { get; set; }
    }
}
