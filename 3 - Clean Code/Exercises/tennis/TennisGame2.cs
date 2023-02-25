using System;

namespace Tennis
{
	public class TennisGame2 : TennisGame
	{
		private Player2 player1 = new Player2();
		private Player2 player2 = new Player2();

		private const string ZERO_POINTS = "Love";
		private const string ONE_POINT = "Fifteen";
		private const string TWO_POINTS = "Thirty";
		private const string THREE_POINTS = "Forty";
		private const string DEUCE = "Deuce";
		private const string SCORE_EQUALITY = "-All";

		public TennisGame2(string playerName1, string playerName2)
		{
			player1.Name = playerName1;
			player2.Name = playerName2;
		}

		public string GetScore()
		{
			string score = string.Empty;

			ComputePlayerResult(player1);
			ComputePlayerResult(player2);

			if (PlayersHaveSamePoints())
			{
				if (player1.Points < 4)
				{
					score = player1.Result;
					score += SCORE_EQUALITY;
				}
				else if (player1.Points > 3)
				{
					score = DEUCE;
				}
			}
			else if (PlayerWithZeroPoints() || ScoreIsMixed())
			{
				score = player1.Result + "-" + player2.Result;
			}
			else if (CheckPlayerWin(player1, player2) ||
					 CheckPlayerWin(player2, player1))
			{
				Player2 playerWithMorePoints = GetPlayerWithMorePoints(player1, player2);
				score = "Win for " + playerWithMorePoints.Name;
			}
			else if (CheckPlayerAdvantage(player1, player2) ||
					 CheckPlayerAdvantage(player2, player1))
			{
				Player2 playerWithMorePoints = GetPlayerWithMorePoints(player1, player2);
				score = "Advantage " + playerWithMorePoints.Name;
			}

			return score;
		}

		public void IncreasePlayerScore(Player2 player)
		{
			player.Points++;
		}

		public void WonPoint(string player)
		{
			if (player == "player1")
			{
				IncreasePlayerScore(player1);
			}
			else
			{
				IncreasePlayerScore(player2);
			}
		}

		public void ComputePlayerResult(Player2 player)
		{
			if (player.Points == 0)
			{
				player.Result = ZERO_POINTS;
			}
			else if (player.Points == 1)
			{
				player.Result = ONE_POINT;
			}
			else if (player.Points == 2)
			{
				player.Result = TWO_POINTS;
			}
			else if (player.Points == 3)
			{
				player.Result = THREE_POINTS;
			}
		}

		private bool PlayersHaveSamePoints()
		{
			return player1.Points == player2.Points;
		}

		public bool PlayerWithZeroPoints()
		{
			return player1.Points == 0 || player2.Points == 0;
		}

		public bool ScoreIsMixed()
		{
			return
				((player1.Points > player2.Points) && (player1.Points < 4) ||
				(player2.Points > player1.Points) && (player2.Points < 4));
		}

		public Player2 GetPlayerWithMorePoints(Player2 player1, Player2 player2)
		{
			return player1.Points > player2.Points ? player1 : player2;
		}

		public bool CheckPlayerAdvantage(Player2 playerWithAdvantage, Player2 playerWithoutAdvantage)
		{
			return
				playerWithAdvantage.Points > playerWithoutAdvantage.Points &&
				playerWithoutAdvantage.Points >= 3;
		}

		public bool CheckPlayerWin(Player2 playerWinning, Player2 playerLosing)
		{
			return
				playerWinning.Points >= 4	&&
				playerLosing.Points >= 0	&&
				(playerWinning.Points - playerLosing.Points) >= 2;
		}
	}
}
