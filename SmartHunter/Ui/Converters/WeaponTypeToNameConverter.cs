using System;
using System.Globalization;
using System.Windows.Data;
using SmartHunter.Game.Data;

namespace SmartHunter.Ui.Converters
{
    public class WeaponTypeToNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is WeaponType)
            {
                if ((WeaponType)value == WeaponType.NO_WEAPON)
                {
                    return "";
                }
                if ((WeaponType)value == WeaponType.BOW)
                {
                    return "Bow";
                }if ((WeaponType)value == WeaponType.CHARGE_BLADE)
                {
                    return "Charge Blade";
                }
                if ((WeaponType)value == WeaponType.DUAL_BLADES)
                {
                    return "Dual Blades";
                }
                if ((WeaponType)value == WeaponType.GREAT_SWORD)
                {
                    return "Great Sword";
                }
                if ((WeaponType)value == WeaponType.GUNLANCE)
                {
                    return "Gunlance";
                }
                if ((WeaponType)value == WeaponType.HAMMER)
                {
                    return "Hammer";
                }
                if ((WeaponType)value == WeaponType.HEAVY_BOWGUN)
                {
                    return "Heavy Bowgun";
                }
                if ((WeaponType)value == WeaponType.HUNTING_HORN)
                {
                    return "Hunting Horn";
                }
                if ((WeaponType)value == WeaponType.INSECT_GLAIVE)
                {
                    return "Insect Glaive";
                }
                if ((WeaponType)value == WeaponType.KINSECT)
                {
                    return "Kinsect";
                }
                if ((WeaponType)value == WeaponType.LANCE)
                {
                    return "Lance";
                }
                if ((WeaponType)value == WeaponType.LIGHT_BOWGUN)
                {
                    return "Light Bowgun";
                }
                if ((WeaponType)value == WeaponType.LONG_SWORD)
                {
                    return "Long Sword";
                }
                if ((WeaponType)value == WeaponType.SLINGER)
                {
                    return "Slinger";
                }
                if ((WeaponType)value == WeaponType.SWITCH_AXE)
                {
                    return "Switch Axe";
                }
                if ((WeaponType)value == WeaponType.SWORD_AND_SHIELD)
                {
                    return "Sword and Shield";
                }
            }
            return "Unkown Weapon";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
