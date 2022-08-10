namespace MyLinq.Tests
{
    public class MySelectTests
    {
        [Fact]
        public void NullSourceThrowsNullArgumentException()
        {
            IEnumerable<int> source = null;
            Should.Throw<ArgumentNullException>(() => source.Select(x => x + 1));
        }

        [Fact]
        public void NullProjectionThrowsNullArgumentException()
        {
            int[] source = { 1, 3, 7, 9, 10 };
            Func<int, int> projection = null;
            Should.Throw<ArgumentNullException>(() => source.Select(projection));
        }


        [Fact]
        public void SimpleProjection()
        {
            int[] source = { 1, 5, 2 };
            var result = source.Select(x => x * 2);
            result.ShouldBe(new[] { 2, 10, 4 });
        }

        [Fact]
        public void SimpleProjectionWithQueryExpression()
        {
            int[] source = { 1, 5, 2 };
            var result = from x in source
                         select x * 2;
            result.ShouldBe(new[] { 2, 10, 4 });
        }

        [Fact]
        public void EmptySource()
        {
            int[] source = new int[0];
            var result = source.Select(x => x * 2);
            result.ShouldBeEmpty();
        }



        [Fact]
        public void SimpleProjectionToDifferentType()
        {
            int[] source = { 1, 5, 2 };
            var result = source.Select(x => x.ToString());
            result.ShouldBe(new[] { "1", "5", "2" });
        }

        [Fact]
        public void SideEffectsInProjection()
        {
            int[] source = new int[3]; // Actual values won’t be relevant
            int count = 0;
            var query = source.Select(x => count++);
            query.ShouldBe(new[] { 0, 1, 2 });
            query.ShouldBe(new[] { 3, 4, 5 });
            count = 10;
            query.ShouldBe(new[] { 10, 11, 12 });
        }

        [Fact]
        public void WhereAndSelect()
        {
            int[] source = { 1, 3, 4, 2, 8, 1 };
            var result = from x in source
                         where x < 4
                         select x * 2;
            result.ShouldBe(new[] { 2, 6, 4, 2 });
        }
    }
}
