using DSM5.Data;
using DSM5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSM5.Services
{

    public class DisorderService
    {    
        private readonly Guid _userId;

        public DisorderService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateDisorder(DisorderCreate model)
        {
            var entity =
                new Disorder()
                {
                    DisorderName = model.DisorderName,
                    ICD = model.ICD,
                    Category = model.Category,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Disorders.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<DisorderListItem> GetDisorders()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Disorders
                        .Select(e => new DisorderListItem
                        {
                            DisorderID = e.DisorderID,
                            ICD = e.ICD,
                            Category = e.Category,
                            DisorderName = e.DisorderName,
                            Symptoms = e.Symptoms,
                            Comorbidities = e.Comorbidities
                        }
                        );
                return query.ToArray();
            }
        }

        public DisorderDetail GetDisorderByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Disorders
                        .Single(e => e.DisorderID == id);
                return new DisorderDetail
                {
                    DisorderID = entity.DisorderID,
                    ICD = entity.ICD,
                    Category = entity.Category,
                    DisorderName = entity.DisorderName,
                    Symptoms = entity.Symptoms,
                    Comorbidities = entity.Comorbidities
                };
            }
        }

        public bool UpdateDisorder(DisorderEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Disorders
                        .Single(e => e.DisorderID == model.DisorderID);

                entity.ICD = model.ICD;
                entity.Category = model.Category;
                entity.DisorderName = model.DisorderName;
                entity.Symptoms = model.Symptoms;
                entity.Comorbidities = model.Comorbidities;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteDisorder(int disorderID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Disorders
                        .Single(e => e.DisorderID == disorderID);

                ctx.Disorders.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
