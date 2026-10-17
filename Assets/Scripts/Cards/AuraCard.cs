using System;
using Aura.Core;

namespace Aura.Cards
{
    [Serializable]
    public sealed class AuraCard
    {
        public string Id;
        public string Title;
        public string Prompt;
        public SessionPhase Phase;
        public int Points;

        public AuraCard(string id, string title, string prompt, SessionPhase phase, int points = 1)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("ID required", nameof(id));
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Title required", nameof(title));
            if (string.IsNullOrWhiteSpace(prompt)) throw new ArgumentException("Prompt required", nameof(prompt));
            if (points < 0) throw new ArgumentOutOfRangeException(nameof(points));
            Id = id; Title = title; Prompt = prompt; Phase = phase; Points = points;
        }
    }
}
