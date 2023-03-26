using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Subclassesplus.Content.ShotgunExpansion.Projectiles.PostEye
{
	public class DreadfulBulletExplosionProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			Main.projFrames[Projectile.type] = 4;
			DisplayName.SetDefault("Dreadful Bullet Explosion"); // The English name of the projectile
		}
		// TODO: Make projectile have animation, explosion like that is
		public override void SetDefaults()
		{
			Projectile.width = 48; // The width of projectile hitbox
			Projectile.height = 48;
			Projectile.friendly = true; // Can the projectile deal damage to enemies?
			Projectile.DamageType = DamageClass.Ranged; // Is the projectile shoot by a ranged weapon?
			Projectile.ignoreWater = true; // Does the projectile's speed be influenced by water?
			Projectile.tileCollide = false; // Can the projectile collide with tiles?
			Projectile.penetrate = -1;
			Projectile.timeLeft = 30;
		}

		public override void AI()
		{
			if (++Projectile.frameCounter >= 7.5f)
			{
				Projectile.frameCounter = 0;
				// Or more compactly Projectile.frame = ++Projectile.frame % Main.projFrames[Projectile.type];
				if (++Projectile.frame >= Main.projFrames[Projectile.type])
					Projectile.frame = 0;
			}

			/*int Tick = 0;
			const int FirstHalfRepetitions = 2;
			const int SecondHalfRepetitions = 2;
			const int ThirdHalfRepetitions = 2;
			public override void AI()
			{
				Tick++;

				if (Tick == 0)
				{
					for (int i = 0; i <= FirstHalfRepetitions; i++)
					{
						Projectile.velocity.X *= 0.5f;
						Projectile.velocity.Y *= 0.5f;
					}
				}
				if (Tick == 10)
				{
					for (int i = 0; i <= SecondHalfRepetitions; i++)
					{
						Projectile.velocity.X *= 0.8f;
						Projectile.velocity.Y *= 0.8f;
					}
				}
				if (Tick == 20)
				{
					for (int i = 0; i <= ThirdHalfRepetitions; i++)
					{

						Projectile.velocity.X *= 1.3f;
						Projectile.velocity.Y *= 1.3f;
					}
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
			}*/
		}
    }
}