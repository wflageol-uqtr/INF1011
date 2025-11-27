using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.GameLogic
{
    public abstract class GameState : IGameState
    {
        public PlayerState? UpdatedPlayer { get; protected set; }

        public bool IsComplete => UpdatedPlayer != null;

        private void InvalidAction()
            => throw new GameException("Action invalide à ce stade de la partie.");

        public virtual void Bet(int amount) => InvalidAction();

        public virtual void DrawCards(IDeck deck) => InvalidAction();

        public virtual void Fold() => InvalidAction();

        public virtual void ResetBet() { }

        public virtual void ReplaceCards(IDeck deck, IEnumerable<Card> replaceCards) => InvalidAction();

        public abstract IGameState? CreateNextGameState();
    }
}
