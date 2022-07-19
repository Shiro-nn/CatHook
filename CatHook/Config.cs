using Qurre.API.Addons;
using System.Collections.Generic;
using System.ComponentModel;

namespace CatHook
{
    public class Config : IConfig
    {
        [Description("Plugin Name")]
        public string Name { get; set; } = "Cat Hook";

        [Description("Enable the plugin?")]
        public bool IsEnable { get; set; } = true;
        [Description("...")]
        public string CannotText = "<b><color=red>Крюк-кошку нельзя использовать в данной местности.</color></b>";
        [Description("...")]
        public string DropItemText = "<b><color=red>Для использования крюк-кошки,</color></b>\n<b><color=red>вы должны убрать предмет из руки.</color></b>";
        [Description("...")]
        public string DescriptionText = "Крюк-Кошка - прибор из серии игр Just Cause™, который позволяет быстро перемещаться по воздуху\nПоможет убежать!";
        [Description("...")]
        public string PickupText = "<b><color=lime>Вы подобрали <color=#0089c7>крюк</color>-<color=#0089c7>кошку</color></color></b>\n<color=#fdffbb>Подробнее:</color> <color=red>.</color><color=cyan>cat_hook info</color>";
        [Description("Группа админов, которые смогут использовать Паутинку.")]
        public List<string> AdminWhoCanGet = new List<string>()
        {
            "owner",
            "admin",
            "moderator"
        };
    }
}
