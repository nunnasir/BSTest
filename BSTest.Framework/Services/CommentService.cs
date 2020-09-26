using BSTest.Framework.Entity;
using BSTest.Framework.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSTest.Framework.Services
{
    public class CommentService : ICommentService
    {
        private IBsTestUnitOfWork _bsTestUnitOfWork;
        public CommentService(IBsTestUnitOfWork bsTestUnitOfWork)
        {
            _bsTestUnitOfWork = bsTestUnitOfWork;
        }

        public void CreateComment(Comment comment)
        {
            _bsTestUnitOfWork.CommentRepository.Add(comment);
            _bsTestUnitOfWork.Save();
        }

        public void DisLikeComment(int id)
        {
            var comment = _bsTestUnitOfWork.CommentRepository.GetById(id);
            comment.DisLike += 1;

            _bsTestUnitOfWork.Save();
        }

        public void Dispose()
        {
            _bsTestUnitOfWork?.Dispose();
        }

        public (IList<Comment> records, int total, int totalDisplay) GetComments(int pageIndex, int pageSize, string searchText, string sortText)
        {
            if (searchText != "")
                return _bsTestUnitOfWork.CommentRepository.GetDynamic(
                    c => c.Post.Title.Contains(searchText) || c.UserName.Contains(searchText) || c.CommentText.Contains(searchText),
                    sortText, c => c.Include(p => p.Post), pageIndex, pageSize, false);
            else
                return _bsTestUnitOfWork.CommentRepository.GetDynamic(null, sortText, c => c.Include(p => p.Post), pageIndex, pageSize, false);
        }

        public void LikeComment(int id)
        {
            var comment = _bsTestUnitOfWork.CommentRepository.GetById(id);
            comment.Like += 1;

            _bsTestUnitOfWork.Save();
        }
    }
}
