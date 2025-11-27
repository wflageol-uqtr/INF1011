using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.GameLogic
{
    public class BetGameState : GameState
    {
        private PlayerState initialPlayer;
        private bool secondRound;

        public BetGameState(PlayerState player, bool secondRound)
        {
            initialPlayer = player;
            this.secondRound = secondRound;
        }

        public override void Bet(int amount)
        {
            if (UpdatedPlayer != null)
                throw new GameException("Vous avez déjà misé pour ce tour.");

            UpdatedPlayer = initialPlayer with { Bet = amount };
        }
        public override void Fold()
            => UpdatedPlayer = initialPlayer with { Folded = true };

        public override void ResetBet()
        {
            if (UpdatedPlayer?.Folded ?? false)
                UpdatedPlayer = null;
        }
        public override IGameState? CreateNextGameState()
        {
            if (UpdatedPlayer == null)
                throw new ArgumentException("Opération invalide.");

            if (UpdatedPlayer.Folded || secondRound)
                return null;
            else
                return new ReplaceGameState(UpdatedPlayer);
        }

    }
}
