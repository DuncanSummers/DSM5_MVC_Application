using DSM5.Data;
using DSM5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSM5.Services
{
    public class ComorbidityService
    {
        private readonly Guid _userID;

        public ComorbidityService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreateComorbidity(ComorbidityCreate model)
        {
            var entity =
                new Comorbidity()
                {
                    BaseID = model.BaseID,
                    ComorbidityID = model.ComorbidityID
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comorbidities.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ComorbidityListItem> GetComorbidity()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comorbidities
                        .Select(e => new ComorbidityListItem()
                        {
                            BaseID = e.BaseID,
                            ComorbidityID = e.ComorbidityID
                        });
                return query.ToArray();
            }
        }

        public ComorbidityDetail GetComorbidityByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comorbidities
                        .Single(e => e.BaseID == id);
                return new ComorbidityDetail()
                {
                    BaseID = entity.BaseID,
                    ComorbidityID = entity.ComorbidityID
                };
            }
        }

        public bool UpdateComorbidity(ComorbidityEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comorbidities
                        .Single(e => e.BaseID == model.BaseID);

                entity.BaseID = model.BaseID;
                entity.ComorbidityID = model.ComorbidityID;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteComorbidity(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comorbidities
                        .Single(e => e.BaseID == id);

                ctx.Comorbidities.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
