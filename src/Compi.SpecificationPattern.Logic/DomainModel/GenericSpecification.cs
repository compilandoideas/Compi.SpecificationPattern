using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Compi.SpecificationPattern.Logic.DomainModel
{
    public class GenericSpecification<T>
    {
        public Expression<Func<T, bool>> Expression { get; }


        public GenericSpecification(Expression<Func<T, bool>> expression)
        {
            Expression = expression ??
                throw new ArgumentNullException(nameof(expression));

        }


        public bool IsSatisfied(T entity)
        {
            return Expression.Compile().Invoke(entity);
        }
    }
}
