using BSTest.Framework.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSTest.Models
{
    public class CommentModel : CommentBaseModel
    {
        public CommentModel(ICommentService commentService) : base(commentService) { }
        public CommentModel() : base() { }

        internal object GetComments(DataTableAjaxRequestModel tableModel)
        {
            var data = _commentService.GetComments(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new string[] { "CommentText", "Post.Title", "UserName", "Created_at" }));

            return new
            {
                recrecordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.CommentText,
                            record.Post.Title,
                            record.UserName,
                            record.Created_at.ToLocalTime().ToString("dd/MM/yyyyy"),
                            record.Like.ToString() + "," + record.DisLike.ToString() + "," + record.Id.ToString()
                        }).ToArray()
            };
        }

        public void LikeComment(int id)
        {
            _commentService.LikeComment(id);
        }

        public void DisLikeComment(int id)
        {
            _commentService.DisLikeComment(id);
        }

    }
}
