using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Subclassesplus.Content.ShotgunExpansion.Items.Weapons.PreBoss
{
	public class LeadFlintlockShotgun : ModItem
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
			Item.useTime = 34; // The item's use time in ticks (60 ticks == 1 second.)
			Item.useAnimation = 34; // The length of the item's use animation in ticks (60 ticks == 1 second.)
			Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
			Item.autoReuse = false; // Whether or not you can hold click to automatically use it again.
			Item.UseSound = SoundID.Item36; // The sound that this item plays when used.

			// Weapon Properties
			Item.DamageType = DamageClass.Ranged; // Sets the damage type to ranged.
			Item.damage = 4;
			Item.crit = 0;
			Item.knockBack = 3f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			Item.noMelee = true; // So the item's animation doesn't do damage.
			Item.useAmmo = AmmoID.Bullet;
			// Gun Properties
			Item.shoot = ProjectileID.PurificationPowder; // For some reason, all the guns in the vanilla source have this.
			Item.shootSpeed = 7f; // The speed of the projectile (measured in pixels per frame.)
			Item.useAmmo = AmmoID.Bullet; // The "ammo Id" of the ammo item that this weapon uses. Ammo IDs are magic numbers that usually correspond to the item id of one item that most commonly represent the ammo type.
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			const int NumberOfProjectiles = 3; // The number of projectiles that this gun will shoot.

			for (int i = 0; i < NumberOfProjectiles; i++) {
				// Rotate the velocity randomly by 30 degrees at max.
				Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(15));
				 
				// Decrease velocity randomly for nicer visuals.
				newVelocity *= 1f - Main.rand.NextFloat(0.3f);

				// Create a projectile.
				Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
			}

			return false; // Return false because we don't want tModLoader to shoot projectile
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			Recipe.Create(ModContent.ItemType<Content.ShotgunExpansion.Items.Weapons.PreBoss.LeadFlintlockShotgun>())
				.AddIngredient(ItemID.LeadBar, 8)
				.AddIngredient(ItemID.Wood, 2)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}
