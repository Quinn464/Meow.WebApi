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
                    TextPawst = model.Content,
                    CreatedUtc = DateTimeOffset.Now,
                };

            using (var ctx = new ApplicationDbContext())    // allows us to close the connection to the database right here
                                                            // when the DbContext is connected and we will be using it for something
            {
                ctx.Replies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ReplyListItem> GetReplies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                // var ownerIdGuid = Guid.Parse(ownerId);
                var query =
                    ctx
                    .Replies
                    // .DefaultIfEmpty()
                    .Where(e => e.CatOwnerId == _userId) // Where(note => note.OwnerId == ownerIdGuid);
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
                        PawstId = entity.PawstReplyId,
                        Title = entity.PawstReplyTitle,
                        Content = entity.Catent,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }




    }
}
