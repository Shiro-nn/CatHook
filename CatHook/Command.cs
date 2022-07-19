using System;
using System.IO;
using System.Linq;
using CommandSystem;
using MEC;
using Qurre;
using Qurre.API;
using Qurre.API.Addons.Models;
using UnityEngine;

namespace CatHook
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    [CommandHandler(typeof(ClientCommandHandler))]
    public class CallMapCommand : ICommand
    {
        public string Command => "hook";
        public string[] Aliases => new string[] { "cat_hook" };
        public string Description => "Использовать паутинку: hook";
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player admin = Player.Get((sender as CommandSender).SenderId);
            if (!CatHook.CustomConfig.AdminWhoCanGet.Contains(admin.GroupName))
            {
                response = CatHook.CustomConfig.CannotAdminText;
                return false;
            }
            if (admin.Role == RoleType.Spectator)
            {
                response = CatHook.CustomConfig.DiedText;
                return false;
            }
            /*
            if (arguments.At(0).ToLower() == "info")
            {
                response = CatHook.CustomConfig.DescriptionText;
                return true;
            }
            if (arguments.At(0).ToLower() == "run")
            {
                //CatHook.Run(admin);
                response = "Успешно!";
                return true;
            }
            if (arguments.At(0).ToLower() == "drop")
            {
                //CatHook.Drop(admin);
                response = "Успешно!";
                return true;
            }
            */
            Timing.RunCoroutine(CatHook.Teleport(admin));
            response = $"Проверка";
            return true;
        }
    }
}