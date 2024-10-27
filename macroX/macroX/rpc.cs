using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordRPC;

namespace macroX
{
    internal class rpc
    {
        public static DiscordRpcClient client;
        public static Timestamps rpctimestamp { get; set; }
        private static RichPresence presence;
        public static void InitializeRPC()
        {
            client = new DiscordRpcClient("1295192091248427018");
            client.Initialize();
            Button[] buttons = {
                new Button() { Label = "Discord Server", Url = "https://discord.gg/zCQ8jQ2GBf" },
                new Button() { Label = "$", Url = "https://dsc.gg/zenxcorpp" }
            };

            presence = new RichPresence()
            {
                Details = "Doble Clic, Autoclick & more...",
                State = "by $ ZenX Corp - https://dsc.gg/zenxcorpp",
                Timestamps = rpctimestamp,
                Buttons = buttons,

                Assets = new Assets()
                {
                    LargeImageKey = "macrox",
                    LargeImageText = "by $ ZenX Corp",
                    SmallImageKey = "",
                    SmallImageText = ""
                }
            };
            SetState("by $ ZenX Corp - https://dsc.gg/zenxcorpp");
        }
        public static void SetState(string state)
        {
            presence.State = state;
            client.SetPresence(presence);
        }
    }
}
