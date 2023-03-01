using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Subclassesplus.Content.ShotgunExpansion.Items.Weapons.PreBoss
{
	public class PlatinumFlintlockShotgun : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {

			// Common Properties
			Item.width = 40; // Hitbox width of the item.
			Item.height = 20; // Hitbox height of the item.
			Item.rare = ItemRarityID.White; // The color that the item's name will be in-game.

			// Use Properties
			Item.useTime = 32;
			Item.useAnimation = 32;
			Item.useStyle = ItemUseStyleID.Shoot; 
			Item.autoReuse = false; 
			Item.UseSound = SoundID.Item36;

			// Weapon Properties
			Item.DamageType = DamageClass.Ranged; 
			Item.damage = 8; 
			Item.crit = 0;
			Item.knockBack = 3f; 
			Item.noMelee = true; 
			Item.useAmmo = AmmoID.Bullet;

			// Gun Properties
			Item.shoot = ProjectileID.PurificationPowder; 
			Item.shootSpeed = 7f;
			Item.useAmmo = AmmoID.Bullet; 
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			const int NumberOfProjectiles = 3; // The number of projectiles that this gun will shoot.

			for (int i = 0; i < NumberOfProjectiles; i++) {
				// Rotate the velocity randomly by 30 degrees at max.
				Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(10));
				 
				// Decrease velocity randomly for nicer visuals.
				newVelocity *= 1f - Main.rand.NextFloat(0.3f);

				// Create a projectile.
				Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
			}

			return false; // Return false because we don't want tModLoader to shoot projectile
		}
		public override void AddRecipes() {
			Recipe.Create(ModContent.ItemType<Content.ShotgunExpansion.Items.Weapons.PreBoss.PlatinumFlintlockShotgun>())
				.AddIngredient(ItemID.PlatinumBar, 8)
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
