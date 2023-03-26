using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
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

        int TimesHitNpc = 0;
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.Bullet);
            AIType = ProjectileID.Bullet;
            Projectile.penetrate = 5;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            TimesHitNpc++;

            /*Projectile.velocity.X *= 1.1f;
            Projectile.velocity.Y *= 1.1f;*/

            if (Projectile.owner != Main.myPlayer || Main.player[Projectile.owner].HeldItem.damage <= 30)
            {
                Projectile.damage = (int)(Projectile.damage * 0.95f);
            }
            else
            {
                Projectile.damage = (int)(Projectile.damage * 0.85f);
            }

            Player player = Main.player[Projectile.owner];
            if (player.inventory[player.selectedItem].type == ItemID.Musket)
            {
                Projectile.damage = (int)(Projectile.damage * 0.775f);
            }

            /*if (TimesHitNpc == 4)
            {
                Projectile.velocity.Y *= 1.5f;

                SoundEngine.PlaySound(SoundID.AbigailUpgrade, Projectile.position);

                Projectile.damage = 1;

            }*/

            if (TimesHitNpc == 5) //TODO: Clean up the cementery of ideas, make this bullet scale with the weapon's damage, add particles when TimesHitNpc == 4
            {
                TimesHitNpc = 0;

                if (Projectile.owner != Main.myPlayer || Main.player[Projectile.owner].HeldItem.damage <= 30)
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ProjectileID.ExplosiveBullet, Projectile.damage = 5, Projectile.knockBack, Projectile.owner, 0f, 0f);
                }
                else
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ProjectileID.ExplosiveBullet, Projectile.damage = 10, Projectile.knockBack, Projectile.owner, 0f, 0f);
                }
            }
            if (Projectile.damage < 0)
            {
                Projectile.damage = 1;
            }
        }

        /*public override void Kill(int timeLeft)
         {
                 Projectile.damage = OrgProjDamage;

                 if (Projectile.owner != Main.myPlayer || Main.player[Projectile.owner].HeldItem.damage <= 30)
                 {
                     // Reduce the damage of the projectile by 5%
                     Projectile.damage = (int)(Projectile.damage * 0.75f);
                 }
                 else
                 {
                     // Reduce the damage of the projectile by 15%
                     Projectile.damage = (int)(Projectile.damage * 0.70f);
                 }
                 Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ProjectileID.ExplosiveBullet, Projectile.damage, Projectile.knockBack, Projectile.owner, 0f, 0f);
             }
         }

         public override void AI()
         {
             for (int i = 0; i < Main.npc.Length; i++)
             {
                 NPC target = Main.npc[i];
                 if (target.active && !target.friendly && Projectile.Hitbox.Intersects(target.Hitbox))
                 {
                     if (Projectile.penetrate == 5)
                     {
                         if (Projectile.owner != Main.myPlayer || Main.player[Projectile.owner].HeldItem.damage <= 30)
                         {
                             // Reduce the damage of the projectile by 5%
                             OrgProjectileDamage = (int)(Projectile.damage * 0.95f) * 4;
                         }
                         else
                         {
                             // Reduce the damage of the projectile by 15%
                             OrgProjectileDamage = (int)(Projectile.damage * 0.90f) * 4;
                         }
                         Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ProjectileID.ExplosiveBullet, Projectile.damage, Projectile.knockBack, Projectile.owner, 0f, 0f);
                     }
                 }
             }
         }

         public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
         {
             float radius = Projectile.penetrate > 1 ? 6 : 64;
             return Projectile.Center.DistanceSQ(targetHitbox.ClosestPointInRect(Projectile.Center)) < radius * Projectile.scale * radius * Projectile.scale;
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