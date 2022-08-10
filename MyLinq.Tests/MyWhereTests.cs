namespace MyLinq.Tests
{
    public class MyWhereTests
    {
        
        [Fact]
        public void SimpleFilteringWithQueryExpression()
        {
            int[] source = { 1, 3, 4, 2, 8, 1 };
            var result = from x in source
                         where x < 4
                         select x;
            result.ShouldBe(new[] { 1, 3, 2, 1 });
        }

        [Fact]
        public void EmptySource()
        {
            int[] source = new int[0];
            var result = source.Where(x => x < 4);
            result.ShouldBeEmpty();
        }


        [Fact]
        public void SimpleFiltering()
        {
            int[] source = { 1, 3, 4, 2, 8, 1 };
            var result = source.Where(x => x < 4);
            result.ShouldBe(new[] { 1, 3, 2, 1 });
        }

        [Fact]
        public void NullSourceThrowsNullArgumentException()
        {
            IEnumerable<int> source = null;
            Should.Throw<ArgumentNullException>(() => source.Where(x => x > 5));
        }
        [Fact]
        public void NullPredicateThrowsNullArgumentException()
        {
            int[] source = { 1, 3, 7, 9, 10 };
            Func<int, bool> predicate = null;
            Should.Throw<ArgumentNullException>(() => source.Where(predicate));
        }


    }
}