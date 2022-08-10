namespace MyLinq.Tests
{
    public class MyLastOrDefaultTests
    {
        [Fact]
        public void NullSourceWithoutPredicate()
        {
            int[] source = null;
            Should.Throw<ArgumentNullException>(() => source.LastOrDefault());
        }

        [Fact]
        public void NullSourceWithPredicate()
        {
            int[] source = null;
            Should.Throw<ArgumentNullException>(() => source.LastOrDefault(x => x > 3));
        }

        [Fact]
        public void NullPredicate()
        {
            var source = new LinkedList<int>(new int[] { 1, 3, 5 });
            Should.Throw<ArgumentNullException>(() => source.LastOrDefault(null));
        }

        [Fact]
        public void EmptySequenceWithoutPredicate()
        {
            var source = new LinkedList<int>();
            source.LastOrDefault().ShouldBe(0);
        }

        [Fact]
        public void SingleElementSequenceWithoutPredicate()
        {
            var source = new LinkedList<int>(new int[] { 5 });
            source.LastOrDefault().ShouldBe(5);
        }

        [Fact]
        public void MultipleElementSequenceWithoutPredicate()
        {
            var source = new LinkedList<int>(new int[] { 5, 10 });
            source.LastOrDefault().ShouldBe(10);
        }

        [Fact]
        public void EmptySequenceWithPredicate()
        {
            var source = new LinkedList<int>();
            source.LastOrDefault(x => x > 3).ShouldBe(0);
        }

        [Fact]
        public void SingleElementSequenceWithMatchingPredicate()
        {
            var source = new LinkedList<int>(new int[] { 5 });
            source.LastOrDefault(x => x > 3).ShouldBe(5);
        }

        [Fact]
        public void SingleElementSequenceWithNonMatchingPredicate()
        {
            var source = new LinkedList<int>(new int[] { 2 });
            source.LastOrDefault(x => x > 3).ShouldBe(0);
        }

        [Fact]
        public void MultipleElementSequenceWithNoPredicateMatches()
        {
            var source = new LinkedList<int>(new int[] { 1, 2, 2, 1 });
            source.LastOrDefault(x => x > 3).ShouldBe(0);
        }

        [Fact]
        public void MultipleElementSequenceWithSinglePredicateMatch()
        {
            var source = new LinkedList<int>(new int[] { 1, 2, 5, 2, 1 });
            source.LastOrDefault(x => x > 3).ShouldBe(5);
        }

        [Fact]
        public void MultipleElementSequenceWithMultiplePredicateMatches()
        {
            var source = new LinkedList<int>(new int[] { 1, 2, 5, 10, 2, 1 });
            source.LastOrDefault(x => x > 3).ShouldBe(10);
        }

    }
}
