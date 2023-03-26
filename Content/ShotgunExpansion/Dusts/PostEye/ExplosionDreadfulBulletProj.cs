using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Subclassesplus.Content.ShotgunExpansion.Dusts.PostEye
{
	public class ExplosionDreadfulBulletProj : ModDust
	{
		public override void OnSpawn(Dust dust) {
			dust.noGravity = true; // Makes the dust have no gravity.
			dust.noLight = true; // Makes the dust emit no light.
			dust.frame = new Rectangle(0, 0, 30, 30);
		}

		int Tick = 0;
		public override bool Update(Dust dust)
		{ // Calls every frame the dust is active
			Tick++;
			dust.scale = 1.5f;

			if(Tick == 60)
            {
				dust.active = false;
				Tick = 0;
            }
			return false; // Return false to prevent vanilla behavior.
		}
	}
}
