using Microsoft.Xna.Framework;
using Subclassesplus.Content.SuperDummy.NPCs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Terraria.ModLoader.Config;


namespace Subclassesplus.Common.Configs.SuperDummy
{
	[BackgroundColor(73, 93, 112)]
	[Label("Dev Configuration")]
	public class SuperDummyConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("Super Dummy Config")]

        [Label("[i/p0:156]  Dummy defense")]
        [Tooltip("0 is the defense of a slime, 70 is the defense of Moon Lord's core for comparation.")]
        [Increment(1)]
		[Range(0, 9999)]
        [DefaultValue(0)]
        [SliderColor(120, 239, 148)]
        [DrawTicks]
        [BackgroundColor(91, 196, 181)]
        public int DefenseModifierConfig = SuperDummyNPC.DefenseModifierNPC;

	}
}
