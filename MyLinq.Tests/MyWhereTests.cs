using Shouldly;
using System;
using Xunit;
using System.Collections.Generic;

namespace MyLinq.Tests
{
    public class MyWhereTests
    {
        [Fact]
        public void MyWhere_should_filter_according_to_predicate()
        {
            int[] source = { 1, 3, 4, 2, 8, 1 };
            var result = source.Where(x => x < 4);
            result.ShouldBe(new[] { 1, 3, 2, 1 });
        }

        [Fact]
        public void NullSource_should_throws_NullArgumentException()
        {
            IEnumerable<int> source = null;

            Should.Throw<ArgumentException>(() => source.Where(x => x > 5));
        }

        [Fact]
        public void NullPredicate_should_throws_NullArgumentException()
        {
            int[] source = { 1, 3, 7, 9, 10 };
            Func<int, bool> predicate = null;

            Should.Throw<ArgumentException>(() => source.Where(predicate));
        }
    }
}
