using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Subclassesplus.Content.SuperDummy.Projectiles;
using Subclassesplus.Content.SuperDummy.NPCs;
using System.Collections.Generic;

//Thanks Boaphlipsy for this code (https://github.com/Boaphlipsy/SuperDummy)

namespace Subclassesplus.Content.SuperDummy.Items
{
    class SuperDummyItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Super Dummy");
            Tooltip.SetDefault("Spawns a super dummy at your cursor\n" +
                "Can be detected by minions and homing prjectiles\n" +
                "Right click to remove all spawned super dummies");

            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine tooltip = new TooltipLine(Mod, "ExampleMod: HotPatato", $"You have {timer / 60f:N1} seconds left!") { OverrideColor = Color.Red };
            tooltips.Add(tooltip);
        }
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 30;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.rare = ItemRarityID.Blue;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool? UseItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                if (player.altFunctionUse == ItemAlternativeFunctionID.ActivatedAndUsed)
                {
                    if (Main.netMode == NetmodeID.SinglePlayer)
                    {
                        for (int i = 0; i < Main.maxNPCs; i++)
                        {
                            if (Main.npc[i].active && Main.npc[i].type == ModContent.NPCType<SuperDummyNPC>())
                            {
                                NPC npc = Main.npc[i];
                                npc.life = 0;
                                npc.HitEffect();
                                npc.StrikeNPCNoInteraction(int.MaxValue, 0, 0, false, false, false);
                                SoundEngine.PlaySound(SoundID.Dig, npc.position);
                            }
                        }
                    }
                    else if (Main.netMode == NetmodeID.MultiplayerClient)
                    {
                        for (int i = 0; i < Main.maxNPCs; i++)
                        {
                            if (Main.npc[i].active && Main.npc[i].type == ModContent.NPCType<SuperDummyNPC>())
                            {
                                SoundEngine.PlaySound(SoundID.Dig, Main.npc[i].position);
                            }
                        }
                        var net = Mod.GetPacket();
                        net.Write((byte)1);
                        net.Send();
                    }
                }
                else
                {
                    Vector2 pos = new Vector2((int)Main.MouseWorld.X, (int)Main.MouseWorld.Y - 20);
                    Projectile.NewProjectile(player.GetSource_ItemUse(Item), pos, Vector2.Zero, ModContent.ProjectileType<DummySpawn>(), 0, 0, player.whoAmI, ModContent.NPCType<SuperDummyNPC>());
                }
            }

            return true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.TargetDummy, 1);
            recipe.AddIngredient(ItemID.ManaCrystal, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
