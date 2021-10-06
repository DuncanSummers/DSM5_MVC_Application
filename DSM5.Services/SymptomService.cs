using DSM5.Data;
using DSM5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSM5.Services
{
    public class SymptomService
    {
        private readonly Guid _userId;

        public SymptomService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateSymptom(SymptomCreate model)
        {
            var entity =
                new Symptom()
                {
                    Description = model.Description,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Symptoms.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SymptomListItem> GetSymptom()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Symptoms
                        .Select(e => new SymptomListItem
                        {
                            SymptomID = e.SymptomID,
                            Description = e.Description
                        });
                return query.ToArray();
            }
        }

        public SymptomDetail GetSymptomByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Symptoms
                        .Single(e => e.SymptomID == id);
                return new SymptomDetail()
                {
                    SymptomID = entity.SymptomID,
                    Description = entity.Description
                };
            }
        }

        public bool UpdateSymptom(SymptomEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Symptoms
                        .Single(e => e.SymptomID == model.SymptomID);

                entity.Description = model.Description;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteSymptom(int symptomID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Symptoms
                        .Single(e => e.SymptomID == symptomID);

                ctx.Symptoms.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
