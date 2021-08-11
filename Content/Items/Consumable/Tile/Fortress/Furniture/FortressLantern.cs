using QwertyMod.Content.Items.Consumable.Tile.Fortress.BuildingBlocks;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

using static Terraria.ModLoader.ModContent;
namespace QwertyMod.Content.Items.Consumable.Tile.Fortress.Furniture
{
    public class FortressLantern : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 34;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = 250;
            Item.createTile = TileType<FortressLanternT>();
        }

        public override void AddRecipes()
        {
            CreateRecipe().AddIngredient(ItemType<FortressBrick>(), 6)
                .AddIngredient(ItemID.Torch)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}