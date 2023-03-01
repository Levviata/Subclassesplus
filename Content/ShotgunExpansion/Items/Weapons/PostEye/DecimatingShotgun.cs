using Subclassesplus.Content.ShotgunExpansion.Projectiles.PostEye;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Subclassesplus.Content.ShotgunExpansion.Items.Weapons.PostEye
{
	public class DecimatingShotgun : ModItem
	{ 
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Bullets shoot by this shotgun quickly deaccelerate and then accelerate\ndecimating the immunity frames of foes in half while the bullets are gaining momentum.");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			// Common Properties
			Item.width = 40;
			Item.height = 20;
			Item.rare = ItemRarityID.Blue;

			// Use Properties
			Item.useTime = 37;
			Item.useAnimation = 37;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.autoReuse = false;
			Item.UseSound = SoundID.DD2_BallistaTowerShot;

			// Weapon Properties
			Item.DamageType = DamageClass.Ranged; // Sets the damage type to ranged.
			Item.damage = 6;
			Item.crit = 0;
			Item.knockBack = 5f; 
			Item.noMelee = true;

			// Gun Properties
			Item.shoot = ModContent.ProjectileType<AbhorrentBulletProj>();
			Item.shootSpeed = 7f;
			Item.useAmmo = AmmoID.Bullet;
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{

			const int NumberOfProjectiles = 3;

			if (Main.myPlayer == player.whoAmI)
			{
				for (int i = 0; i < NumberOfProjectiles; i++) {  //TODO: Make this "for" loop more readable
					Vector2 NewVelocity = velocity.RotatedBy(MathHelper.ToRadians(-5 + (i * 5)));

					if (i == 0) {
						Projectile.NewProjectileDirect(source, position, NewVelocity, ModContent.ProjectileType<AbhorrentBulletProj>(), damage, knockback, player.whoAmI);
					}
					if (i == 1) {
						NewVelocity *= 1.10f;
						Projectile.NewProjectileDirect(source, position, NewVelocity, ModContent.ProjectileType<AbhorrentBulletProj>(), damage, knockback, player.whoAmI);
					}
					if (i == 2) {
						Projectile.NewProjectileDirect(source, position, NewVelocity, ModContent.ProjectileType<AbhorrentBulletProj>(), damage, knockback, player.whoAmI);
					}
				}
			}
			return false;
		}
		public override void AddRecipes() {
			Recipe.Create(ModContent.ItemType<Content.ShotgunExpansion.Items.Weapons.PreBoss.TungstenFlintlockShotgun>())
				.AddIngredient(ItemID.TungstenBar, 8)
				.AddIngredient(ItemID.Wood, 2)
				.AddTile(TileID.Anvils)
				.Register();
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-0.5f, -1f);
		}
	}
}
