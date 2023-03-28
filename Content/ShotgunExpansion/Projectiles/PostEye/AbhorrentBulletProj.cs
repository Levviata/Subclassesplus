using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

//TODO: Make non-shotgun subclass deal 40-50% less damage when slowing down

namespace Subclassesplus.Content.ShotgunExpansion.Projectiles.PostEye
{
	public class AbhorrentBulletProj : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Abhorrent Bullet"); // The English name of the projectile
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.Bullet);
			AIType = ProjectileID.Bullet;
			Projectile.penetrate = 2;
		}

		int Tick = 0;
		const int FirstHalfRepetitions = 2;
		const int SecondHalfRepetitions = 3;
		const int ThirdHalfRepetitions = 2;

		public override async void AI()
        {
			Tick++;

			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 30;

			if (Tick == 12) { 
					for (int i = 0; i <= FirstHalfRepetitions; i++)
					{
					Projectile.velocity.X *= 0.6f;
					Projectile.velocity.Y *= 0.6f;
					}
			}
			if (Tick == 18) { 
					for (int i = 0; i <= SecondHalfRepetitions; i++)
					{
					Projectile.velocity.X *= 1f;
					Projectile.velocity.Y *= 1f;
					}
			}
			if (Tick == 26) {
				Projectile.usesLocalNPCImmunity = false;
					for (int i = 0; i <= ThirdHalfRepetitions; i++)
					{

					Projectile.velocity.X *= 1.7f;
					Projectile.velocity.Y *= 1.7f;
					}

			}
		}

        /*int Time = 0;
		 * 
		public override void AI() // First attempt at making custom AI, how did it go? Well...
        {
			Time++;
			if (Time == 30) {
				if (Projectile.owner == Main.myPlayer) {
					for (int i = 0; i < 3; i++) {
					// Calculate new speeds for other projectiles.
					// Rebound at 40% to 70% speed, plus a random amount between -8 and 8
						float speedX = -Projectile.velocity.X * 1f;
						float speedY = -Projectile.velocity.Y * 1f;

						// Spawn the Projectile.
						Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + speedX, Projectile.position.Y + speedY, speedX, speedY, ProjectileID.BulletHighVelocity, (int)(Projectile.damage * 0.5), 0f, Projectile.owner, 0f, 0f);
					}
				}
			}
		}*/
        public override void Kill(int timeLeft) {
			// This code and the similar code above in OnTileCollide spawn dust from the tiles collided with. SoundID.Item10 is the bounce sound you hear.
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			SoundEngine.PlaySound(SoundID.Item10, Projectile.position);

		}
	}
}