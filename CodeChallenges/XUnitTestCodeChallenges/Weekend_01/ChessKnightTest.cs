using CodeChallenges;
using Xunit;

namespace XUnitTestCodeChallenges.Weekend_01
{
    public class ChessKnightTest
    {
        [Theory]
        [InlineData(2, "a8")]
        [InlineData(6, "b5")]
        [InlineData(4, "c8")]
        [InlineData(6, "d2")]
        [InlineData(4, "e8")]
        [InlineData(8, "f6")]
        [InlineData(6, "g6")]
        [InlineData(3, "h2")]
        [InlineData(0, "k9")]
        public void Return_Possible_Moves(int expectedMoves, string cell)
        {
            Assert.Equal(expectedMoves, ChessKnight.CheckPossibleMoves(cell));
            Assert.Equal(expectedMoves, ChessKnight.CheckPossibleMoves2(cell));
        }

        [Theory]
        [InlineData(5, "a1")]
        [InlineData(3, "c5")]
        [InlineData(1, "d3")]
        public void Return_Not_Possible_Moves(int expectedMoves, string cell)
        {
            Assert.NotEqual(expectedMoves, ChessKnight.CheckPossibleMoves(cell));
            Assert.NotEqual(expectedMoves, ChessKnight.CheckPossibleMoves2(cell));
        }
    }
}
