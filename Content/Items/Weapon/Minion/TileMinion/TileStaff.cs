﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace QwertyMod.Content.Items.Weapon.Minion.TileMinion
{
    public class TileStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tile Staff");
            Tooltip.SetDefault("Moving diagonally? What's that?");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true; // This lets the player target anywhere on the whole screen while using a controller
            ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.damage = 26;
            Item.mana = 20;
            Item.width = Item.height = 32;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.useStyle = 1;
            Item.noMelee = true;
            Item.rare = ItemRarityID.LightRed;
            Item.shoot = ProjectileType<TileMinion>();
            Item.DamageType = DamageClass.Summon;
            Item.buffType = BuffType<TileMinionB>();
            Item.buffTime = 3600;
            Item.knockBack = 2.5f;
            Item.value = Item.sellPrice(gold: 3);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            player.SpawnMinionOnCursor(source, player.whoAmI, type, Item.damage, knockback);
            return false;
        }

    }
}
