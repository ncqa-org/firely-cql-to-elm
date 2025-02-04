﻿using System.Linq.Expressions;
using Hl7.Cql.Compiler;
using Hl7.Cql.Fhir;
using Hl7.Cql.Runtime;
using Hl7.Fhir.Model;
using Microsoft.Extensions.Logging;
using Expression = System.Linq.Expressions.Expression;
using Library = Hl7.Cql.Elm.Library;

namespace Hl7.Cql.Packaging
{
    /// <summary>
    /// Helpers for ELM Libraries
    /// </summary>
    public static class ElmLibraryExtensions
    {
        /// <summary>
        /// Evaluate the given expression for the given library and context
        /// </summary>
        /// <param name="library">the library</param>
        /// <param name="expression">the expression to evaluate</param>
        /// <param name="context">the context of the expression evaluation</param>
        /// <param name="logFactory">logger</param>
        /// <returns>the result of the expression</returns>
        public static object? EvaluateExpression(this Library library, Elm.Expression expression, CqlContext context, ILoggerFactory logFactory)
        {
            var builderLogger = logFactory.CreateLogger<ExpressionBuilder>();
            var typeResolver = new FhirTypeResolver(ModelInfo.ModelInspector);
            var builder = new ExpressionBuilder(
                new CqlOperatorsBinding(typeResolver, FhirTypeConverter.Create(ModelInfo.ModelInspector)),
                new TypeManager(typeResolver),
                library!, builderLogger, new(false));
            DefinitionDictionary<LambdaExpression> lambdas = new DefinitionDictionary<LambdaExpression>();
            var parameter = Expression.Parameter(typeof(CqlContext), "rtx");
            ExpressionBuilderContext? ctx = new ExpressionBuilderContext(builder, parameter, lambdas, new Dictionary<string, string>());
            var translated = builder.TranslateExpression(expression, ctx);
            var lambda = Expression.Lambda(translated, parameter);
            var func = lambda.Compile();
            return func.DynamicInvoke(context);
        }
    }
}
