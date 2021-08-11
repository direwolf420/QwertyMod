using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace QwertyMod.Content.Items.Consumable.Tile.Trophy.Hydra
{
    public class HydraTrophy : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = 50000;
            Item.createTile = TileType<HydraTrophyT>();
            Item.placeStyle = 0;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hydra Trophy");
            Tooltip.SetDefault("");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
    }
}