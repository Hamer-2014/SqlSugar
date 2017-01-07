﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
namespace SqlSugar
{
    public class LambdaExpressionResolve : BaseResolve
    {
        public LambdaExpressionResolve(Expression exp) : base(exp)
        {
            LambdaExpression lambda = exp as LambdaExpression;
            var expression = lambda.Body;
            if (expression.NodeType == ExpressionType.MemberAccess)
            {
                base.SqlWhere = "(" + ((MemberExpression)expression).Member.Name + "=1)";
                base.IsFinished = true;
            }
            base.Expression = expression;
            base.Continue();
        }
    }
}