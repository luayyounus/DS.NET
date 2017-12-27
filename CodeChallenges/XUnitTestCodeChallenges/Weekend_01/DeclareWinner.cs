using System;
using System.Collections.Generic;
using CodeChallenges;
using Xunit;

namespace XUnitTestCodeChallenges.Weekend_01
{
    public class DeclareWinnerTest
    {
        public static IEnumerable<object[]> GetFighters()
        {
            yield return new object[] {"XML", new Fighter("Json", 20, 3), new Fighter("XML", 30, 2), "XML"};
            yield return new object[] { "Apple", new Fighter("Windows", 5, 1), new Fighter("Apple", 10, 2), "Apple" };
            yield return new object[] { "Peach", new Fighter("Banana", 15, 3), new Fighter("Peach", 20, 5), "Banana" };
        }

        [Theory]
        [MemberData(nameof(GetFighters))]
        public void Return_Winner_Name(string expectedWinner, Fighter fighterOne, Fighter fighterTwo, string firstAttacker)
        {
            Assert.Equal(expectedWinner, DeclareWinner.CheckWinner(fighterOne, fighterTwo, firstAttacker));
        }
    }
}
