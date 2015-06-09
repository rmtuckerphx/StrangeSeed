//The API for a model representing how the player is doing

using System;

namespace StrangeSeed.Common
{
	public interface IGameModel
	{
		// Restore game model to default state (as on startup)
		void Reset();

		int score{ get; set; }

        //int lives{ get; set; }

        //int initLives{ get; set; }

		int level{ get; set; }

		bool levelInProgress{ get; set; }
	}
}

