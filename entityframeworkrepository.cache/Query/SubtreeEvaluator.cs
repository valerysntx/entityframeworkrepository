using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace entityframeworkrepository.cache.Query
{
    internal static partial class Evaluator
    {
        /// <summary>
        /// Evaluates and replaces sub-trees when first candidate is reached (top-down)
        /// </summary>
        class SubtreeEvaluator : ExpressionVisitor
        {
            HashSet<Expression> candidates;

            internal SubtreeEvaluator(HashSet<Expression> candidates)
            {
                this.candidates = candidates;
            }

            internal Expression Eval(Expression exp)
            {
                return this.Visit(exp);
            }

            public override Expression Visit(Expression exp)
            {
                if (exp == null)
                {
                    return null;
                }
                if (this.candidates.Contains(exp))
                {
                    return this.Evaluate(exp);
                }
                return base.Visit(exp);
            }

            private Expression Evaluate(Expression e)
            {
                if (e.NodeType == ExpressionType.Constant)
                {
                    return e;
                }
                LambdaExpression lambda = Expression.Lambda(e);
                Delegate fn = lambda.Compile();
                return Expression.Constant(fn.DynamicInvoke(null), e.Type);
            }

            protected override Expression VisitMemberInit(MemberInitExpression node)
            {
                if (node.NewExpression.NodeType == ExpressionType.New)
                    return node;

                return base.VisitMemberInit(node);
            }
        }
    }
}