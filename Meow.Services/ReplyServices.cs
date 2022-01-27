using Meow.Data;
using Meow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meow.Services
{
    public class ReplyService
    {
        private readonly Guid _userId;
        public ReplyService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateReply(ReplyCreate model)
        {
            var entity =
                new Reply()
                {
                    CatOwnerId = _userId,
                    PawstReplyTitle = model.PawstReplyTitle,
                    Catent = model.Catent,
                    CreatedUtc = DateTimeOffset.Now,
                    CatmentId = model.CatmentId
                };

            using (var ctx = new ApplicationDbContext())    
            {
                ctx.Replies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ReplyListItem> GetReplies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Replies
                    .Where(e => e.CatOwnerId == _userId) 
                    .Select(
                        e =>
                            new ReplyListItem
                            {
                                PawstReplyId = e.PawstReplyId,
                                PawstReplyTitle = e.PawstReplyTitle,
                                CreatedUtc = e.CreatedUtc
                            }
                            );

                return query.ToArray();
            }
        }

        public ReplyDetail GetReplyById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Replies
                    .Single(e => e.PawstReplyId == id && e.CatOwnerId == _userId);
                return
                    new ReplyDetail
                    {
                        PawstReplyId = entity.PawstReplyId,
                        PawstReplyTitle = entity.PawstReplyTitle,
                        Catent = entity.Catent,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdateReply(ReplyEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Replies
                    .Single(e => e.PawstReplyId == model.PawstReplyId && e.CatOwnerId == _userId);
                entity.PawstReplyTitle = model.PawstReplyTitle;
                entity.Catent = model.Catent;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }

        }
        public bool DeleteReply(int pawstReplyId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Replies
                    .Single(e => e.PawstReplyId == pawstReplyId && e.CatOwnerId == _userId);
                ctx.Replies.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }




    }
}
