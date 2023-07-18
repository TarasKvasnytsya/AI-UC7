using System;
using UC7_Logic;

namespace UC7_Tests
{
	public class PlayerAnalyzerTests
	{
		private readonly PlayerAnalyzer _analyzer;

		public PlayerAnalyzerTests()
		{
			_analyzer = new PlayerAnalyzer();
		}

		[Fact]
		public void CalculateScore_OnePlayer_Return150()
		{/////////////CHECK
		 //Arrange
			var playerList = GeneratePlayersList(25, 5, new List<int> { 2, 2, 2 }, 1);

			//Act
			var result = _analyzer.CalculateScore(playerList);

			//Assert
			Assert.Equal(250, result);
		}

		[Fact]
		public void CalculateScore_OnePlayer_Return67_5()
		{
			//Arrange
			var playerList = GeneratePlayersList(15, 3, new List<int> { 3, 3, 3 }, 1);

			//Act
			var result = _analyzer.CalculateScore(playerList);

			//Assert
			Assert.Equal(67.5, result);
		}

		[Fact]
		public void CalculateScore_OnePlayer_Return1008()
		{//////////check
		 //Arrange
			var playerList = GeneratePlayersList(35, 15, new List<int> { 4, 4, 4 }, 1);

			//Act
			var result = _analyzer.CalculateScore(playerList);

			//Assert
			Assert.Equal(2520, result);
		}

		[Fact]
		public void CalculateScore_ThreePlayers_Return750()
		{
			//Arrange
			var playerList = GeneratePlayersList(25, 5, new List<int> { 2, 2, 2 }, 3);

			//Act
			var result = _analyzer.CalculateScore(playerList);

			//Assert
			Assert.Equal(750, result);
		}

		[Fact]
		public void CalculateScore_SkillsNull_ThrowError()
		{
			//Arrange
			var playerList = GeneratePlayersList(25, 5, null, 1);

			//Act & Assert
			Assert.Throws<ArgumentNullException>(() => _analyzer.CalculateScore(playerList));
		}

		[Fact]
		public void CalculateScore_EmptyArray_Return0()
		{
			//Arrange
			var playerList = new List<Player>();

			//Act
			var result = _analyzer.CalculateScore(playerList);

			//Assert
			Assert.Equal(0, result);
		}

		private List<Player> GeneratePlayersList(int age, int experience, List<int> skills, int count)
		{
			var playerList = new List<Player>();

			for (int i = 0; i < count; i++)
			{
				playerList.Add(
					new Player
					{
						Age = age,
						Experience = experience,
						Skills = skills
					});
			}

			return playerList;
		}
	}
}
