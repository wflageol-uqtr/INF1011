using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.GameLogic
{
    public interface IGameState
    {
        bool IsComplete { get; }

        void DrawCards(IDeck deck);
        void Bet(int amount);
        void Fold();
        void ResetBet();
        void ReplaceCards(IDeck deck, IEnumerable<Card> replaceCards);
        IGameState? CreateNextGameState();
    }
}
