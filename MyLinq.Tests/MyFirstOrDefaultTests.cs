using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinq.Tests
{
    public class MyFirstOrDefaultTests
    {
        [Fact]
        public void NullSourceWithoutPredicate()
        {
            int[] source = null;
            Should.Throw<ArgumentNullException>(() => source.FirstOrDefault());
        }

        [Fact]
        public void NullSourceWithPredicate()
        {
            int[] source = null;
            Should.Throw<ArgumentNullException>(() => source.FirstOrDefault(x => x > 3));
        }

        [Fact]
        public void NullPredicate()
        {
            int[] source = { 1, 3, 5 };
            Should.Throw<ArgumentNullException>(() => source.FirstOrDefault(null));
        }

        [Fact]
        public void EmptySequenceWithoutPredicate()
        {
            int[] source = { };
            source.FirstOrDefault().ShouldBe(0);
        }

        [Fact]
        public void SingleElementSequenceWithoutPredicate()
        {
            int[] source = { 5 };
            source.FirstOrDefault().ShouldBe(5);
        }

        [Fact]
        public void MultipleElementSequenceWithoutPredicate()
        {
            int[] source = { 5, 10 };
            source.FirstOrDefault().ShouldBe(5);
        }

        [Fact]
        public void EmptySequenceWithPredicate()
        {
            int[] source = { };
            source.FirstOrDefault(x => x > 3).ShouldBe(0);
        }

        [Fact]
        public void SingleElementSequenceWithMatchingPredicate()
        {
            int[] source = { 5 };
            source.FirstOrDefault(x => x > 3).ShouldBe(5);
        }

        [Fact]
        public void SingleElementSequenceWithNonMatchingPredicate()
        {
            int[] source = { 2 };
            source.FirstOrDefault(x => x > 3).ShouldBe(0);
        }

        [Fact]
        public void MultipleElementSequenceWithNoPredicateMatches()
        {
            int[] source = { 1, 2, 2, 1 };
            source.FirstOrDefault(x => x > 3).ShouldBe(0);
        }

        [Fact]
        public void MultipleElementSequenceWithSinglePredicateMatch()
        {
            int[] source = { 1, 2, 5, 2, 1 };
            source.FirstOrDefault(x => x > 3).ShouldBe(5);
        }

        [Fact]
        public void MultipleElementSequenceWithMultiplePredicateMatches()
        {
            int[] source = { 1, 2, 5, 10, 2, 1 };
            source.FirstOrDefault(x => x > 3).ShouldBe(5);
        }
    }
}
