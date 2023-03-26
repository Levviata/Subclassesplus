using Microsoft.Xna.Framework;
using Subclassesplus.Content.ShotgunExpansion.Projectiles.PostEye;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Subclassesplus.Content.ShotgunExpansion.Items

{
    public class MinisharkClone : ModItem
	{
        public override string Texture => $"Terraria/Images/Item_{ItemID.Minishark}";
        public override void SetStaticDefaults() {
			Tooltip.SetDefault("");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
            // Common Properties
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;
            Item.useAnimation = 8;
            Item.useTime = 8;
            Item.width = 50;
            Item.height = 18;
            Item.useAmmo = AmmoID.Bullet;
            Item.UseSound = SoundID.Item11;
            Item.damage = 6;
            Item.shoot = ItemID.PurificationPowder;
            Item.shootSpeed = 7f;
            Item.noMelee = true;
            Item.value = 350000;
            Item.rare = ItemRarityID.Green;
            Item.DamageType = DamageClass.Ranged;
        }
        public override void ModifyHitNPC(Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
        {
            int targetDefense = target.defense;
            int armorPenetrationBonus = 0;

            if (targetDefense % 2 != 0 && targetDefense > 7 && targetDefense < 21)
            {
                armorPenetrationBonus = (targetDefense - 7) / 2 + 1;
                player.GetArmorPenetration(DamageClass.Ranged) += armorPenetrationBonus;
            }
            else if (targetDefense >= 21)
            {
                player.GetArmorPenetration(DamageClass.Ranged) += 10;
            }
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {

            Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(3));

            Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);

            return false; // Return false because we don't want tModLoader to shoot projectile
		}
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5, -1.5f);
        }
    }
}
