using Terraria;
using Terraria.ModLoader;

namespace QuickSlotSwap
{
    public class QuickSlotSwap : Mod
    {
        public static ModKeybind SwapHotkey { get; private set; }

        public override void Load()
        {
            SwapHotkey = KeybindLoader.RegisterKeybind(this, "SlotSwap", "Q");
        }

        public override void Unload()
        {
            SwapHotkey = null;
        }
    }
}