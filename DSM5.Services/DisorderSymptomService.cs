using DSM5.Data;
using DSM5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSM5.Services
{
    public class DisorderSymptomService
    {
        private readonly Guid _userID;

        public DisorderSymptomService(Guid userId)
        {
            _userID = userId;
        }

        public bool CreateDisorderSymptom(DisorderSymptomCreate model)
        {
            var entity =
                new DisorderSymptom()
                {
                    DisorderID = model.DisorderID,
                    SymptomID = model.SymptomID
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.DisorderSymptoms.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<DisorderSymptomListItem> GetDisorderSymptom()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .DisorderSymptoms
                        .Select(e => new DisorderSymptomListItem()
                        {
                            DisorderID = e.DisorderID,
                            SymptomID = e.SymptomID
                        });
                return query.ToArray();
            }
        }

        public DisorderSymptomDetail GetDisorderSymptomByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .DisorderSymptoms
                        .Single(e => e.ID == id);
                return new DisorderSymptomDetail
                {
                    ID = entity.ID,
                    DisorderID = entity.DisorderID,
                    SymptomID = entity.SymptomID
                };
            }
        }

        public bool UpdateDisorderSymptom(DisorderSymptomEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .DisorderSymptoms
                        .Single(e => e.DisorderID == model.DisorderID);

                entity.DisorderID = model.DisorderID;
                entity.SymptomID = model.SymptomID;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteDisorderSymptom(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .DisorderSymptoms
                        .Single(e => e.ID == id);

                ctx.DisorderSymptoms.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
