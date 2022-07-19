using Qurre.API.Addons;
using System.Collections.Generic;
using System.ComponentModel;

namespace CatHook
{
    public class Config : IConfig
    {
        [Description("Plugin Name")]
        public string Name { get; set; } = "CatHook";

        [Description("Enable the plugin?")]
        public bool IsEnable { get; set; } = true;

        [Description("Надо ли в игре спавнить Крюк-кошку?")]
        public bool IsNeedSpawn { get; set; } = true;

        [Description("Защита от использования не тем админом.")]
        public string CannotAdminText { get; set; } = "<b><color=red>Вы не можете использовать Крюк-кошку</color></b>";

        [Description("Защита от использования, если человек мертв")]
        public string DiedText { get; set; } = "<b><color=red>Чувак ты мертв!</color></b>";

        [Description("Защита от использования на поверхности")]
        public string CannotText { get; set; } = "<b><color=red>Крюк-кошку нельзя использовать в данной местности.</color></b>";

        [Description("Описание плагина.")]
        public string DescriptionText { get; set; } = "Крюк-Кошка - это возможность для админов, которая позволяет летать с большой скоростью по всей карте.";

        [Description("Использования Крюк-Кошки, если в руки предмет.")]
        public string DropItemText { get; set; } = "<b><color=red>Для использования крюк-кошки,</color></b>\n<b><color=red>вы должны убрать предмет из руки.</color></b>";

        [Description("Игрок подобрал Крюк-Кошку")]
        public string PickupText { get; set; } = "<b><color=lime>Вы подобрали <color=#0089c7>крюк</color>-<color=#0089c7>кошку</color></color></b>\n<color=#fdffbb>Подробнее:</color> <color=red>.</color><color=cyan>hook info</color>";

        [Description("Группа админов, которые смогут использовать Паутинку.")]
        public List<string> AdminWhoCanGet { get; set; } = new List<string>()
        {
            "owner",
            "admin",
            "moderator"
        };
    }
}
