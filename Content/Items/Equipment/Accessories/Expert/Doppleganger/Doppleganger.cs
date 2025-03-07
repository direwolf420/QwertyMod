﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace QwertyMod.Content.Items.Equipment.Accessories.Expert.Doppleganger
{
    public class Doppleganger : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Doppleganger");
            Tooltip.SetDefault("Pretends to be the accesory placed above it.\nThe gods forbid equiping the same accesory twice!\nTampering with such an unusual artifact is not advised.");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.rare = 3;
            Item.expert = true;
            Item.value = 500000;
            Item.width = 32;
            Item.height = 22;
            Item.GetGlobalItem<DoppleItem>().isDoppleganger = true;
        }
        public override bool PreReforge()
        {
            Player player = Main.LocalPlayer;
            if (player.difficulty != 2)
            {
                player.KillMe(PlayerDeathReason.ByCustomReason(player.name + " tampered with forces beyond " + (player.Male ? "his" : "her") + " control!"), 1000, 0);
            }
            else
            {
                Main.NewText("You shouldn't tamper with things beyond your control!", Color.Red);
            }
            for (int n = 0; n < 200; n++)
            {
                if (Main.npc[n].active && Main.npc[n].type == NPCID.GoblinTinkerer)
                {
                    Main.npc[n].StrikeNPC(999, 0f, 0);
                }
            }
            return false;
        }

        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            int mimicId = -1;
            Player player = Main.LocalPlayer;
            for (int a = 4; a < 10; a++)
            {
                if (!player.armor[a].IsAir && player.armor[a] == Item && !player.armor[a - 1].IsAir)
                {
                    mimicId = player.armor[a - 1].type;
                }
            }
            Texture2D texture = TextureAssets.Item[Item.type].Value;
            if (mimicId != -1)
            {
                //spriteBatch.Draw(texture, position, null, Color.White, 0, origin, scale, SpriteEffects.None, 0f);;

                Texture2D mimicTexture = TextureAssets.Item[mimicId].Value;
                int frameCount = 1;
                if (Main.itemAnimations[mimicId] != null)
                {
                    frameCount = Main.itemAnimations[mimicId].FrameCount;
                }
                float greaterLength = Math.Max(mimicTexture.Width, mimicTexture.Height / frameCount);
                spriteBatch.Draw(mimicTexture, position + Vector2.UnitY * -3, new Rectangle(0, 0, mimicTexture.Width, mimicTexture.Height / frameCount), new Color(180, 100, 100, 255), 0, origin, (44f / greaterLength) * scale, SpriteEffects.None, 0f);

                return false;
            }

            return true;
        }
    }

    public class DoppleItem : GlobalItem
    {
        public bool isDoppleganger = false;
        public override bool InstancePerEntity => true;
        public override GlobalItem Clone(Item item, Item itemClone)
        {
            return base.Clone(item, itemClone);
        }
    }

    public class DopplePlayer : ModPlayer
    {
        public override void PreUpdate()
        {
            for (int a = 4; a < 10; a++)
            {
                if (!Player.armor[a].IsAir && Player.armor[a].type == ItemType<Doppleganger>() && !Player.armor[a - 1].IsAir)
                {
                    Player.armor[a].type = Player.armor[a - 1].type;
                }
            }
        }
        public override void UpdateEquips()
        {
            for (int a = 4; a < 10; a++)
            {
                if (!Player.armor[a].IsAir && Player.armor[a].GetGlobalItem<DoppleItem>().isDoppleganger)
                {
                    if (!Player.armor[a - 1].IsAir)
                    {
                        ItemLoader.UpdateAccessory(Player.armor[a - 1], Player, Player.hideVisibleAccessory[a]);
                        ItemLoader.UpdateEquip(Player.armor[a - 1], Player);
                        Player.statDefense += Player.armor[a - 1].defense;
                    }
                }
            }
        }

        public override void PostUpdateEquips()
        {
            for (int a = 4; a < 10; a++)
            {
                if (!Player.armor[a].IsAir && Player.armor[a].GetGlobalItem<DoppleItem>().isDoppleganger)
                {
                    Player.armor[a].type = ItemType<Doppleganger>();
                }
            }
        }
    }
}