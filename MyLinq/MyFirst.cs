namespace MyLinq
{
    public static class MyFirst
    {
        public static TSource First<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            using (IEnumerator<TSource> iterator = source.GetEnumerator())
            {
                if (iterator.MoveNext())
                {
                    return iterator.Current;
                }
                throw new InvalidOperationException("Sequence was empty");
            }
        }
        public static TSource First<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }
            foreach (TSource item in source)
            {
                if (predicate(item))
                {
                    return item;
                }
            }
            throw new InvalidOperationException("No items matched the predicate");
        }
    }
}
