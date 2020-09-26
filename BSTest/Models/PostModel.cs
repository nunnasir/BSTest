using BSTest.Framework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSTest.Models
{
    public class PostModel : PostBaseModel
    {
        public PostModel(IPostService postService) : base(postService) { }
        public PostModel() : base() { }

        internal object GetPosts(DataTableAjaxRequestModel tableModel)
        {
            var data = _postService.GetPosts(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new string[] { "Title", "User", "Created_at", "Comments.Count" }));

            return new
            {
                recrecordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.Title,
                            record.User,
                            record.Created_at.ToLocalTime().ToString("dd/MM/yyyyy"),
                            record.Comments.Count.ToString() + " Comments",
                            record.Id.ToString()
                        }).ToArray()
            };
        }

    }
}
