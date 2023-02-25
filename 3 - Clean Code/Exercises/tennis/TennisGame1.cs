
using System;
using NUnit.Framework;

namespace Tennis
{
	class TennisGame1 : TennisGame
	{
		private Player1 player1 = new Player1();
		private Player1 player2 = new Player1();

		private const string ZERO_POINTS = "Love";
		private const string ZERO_POINTS_EQUALITY = "Love-All";
		private const string ONE_POINT = "Fifteen";
		private const string ONE_POINT_EQUALITY = "Fifteen-All";
		private const string TWO_POINTS = "Thirty";
		private const string TWO_POINTS_EQUALITY = "Thirty-All";
		private const string THREE_POINTS = "Forty";
		private const string THREE_POINTS_EQUALITY = "Forty-All";
		private const string DEUCE = "Deuce";
		private const string ADVANTAGE_PLAYER1 = "Advantage player1";
		private const string ADVANTAGE_PLAYER2 = "Advantage player2";
		private const string WIN_PLAYER1 = "Win for player1";
		private const string WIN_PLAYER2 = "Win for player2";

		public TennisGame1(string playerName1, string playerName2)
		{
			player1.Name = playerName1;
			player2.Name = playerName2;
		}

		public void WonPoint(string playerName)
		{
			if (playerName == "player1")
			{
				player1.Score++;
			}
			else
			{
				player2.Score++;
			}
		}

		public string GetScore()
		{
			string score = string.Empty;
			int playerScore = 0;

			if (player1.Score == player2.Score)
			{
				switch (player1.Score)
				{
					case 0:
						score = ZERO_POINTS_EQUALITY;
						break;
					case 1:
						score = ONE_POINT_EQUALITY;
						break;
					case 2:
						score = TWO_POINTS_EQUALITY;
						break;
					case 3:
						score = THREE_POINTS_EQUALITY;
						break;
					default:
						score = DEUCE;
						break;
				}
			}
			else if (Math.Max(player1.Score, player2.Score) >= 4)
			{
				int scoreDifference = player1.Score - player2.Score;

				if (scoreDifference == 1)
				{
					score = ADVANTAGE_PLAYER1;
				}
				else if (scoreDifference == -1)
				{
					score = ADVANTAGE_PLAYER2;
				}
				else if (scoreDifference >= 2)
				{
					score = WIN_PLAYER1;
				}
				else
				{
					score = WIN_PLAYER2;
				}
			}
			else
			{
				for (int playerNumber = 1; playerNumber <= 2; playerNumber++)
				{
					if (playerNumber == 1)
					{
						playerScore = player1.Score;
					}
					else
					{
						score += "-";
						playerScore = player2.Score;
					}

					switch (playerScore)
					{
						case 0:
							score += ZERO_POINTS;
							break;
						case 1:
							score += ONE_POINT;
							break;
						case 2:
							score += TWO_POINTS;
							break;
						case 3:
							score += THREE_POINTS;
							break;
					}
				}
			}

			return score;
		}
	}

}
