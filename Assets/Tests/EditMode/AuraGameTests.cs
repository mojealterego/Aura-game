using System;
using System.Collections.Generic;
using Aura.Cards;
using Aura.Core;
using NUnit.Framework;

namespace Aura.Tests
{
    public sealed class AuraGameTests
    {
        private static AuraGame NewGame() => new AuraGame(new List<AuraCard>
        {
            new AuraCard("r1", "A", "Question A", SessionPhase.Reflection),
            new AuraCard("r2", "B", "Question B", SessionPhase.Reflection),
            new AuraCard("i1", "C", "Question C", SessionPhase.Imagination)
        });

        [Test] public void StartsInReflection() => Assert.AreEqual(SessionPhase.Reflection, NewGame().Phase);
        [Test] public void RejectsWrongPhase() => Assert.Throws<InvalidOperationException>(() => NewGame().Play("i1"));
        [Test] public void RejectsDuplicateCard()
        {
            var game = NewGame(); game.Play("r1");
            Assert.Throws<InvalidOperationException>(() => game.Play("r1"));
        }
        [Test] public void CompletesAfterAllCards()
        {
            var game = NewGame(); game.Play("r1"); game.Play("r2");
            Assert.AreEqual(SessionPhase.Imagination, game.Phase);
            game.Play("i1");
            Assert.AreEqual(SessionPhase.Complete, game.Phase);
            Assert.AreEqual(3, game.Score);
        }
    }
}
