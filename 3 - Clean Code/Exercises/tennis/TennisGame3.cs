using System;

namespace Tennis
{
	public class TennisGame3 : TennisGame
	{
		private Player3 player1 = new Player3();
		private Player3 player2 = new Player3();

		private const string ZERO_POINTS = "Love";
		private const string ONE_POINT = "Fifteen";
		private const string TWO_POINTS = "Thirty";
		private const string THREE_POINTS = "Forty";
		private const string DEUCE = "Deuce";
		private const string SCORE_EQUALITY = "-All";

		public TennisGame3(string playerName1, string playerName2)
		{
			player1.Name = playerName1;
			player2.Name = playerName2;
		}

		public string GetScore()
		{
			string score;

			if (player1.Points < 4 && player2.Points < 4)
			{
				string[] scorePoints = new string[] { ZERO_POINTS, ONE_POINT, TWO_POINTS, THREE_POINTS };

				score = scorePoints[player1.Points];

				if (player1.Points == player2.Points)
				{
					score += SCORE_EQUALITY;
				}
				else
				{
					score += "-" + scorePoints[player2.Points];
				}

				return score;
			}

			if (player1.Points == player2.Points)
			{
				return "Deuce";
			}
					
			string playerWithMorePoints = player1.Points > player2.Points ? player1.Name : player2.Name;
			score = ((player1.Points - player2.Points) * (player1.Points - player2.Points) == 1) ? "Advantage " : "Win for ";

			return score + playerWithMorePoints;
		}

		public void WonPoint(string playerName)
		{
			if (playerName == "player1")
			{
				player1.Points++;
			}
			else
			{
				player2.Points++;
			}
		}

	}
}
