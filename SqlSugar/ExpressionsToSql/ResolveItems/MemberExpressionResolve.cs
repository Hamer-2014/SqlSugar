﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
namespace SqlSugar
{
    public class MemberExpressionResolve : BaseResolve
    {
        public MemberExpressionResolve(ExpressionParameter parameter) : base(parameter)
        {
            var expression = base.Expression as MemberExpression;
            var isLeft = parameter.IsLeft;
            var isSingle = parameter.Context.IsSingle;
            string fieldName = string.Empty;
            fieldName = isSingle ? expression.Member.Name : expression.Member.ToString();
            parameter.BaseParameter.TempData.Add(ExpConst.FiledName, fieldName);
            if (isLeft == null && base.SqlWhere == null)
            {
                base.SqlWhere = fieldName;
            }
        }
    }
}