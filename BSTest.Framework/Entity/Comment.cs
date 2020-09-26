using BSTest.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSTest.Framework.Entity
{
    public class Comment : IEntity<int>
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public string UserName { get; set; }
        public Post Post { get; set; }
        public int PostId { get; set; }
        public int Like { get; set; }
        public int DisLike { get; set; }
        public DateTime Created_at { get; set; }
    }
}
