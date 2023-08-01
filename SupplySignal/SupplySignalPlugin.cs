using Rocket.API.Collections;
using Rocket.Core.Plugins;
using Rocket.Unturned.Chat;
using SDG.Unturned;
using System;
using System.Collections;
using UnityEngine;
using Logger = Rocket.Core.Logging.Logger;

namespace RestoreMonarchy.SupplySignal
{
    public class SupplySignalPlugin : RocketPlugin<SupplySignalConfiguration>
    {
        public Color MessageColor { get; set; }

        protected override void Load()
        {
            MessageColor = UnturnedChat.GetColorFromName(Configuration.Instance.MessageColor, Color.green);
            UseableThrowable.onThrowableSpawned += OnThrowableSpawned;
            Logger.Log($"{Name} {Assembly.GetName().Version} has been loaded!", ConsoleColor.Yellow);
        }

        protected override void Unload()
        {
            UseableThrowable.onThrowableSpawned -= OnThrowableSpawned;
            Logger.Log($"{Name} has been unloaded!", ConsoleColor.Yellow);
        }

        public override TranslationList DefaultTranslations => new TranslationList()
        {
            { "BroadcastAirdrop", "{0} called in airdrop!" }
        };

        private void OnThrowableSpawned(UseableThrowable useable, GameObject throwable)
        {
            if (useable.equippedThrowableAsset.id == Configuration.Instance.SupplyGrenadeId)
                StartCoroutine(CallAirdrop(throwable.transform, useable.player.channel.owner.playerID.playerName));
        }

        IEnumerator CallAirdrop(Transform transform, string playerName)
        {
            if (Configuration.Instance.ShouldBroadcast)
            {
                string message = Translate("BroadcastAirdrop", playerName);
                message = message.Replace("[[", "<").Replace("]]", ">");
                string iconUrl = string.IsNullOrEmpty(Configuration.Instance.MessageIconUrl) ? null : Configuration.Instance.MessageIconUrl;
                ChatManager.serverSendMessage(message, MessageColor, null, null, EChatMode.SAY, iconUrl, true);
            }
                
            yield return new WaitForSeconds(Configuration.Instance.AirdropDelay);
            LevelManager.airdrop(transform.position, Configuration.Instance.AirdropId, Configuration.Instance.AirdropSpeed);
        }
    }
}
