namespace MyLinq
{
    public static class MyFirstOrDefault
    {
        public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source, TSource defaultValue)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            using (IEnumerator<TSource> iterator = source.GetEnumerator())
            {
                return iterator.MoveNext() ? iterator.Current : default(TSource);
            }
        }

        public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, TSource defaultValue)
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
            return default(TSource);
        }
    }
}
