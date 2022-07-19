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
        public string DescriptionText = "Крюк-Кошка - это возможность для админов, которое позволяет летать с большой скоростью по всей карте.";
        
        [Description("Группа админов, которые смогут использовать Паутинку.")]
        public List<string> AdminWhoCanGet = new List<string>()
        {
            "owner",
            "admin",
            "moderator"
        };
    }
}
