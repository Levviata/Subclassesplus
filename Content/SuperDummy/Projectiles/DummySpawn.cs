﻿using Terraria;
using Terraria.ModLoader;

//Thanks Boaphlipsy for this code (https://github.com/Boaphlipsy/SuperDummy)

namespace Subclassesplus.Content.SuperDummy.Projectiles
{
    class DummySpawn : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dummy Spawn");
        }

        public override void SetDefaults()
        {
            Projectile.width = 2;
            Projectile.height = 2;
            Projectile.aiStyle = -1;
            Projectile.timeLeft = 1;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.hide = true;
        }

        public override bool? CanDamage()
        {
            return false;
        }

        public override void Kill(int timeLeft)
        {
            NPC.NewNPC(NPC.GetBossSpawnSource(Main.myPlayer), (int)Projectile.Center.X, (int)Projectile.Center.Y, (int)Projectile.ai[0]);
        }
    }
}
