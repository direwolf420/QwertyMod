using Terraria;
using Terraria.ModLoader;

namespace QwertyMod.Content.Dusts
{
    public class CaeliteDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = false;
            dust.noLight = true;
            dust.scale = 1f;
            dust.noGravity = true;
        }
    }
}