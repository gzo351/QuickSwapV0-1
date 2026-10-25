using Terraria;
using Terraria.ModLoader;

namespace QuickSlotSwap
{
    public class QuickSlotSwapPlayer : ModPlayer
    {
        public int LastSlot = -1;
        public int PrevSlot = -1;

        public override void PostUpdate()
        {
            if (QuickSlotSwap.SwapHotkey.JustPressed)
            {
                DoSwapLogic();
            }
        }

        void DoSwapLogic()
        {
            int currentSlot = Player.selectedItem;

            // 当前选中是空物品，只切换不记录
            if (Player.inventory[currentSlot].IsAir)
            {
                if (PrevSlot >= 0 && PrevSlot < 10 && !Player.inventory[PrevSlot].IsAir)
                {
                    Player.selectedItem = PrevSlot;
                }
                return;
            }

            // 目标逻辑：
            // 槽1拿A按Q → 记录A
            // 手动切槽3拿B按Q → A、B来回切
            // 手动切槽5拿C按Q → B、C来回切
            if (LastSlot != currentSlot)
            {
                PrevSlot = LastSlot;
                LastSlot = currentSlot;
            }
            else
            {
                // 同一个槽按Q，互相切换
                (LastSlot, PrevSlot) = (PrevSlot, LastSlot);
            }

            if (PrevSlot >= 0 && PrevSlot < 10)
            {
                Player.selectedItem = PrevSlot;
            }
        }
    }
}