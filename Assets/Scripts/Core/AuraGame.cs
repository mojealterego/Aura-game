using System;
using System.Collections.Generic;
using Aura.Cards;

namespace Aura.Core
{
    public enum SessionPhase { Reflection, Imagination, Complete }

    public sealed class AuraGame
    {
        private readonly IReadOnlyList<AuraCard> cards;
        private readonly HashSet<string> played = new HashSet<string>(StringComparer.Ordinal);
        private readonly int reflectionRounds;
        public SessionPhase Phase { get; private set; } = SessionPhase.Reflection;
        public int Turn { get; private set; }
        public int Score { get; private set; }

        public AuraGame(IReadOnlyList<AuraCard> deck, int reflectionRounds = 2)
        {
            if (deck == null || deck.Count == 0) throw new ArgumentException("Empty deck", nameof(deck));
            if (reflectionRounds < 1) throw new ArgumentOutOfRangeException(nameof(reflectionRounds));
            var ids = new HashSet<string>(StringComparer.Ordinal);
            foreach (var card in deck)
                if (card == null || string.IsNullOrWhiteSpace(card.Id) || !ids.Add(card.Id))
                    throw new ArgumentException("Card IDs must be unique", nameof(deck));
            cards = deck;
            this.reflectionRounds = reflectionRounds;
        }

        public IReadOnlyList<AuraCard> AvailableCards()
        {
            var result = new List<AuraCard>();
            foreach (var card in cards)
                if (!played.Contains(card.Id) && card.Phase == Phase) result.Add(card);
            return result;
        }

        public void Play(string id)
        {
            if (Phase == SessionPhase.Complete) throw new InvalidOperationException("Session complete");
            AuraCard card = null;
            foreach (var item in cards) if (item.Id == id) { card = item; break; }
            if (card == null || card.Phase != Phase || played.Contains(id))
                throw new InvalidOperationException("Card unavailable");
            played.Add(id);
            Turn++;
            Score += card.Points;
            if (Phase == SessionPhase.Reflection && (Turn >= reflectionRounds || AvailableCards().Count == 0))
                Phase = SessionPhase.Imagination;
            if (Phase == SessionPhase.Imagination && AvailableCards().Count == 0)
                Phase = SessionPhase.Complete;
        }
    }
}
