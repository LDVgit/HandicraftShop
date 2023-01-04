namespace HandicraftShop.Extensions;

/// <summary> Enumerable Extensions. </summary>
public static class EnumerableExtensions
{
    /// <summary>
    /// Call action for enumeration.
    /// </summary>
    /// <param name="enumeration"> Enumeration. </param>
    /// <param name="action"> Action. </param>
    /// <typeparam name="T"> Type. </typeparam>
    public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
    {
        foreach (T obj in enumeration)
            action(obj);
    }
}