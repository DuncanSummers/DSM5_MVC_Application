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
                    Subcategory = model.Subcategory,
                    Symptoms = model.Symptoms
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
                            Subcategory = e.Subcategory,
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
                    Subcategory = entity.Subcategory,
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
                entity.Subcategory = model.Subcategory;
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
