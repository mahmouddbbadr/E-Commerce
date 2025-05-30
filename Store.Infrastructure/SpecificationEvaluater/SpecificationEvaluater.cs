﻿using Microsoft.EntityFrameworkCore;
using Store.Core.Entities;
using Store.Core.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infrastructure.SpecificationEvaluater
{
    public class SpecificationEvaluater<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> specification)
        {
            var query = inputQuery;
            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }

            query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }
    }
}
