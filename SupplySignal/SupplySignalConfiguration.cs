﻿using Rocket.API;

namespace RestoreMonarchy.SupplySignal
{
    public class SupplySignalConfiguration : IRocketPluginConfiguration
    {
        public string MessageColor { get; set; }
        public string MessageIconUrl { get; set; }
        public ushort SupplyGrenadeId { get; set; }
        public float AirdropDelay { get; set; }
        public ushort AirdropId { get; set; }
        public float AirdropSpeed { get; set; }
        public bool ShouldBroadcast { get; set; }

        public void LoadDefaults()
        {
            MessageColor = "yellow";
            MessageIconUrl = string.Empty;
            SupplyGrenadeId = 14950;
            AirdropDelay = 5;
            AirdropId = 23412;
            AirdropSpeed = 128;
            ShouldBroadcast = true;
        }
    }
}