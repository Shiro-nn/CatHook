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
        public string Description => "Использовать паутинку: hook [info / run]";
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get((sender as CommandSender).SenderId);
            if (CatHook.CustomConfig.AdminWhoCanGet.Contains(player.GroupName) || player == CatHook.Person)
            {
                if (player.Role == RoleType.Spectator)
                {
                    response = CatHook.CustomConfig.DiedText;
                    return false;
                }
                if (arguments.Count != 1)
                {
                    response = "Введите команду: hook [info или run]";
                    return false;
                }
                if (arguments.At(0).ToLower() == "info")
                {
                    response = CatHook.CustomConfig.DescriptionText;
                    return true;
                }
                if (arguments.At(0).ToLower() == "run")
                {
                    Timing.RunCoroutine(PhysicCore.Teleport(player));
                    response = "Крюк-Кошка использовалась!";
                    return true;
                }
            }
            response = CatHook.CustomConfig.CannotAdminText;
            return false;
        }
    }
}