namespace HandicraftShop.Catalog.DataAccess;

using System.Linq.Expressions;

public class ExpressionFieldDefinition<TDocument, TField>
{
    public ExpressionFieldDefinition(LambdaExpression expression, TField value)
    {
        Expression = expression;
        Value = value;
    }

    public LambdaExpression Expression { get; }
    public TField Value { get; }

}