﻿using QwertyMod.Content.NPCs.Bosses.TundraBoss;
using QwertyMod.Content.Items.Consumable.Tiles.Trophy;
using QwertyMod.Content.Items.Equipment.Vanity.BossMasks;
using QwertyMod.Content.Items.Weapon.Magic.PenguinWhistle;
using QwertyMod.Content.Items.Weapon.Melee.Sword;
using QwertyMod.Content.Items.Weapon.Ranged.SpecialAmmo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using QwertyMod.Content.Items.Equipment.Accessories.Expert;
using Terraria.DataStructures;

namespace QwertyMod.Content.Items.Consumable.BossBag
{
    public class TundraBossBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Treasure Bag");
            Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
        }

        public override void SetDefaults()
        {
            Item.maxStack = 999;
            Item.consumable = true;
            Item.width = 60;
            Item.height = 34;
            Item.rare = 9;
            Item.expert = true;
        }

        public override int BossBagNPC => NPCType<PolarBear>();

        public override bool CanRightClick()
        {
            return true;
        }

        public override void OpenBossBag(Player player)
        {
            if (Main.rand.Next(7) == 0)
            {
                player.QuickSpawnItem(new EntitySource_Misc(""), ItemType<PolarMask>());
            }
            switch (Main.rand.Next(3))
            {
                case 0:
                    player.QuickSpawnItem(new EntitySource_Misc(""), ItemType<PenguinClub>());
                    break;

                case 1:
                    player.QuickSpawnItem(new EntitySource_Misc(""), ItemType<PenguinLauncher>());
                    break;

                case 2:
                    player.QuickSpawnItem(new EntitySource_Misc(""), ItemType<PenguinWhistle>());
                    break;
            }
            player.QuickSpawnItem(new EntitySource_Misc(""), ItemType<PenguinGenerator>());
            player.QuickSpawnItem(new EntitySource_Misc(""), ItemID.Penguin, Main.rand.Next(40, 81));
            player.QuickSpawnItem(new EntitySource_Misc(""), 73, 4);
        }
    }
}
