using System.Collections.ObjectModel;
using System.Linq;
using SmartHunter.Core.Data;

namespace SmartHunter.Game.Data.WidgetContexts
{
    public class PlayerWidgetContext : WidgetContext
    {
        public ObservableCollection<PlayerStatusEffect> StatusEffects { get; private set; }

        public PlayerWidgetContext()
        {
            StatusEffects = new ObservableCollection<PlayerStatusEffect>();
        }

        public PlayerStatusEffect UpdateAndGetPlayerStatusEffect(int index, float? currentTime, bool isConditionPassed)
        {
            PlayerStatusEffect playerStatusEffect = StatusEffects.SingleOrDefault(statusEffect => statusEffect.Index == index);
            if (playerStatusEffect == null && isConditionPassed)
            {
                playerStatusEffect = new PlayerStatusEffect(index, currentTime, currentTime, isConditionPassed);
                StatusEffects.Add(playerStatusEffect);
            }
            else if (playerStatusEffect != null)
            {
                if (currentTime.HasValue)
                {
                    playerStatusEffect.Time.Current = currentTime.Value;
                }

                playerStatusEffect.IsConditionPassed = isConditionPassed;
            }

            return playerStatusEffect;
        }

        public override void UpdateFromConfig()
        {
            base.UpdateFromConfig();

            foreach (var statusEffect in StatusEffects)
            {
                statusEffect.NotifyPropertyChanged(nameof(PlayerStatusEffect.IsVisible));
            }
        }
    }
}
