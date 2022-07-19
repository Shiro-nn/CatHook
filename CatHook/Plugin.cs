using UnityEngine;
using Qurre;
using Qurre.API;
using Qurre.API.Events;
using Qurre.API.Controllers;
using Qurre.API.Controllers.Items;

namespace CatHook
{
    public class CatHook : Plugin
    {
        public override string Developer => "fydne & KoT0XleB#4663";
        public override string Name => "CatHook";
        public override void Enable() => RegisterEvents();
        public override void Disable() => UnregisterEvents();
        public static Config CustomConfig { get; private set; }
        public Pickup HookItem;
        public static Player Person;
        public void RegisterEvents()
        {
            CustomConfig = new Config();
            CustomConfigs.Add(CustomConfig);
            if (!CustomConfig.IsEnable) return;

            Qurre.Events.Round.Start += OnRoundStart;
            Qurre.Events.Player.Dead += OnDead;
            Qurre.Events.Player.PickupItem += OnPickupItem;
        }
        public void UnregisterEvents()
        {
            CustomConfigs.Remove(CustomConfig);
            if (!CustomConfig.IsEnable) return;

            Qurre.Events.Round.Start -= OnRoundStart;
            Qurre.Events.Player.Dead -= OnDead;
            Qurre.Events.Player.PickupItem -= OnPickupItem;
        }
        public void OnRoundStart()
        {
            if (CustomConfig.IsNeedSpawn) HookItem = new Item(ItemType.Flashlight).Spawn(Map.Pickups.RandomItem().Position + Vector3.up * 1);
        }
        public void OnDead(DeadEvent ev)
        {
            if (ev.Target == Person) HookItem = new Item(ItemType.Flashlight).Spawn(ev.Target.Position);
        }
        public void OnPickupItem(PickupItemEvent ev)
        {
            if (ev.Pickup == HookItem)
            {
                ev.Player.Broadcast(CustomConfig.PickupText, 5);
                Person = ev.Player;
                ev.Allowed = false;
                ev.Pickup.Destroy();
            }
        }
    }
}