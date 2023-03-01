using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Subclassesplus.Content.ShotgunExpansion.Projectiles.PostEye
{
	public class DreadfulBulletProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dreadful Bullet"); // The English name of the projectile
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.Bullet);
			AIType = ProjectileID.Bullet;
			Projectile.timeLeft = 30;
		}

		int Tick = 0;
        public override void AI()
        {
			Tick++;

				if (Tick == 10) {
				Projectile.velocity.RotatedBy(MathHelper.ToRadians(5));
				}
				if (Tick == 20) {
				Projectile.velocity.RotatedBy(MathHelper.ToRadians(10));
				}
				if (Tick == 30) {
				Projectile.velocity.RotatedBy(MathHelper.ToRadians(-15));
				}
        }
        public override void Kill(int timeLeft)
		{
			// This code and the similar code above in OnTileCollide spawn dust from the tiles collided with. SoundID.Item10 is the bounce sound you hear.
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			SoundEngine.PlaySound(SoundID.Item10, Projectile.position);

			// Spawn projectile

			const int NumberOfProjectiles = 3;

			for (int i = 1; i <= NumberOfProjectiles; i++){
				Vector2 velocity = Projectile.velocity.RotatedBy(MathHelper.ToRadians(-5 + (i * 5)));
				Vector2 position = Projectile.Center;
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, velocity, ProjectileID.Bullet, (int)(Projectile.damage * 0.5), 0f, Projectile.owner, 0f, 0f);
			}
		}
	}
}