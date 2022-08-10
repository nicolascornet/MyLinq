using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinq.Tests
{
    public class MyLastTests
    {
        [Fact]
        public void NullSourceWithoutPredicate()
        {
            int[] source = null;
            Should.Throw<ArgumentNullException>(() => source.Last());
        }

        [Fact]
        public void NullSourceWithPredicate()
        {
            int[] source = null;
            Should.Throw<ArgumentNullException>(() => source.Last(x => x > 3));
        }

        [Fact]
        public void NullPredicate()
        {
            var source = new LinkedList<int>(new int[] { 1, 3, 5 });
            Should.Throw<ArgumentNullException>(() => source.Last(null));
        }

        [Fact]
        public void EmptySequenceWithoutPredicate()
        {
            var source = new LinkedList<int>();
            Should.Throw<InvalidOperationException>(() => source.Last());
        }

        [Fact]
        public void SingleElementSequenceWithoutPredicate()
        {
            var source = new LinkedList<int>(new int[] { 5 });
            source.Last().ShouldBe(5);
        }

        [Fact]
        public void MultipleElementSequenceWithoutPredicate()
        {
            var source = new LinkedList<int>(new int[] { 5, 10 });
            source.Last().ShouldBe(10);
        }

        [Fact]
        public void EmptySequenceWithPredicate()
        {
            var source = new LinkedList<int>();
            Should.Throw<InvalidOperationException>(() => source.Last(x => x > 3));
        }

        [Fact]
        public void SingleElementSequenceWithMatchingPredicate()
        {
            var source = new LinkedList<int>(new int[] { 5 });
            source.Last().ShouldBe(5);
        }

        [Fact]
        public void SingleElementSequenceWithNonMatchingPredicate()
        {
            var source = new LinkedList<int>(new int[] { 2 });
            Should.Throw<InvalidOperationException>(() => source.Last(x => x > 3));
        }

        [Fact]
        public void MultipleElementSequenceWithNoPredicateMatches()
        {
            var source = new LinkedList<int>(new int[] { 1, 2, 2, 1 });
            Should.Throw<InvalidOperationException>(() => source.Last(x => x > 3));
        }

        [Fact]
        public void MultipleElementSequenceWithSinglePredicateMatch()
        {
            var source = new LinkedList<int>(new int[] { 1, 2, 5, 2, 1 });
            source.Last(x => x > 3).ShouldBe(5);
        }

        [Fact]
        public void MultipleElementSequenceWithMultiplePredicateMatches()
        {
            var source = new LinkedList<int>(new int[] { 1, 2, 5, 10, 2, 1 });
            source.Last(x => x > 3).ShouldBe(10);
        }

    }
}
