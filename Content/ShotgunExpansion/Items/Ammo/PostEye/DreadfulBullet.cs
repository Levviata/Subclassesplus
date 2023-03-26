using Subclassesplus.Content.ShotgunExpansion.Projectiles.PostEye;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Subclassesplus.Content.ShotgunExpansion.Items.Ammo.PostEye
{
	public class DreadfulBullet : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Explodes after penetrating four foes");

			//DisplayName.SetDefault("");
			/* Use \n to make new lines. By default mayus letters create
			an space so this is not often needed */

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
			// Amount needed to duplicate in journey mode
		}
		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;

			Item.DamageType = DamageClass.Ranged; // Ranged, Magic, etc. ModContent.GetInstance<ExampleDamageClass>();
			Item.damage = 7;
			//Item.crit = 6; // 6% + 4% (default crit) = 8% crit chance
			Item.maxStack = 9999;
			Item.knockBack = 1f; // Average knockback
			Item.shootSpeed = 7f; // Chlorophyte Shotbow velocity of 11.5f + Wooden Arrows velocity of 3f = 14.5
			Item.shoot = ModContent.ProjectileType<DreadfulBulletProj>();
			Item.consumable = true;
			Item.ammo = AmmoID.Bullet; // ModContent.ItemType<ExampleCustomAmmo>();
			//Item.mana = 10; // Mana cost

			//Item.channel = true; // Whether it channels (hold in / hold out)
			//Item.noMelee = true; // Weapon is not melee so it doesnt deal damage by swinging
			//Item.noUseGraphic = true; // Graphic not visible	
			Item.value = Item.buyPrice(copper: 0, silver: 0, gold: 0, platinum: 0);
			Item.rare = ItemRarityID.Blue; // ModContent.RarityType<ExampleModRarity>();
		}

		public override void AddRecipes()
		{
			Recipe.Create(ModContent.ItemType<DreadfulBullet>(), 70)
				.AddIngredient(ItemID.DemoniteBar, 1)
				.AddIngredient(ItemID.MusketBall, 70)
				.AddTile(TileID.Anvils)
				.Register();
		}
		/*
		 public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient<ExampleItem>()
				.AddTile<Tiles.Furniture.ExampleWorkbench>()
				.Register();
		 */
	}
}