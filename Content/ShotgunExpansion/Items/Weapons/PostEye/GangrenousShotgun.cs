using Subclassesplus.Content.ShotgunExpansion.Projectiles.PostEye;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Subclassesplus.Content.ShotgunExpansion.Items.Weapons.PostEye
{
	public class GangrenousShotgun : ModItem
	{ 
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			// Common Properties
			Item.width = 40; // Hitbox width of the item.
			Item.height = 20; // Hitbox height of the item.
			Item.rare = ItemRarityID.Blue; // The color that the item's name will be in-game.

			// Use Properties
			Item.useTime = 32; // The item's use time in ticks (60 ticks == 1 second.)
			Item.useAnimation = 32; // The length of the item's use animation in ticks (60 ticks == 1 second.)
			Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
			Item.autoReuse = false; // Whether or not you can hold click to automatically use it again.
			Item.UseSound = SoundID.DD2_BallistaTowerShot; // The sound that this item plays when used.

			// Weapon Properties
			Item.DamageType = DamageClass.Ranged; // Sets the damage type to ranged.
			Item.damage = 6; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			Item.crit = 0;
			Item.knockBack = 5f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			Item.noMelee = true; // So the item's animation doesn't do damage.%A
			// Gun Properties
			Item.shoot = ModContent.ProjectileType<AbhorrentBulletProj>(); // For some reason, all the guns in the vanilla source have this.
			Item.shootSpeed = 7f; // The speed of the projectile (measured in pixels per frame.)
			Item.useAmmo = AmmoID.Bullet; // The "ammo Id" of the ammo item that this weapon uses. Ammo IDs are magic numbers that usually correspond to the item id of one item that most commonly represent the ammo type.
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {

			Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(10));

			Projectile.NewProjectileDirect(source, position, velocity, ModContent.ProjectileType<DreadfulBulletProj>(), damage, knockback, player.whoAmI);
			
			return false;
		}
		public override void AddRecipes() {
			Recipe.Create(ModContent.ItemType<PreBoss.TungstenFlintlockShotgun>())
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
