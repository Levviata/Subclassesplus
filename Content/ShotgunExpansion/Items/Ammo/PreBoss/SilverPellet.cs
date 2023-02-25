using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Subclassesplus.Content.ShotgunExpansion.Items.Ammo.PreBoss
{
	public class SilverPellet : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("This is an example sword");

			//DisplayName.SetDefault("");
			/* Use \n to make new lines. By default mayus letters create
			an space so this is not often needed */

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
			// Amount needed to duplicate in journey mode
		}
		/*

		<8	Insanely Fast
		9–20	Very Fast
		21–25	Fast
		26–30	Average
		31–35	Slow
		36–45	Very Slow
		46–55	Extremely Slow
		>56	Snail

		0	No knockback
		0.1 to 1.5	Extremely weak knockback
		1.6 to 3	Very weak knockback
		3.1 to 4	Weak knockback
		4.1 to 6	Average knockback
		6.1 to 7	Strong knockback
		7.1 to 9	Very strong knockback
		9.1 to 11	Extremely strong knockback
		Above 11	Insane knockback
		*/
		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;

			Item.DamageType = DamageClass.Ranged; // Ranged, Magic, etc. ModContent.GetInstance<ExampleDamageClass>();
			Item.damage = 7;
			//Item.crit = 6; // 6% + 4% (default crit) = 8% crit chance
			Item.maxStack = 9999;
			Item.knockBack = 1.6f; // Average knockback
			Item.shootSpeed = 7f; // Chlorophyte Shotbow velocity of 11.5f + Wooden Arrows velocity of 3f = 14.5
			Item.shoot = ProjectileID.Bullet;
			Item.consumable = true;
			Item.ammo = AmmoID.Bullet; // ModContent.ItemType<ExampleCustomAmmo>();
			//Item.mana = 10; // Mana cost

			//Item.channel = true; // Whether it channels (hold in / hold out)
			//Item.noMelee = true; // Weapon is not melee so it doesnt deal damage by swinging
			//Item.noUseGraphic = true; // Graphic not visible	
			Item.value = Item.buyPrice(copper: 0, silver: 0, gold: 0, platinum: 0);
			Item.rare = ItemRarityID.White; // ModContent.RarityType<ExampleModRarity>();
		}

		public override void AddRecipes()
		{
			Recipe.Create(ModContent.ItemType<Content.ShotgunExpansion.Items.Ammo.PreBoss.SilverPellet>(), 90)
				.AddIngredient(ItemID.SilverBar, 2)
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