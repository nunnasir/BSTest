using BSTest.Framework.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSTest.Framework.Services
{
    public interface ICommentService : IDisposable
    {
        (IList<Comment> records, int total, int totalDisplay) GetComments(int pageIndex, int pageSize, string searchText, string sortText);
        void CreateComment(Comment comment);
        void LikeComment(int id);
        void DisLikeComment(int id);
    }
}
