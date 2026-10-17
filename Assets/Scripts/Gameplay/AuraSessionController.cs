using System.Collections.Generic;
using Aura.Cards;
using Aura.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Aura.Gameplay
{
    public sealed class AuraSessionController : MonoBehaviour
    {
        [SerializeField] private Text titleLabel;
        [SerializeField] private Text promptLabel;
        [SerializeField] private Text progressLabel;
        [SerializeField] private Button playButton;
        private AuraGame game;
        private AuraCard selected;

        private void Start()
        {
            game = new AuraGame(new List<AuraCard>
            {
                new AuraCard("r1", "Obserwacja", "Co dostrzegasz w tej chwili?", SessionPhase.Reflection),
                new AuraCard("r2", "Perspektywa", "Jak inaczej można spojrzeć na tę sytuację?", SessionPhase.Reflection),
                new AuraCard("i1", "Światło", "Wyobraź sobie spokojny ruch światła.", SessionPhase.Imagination),
                new AuraCard("i2", "Przestrzeń", "Wybierz znaczenie, które chcesz nadać tej chwili.", SessionPhase.Imagination)
            });
            if (playButton != null) playButton.onClick.AddListener(PlaySelected);
            Refresh();
        }

        private void OnDestroy()
        {
            if (playButton != null) playButton.onClick.RemoveListener(PlaySelected);
        }

        public void PlaySelected()
        {
            if (selected == null) return;
            game.Play(selected.Id);
            Refresh();
        }

        private void Refresh()
        {
            if (game.Phase == SessionPhase.Complete)
            {
                selected = null;
                Set(titleLabel, "Sesja zakończona");
                Set(promptLabel, "Możesz wrócić do Aury w dowolnej chwili.");
                Set(progressLabel, "Wynik: " + game.Score);
            }
            else
            {
                var available = game.AvailableCards();
                selected = available.Count > 0 ? available[0] : null;
                Set(titleLabel, selected != null ? selected.Title : "Brak kart");
                Set(promptLabel, selected != null ? selected.Prompt : "");
                Set(progressLabel, "Akt " + game.Phase + " · Ruch " + (game.Turn + 1));
            }
            if (playButton != null) playButton.interactable = selected != null;
        }

        private static void Set(Text label, string text)
        {
            if (label != null) label.text = text;
        }
    }
}
