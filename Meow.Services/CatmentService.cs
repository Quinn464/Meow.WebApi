using Meow.Data;
using Meow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meow.Services
{
    public class CatmentService
    {
        private readonly Guid _userId;

        public CatmentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCatment(CatmentCreate model)
        {
            var entity =
                new Catment()
                {
                    AuthorId = _userId,
                    ContentCatment = model.ContentCatment,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Catments.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        public IEnumerable<CatmentListItem> GetCatmentsGet()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Catments
                    .Where(e => e.AuthorId == _userId)
                    .Select(
                        e =>
                        new CatmentListItem
                        {
                            CatmentId = e.CatmentId,
                            ContentCatment = e.ContentCatment,
                            CreatedUtc = e.CreatedUtc
                        }
                     );

                return query.ToArray();
            }
        }

        public CatmentDetail GetCatmentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Catments
                    .Single(e => e.CatmentId == id && e.AuthorId == _userId);
                return
                    new CatmentDetail
                    {
                        CatmentId = entity.CatmentId,
                        AuthorId = entity.AuthorId,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdateCatment(CatmentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Catments
                    .Single(e => e.CatmentId == model.CatmentId && e.AuthorId == _userId);

                entity.ContentCatment = model.ContentCatment;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCatment(int catemntsId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Catments
                    .Single(e => e.CatmentId == catemntsId && e.AuthorId == _userId);

                ctx.Catments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }

        }

    }
}
