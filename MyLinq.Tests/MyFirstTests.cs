using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinq.Tests
{
    public class MyFirstTests
    {
        [Fact]
        public void NullSourceWithoutPredicate()
        {
            int[] source = null;
            Should.Throw<ArgumentNullException>(() => source.First());
        }

        [Fact]
        public void NullSourceWithPredicate()
        {
            int[] source = null;
            Should.Throw<ArgumentNullException>(() => source.First(x => x > 3));
        }

        [Fact]
        public void NullPredicate()
        {
            int[] source = { 1, 3, 5 };
            Should.Throw<ArgumentNullException>(() => source.First(null));
        }

        [Fact]
        public void EmptySequenceWithoutPredicate()
        {
            int[] source = { };
            Should.Throw<InvalidOperationException>(() => source.First());
        }

        [Fact]
        public void SingleElementSequenceWithoutPredicate()
        {
            int[] source = { 5 };
            source.First().ShouldBe(5);
        }

        [Fact]
        public void MultipleElementSequenceWithoutPredicate()
        {
            int[] source = { 5, 10 };
            source.First().ShouldBe(5);
        }

        [Fact]
        public void EmptySequenceWithPredicate()
        {
            int[] source = { };
            Should.Throw<InvalidOperationException>(() => source.First(x => x > 3));
        }

        [Fact]
        public void SingleElementSequenceWithMatchingPredicate()
        {
            int[] source = { 5 };
            source.First(x => x > 3).ShouldBe(5);
        }

        [Fact]
        public void SingleElementSequenceWithNonMatchingPredicate()
        {
            int[] source = { 2 };
            Should.Throw<InvalidOperationException>(() => source.First(x => x > 3));
        }

        [Fact]
        public void MultipleElementSequenceWithNoPredicateMatches()
        {
            int[] source = { 1, 2, 2, 1 };
            Should.Throw<InvalidOperationException>(() => source.First(x => x > 3));
        }

        [Fact]
        public void MultipleElementSequenceWithSinglePredicateMatch()
        {
            int[] source = { 1, 2, 5, 2, 1 };
            source.First(x => x > 3).ShouldBe(5);
        }

        [Fact]
        public void MultipleElementSequenceWithMultiplePredicateMatches()
        {
            int[] source = { 1, 2, 5, 10, 2, 1 };
            source.First(x => x > 3).ShouldBe(5);
        }

        [Fact]
        public void EarlyOutAfterFirstElementWithoutPredicate()
        {
            int[] source = { 15, 1, 0, 3 };
            var query = source.Select(x => 10 / x);
            // We finish before getting as far as dividing by 0
            query.First().ShouldBe(0);
        }

        [Fact]
        public void EarlyOutAfterFirstElementWithPredicate()
        {
            int[] source = { 15, 1, 0, 3 };
            var query = source.Select(x => 10 / x);
            // We finish before getting as far as dividing by 0
            query.First(y => y > 5).ShouldBe(10);
        }
    }
}
