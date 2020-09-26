using BSTest.Framework.Entity;
using BSTest.Framework.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSTest.Framework.Services
{
    public class PostService : IPostService
    {
        private IBsTestUnitOfWork _bsTestUnitOfWork;
        public PostService(IBsTestUnitOfWork bsTestUnitOfWork)
        {
            _bsTestUnitOfWork = bsTestUnitOfWork;
        }

        public void CreatePost(Post post)
        {
            _bsTestUnitOfWork.PostRepository.Add(post);
            _bsTestUnitOfWork.Save();
        }

        public void Dispose()
        {
            _bsTestUnitOfWork?.Dispose();
        }

        public (IList<Post> records, int total, int totalDisplay) GetPosts(int pageIndex, int pageSize, string searchText, string sortText)
        {
            if (searchText != "")
                return _bsTestUnitOfWork.PostRepository.GetDynamic(
                    c => c.Title.Contains(searchText),
                    sortText, c => c.Include(p => p.Comments), pageIndex, pageSize, false);
            else
                return _bsTestUnitOfWork.PostRepository.GetDynamic(null, sortText, c => c.Include(p => p.Comments), pageIndex, pageSize, false);
        }
    }
}
