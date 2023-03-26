using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using Terraria;
using Terraria.ModLoader.Config;


namespace Subclassesplus.Common.Configs.SupperDummy
{
	[BackgroundColor(99, 180, 209)]
	[Label("ModConfig Showcase B: Ranges")]
	public class SuperDummyConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ClientSide;

        [Label("Test")]
        [Tooltip("0 is the defense of a slime, 70 is the defense of Moon Lord's core.")]
        [Increment(1)]
		[Range(0, 70)]
        [DrawTicks]
        [DefaultValue(100)]
		[Slider] // The Slider attribute makes this field be presented with a slider rather than a text input. The default ticks is 1.
		public int DefenseModifier;
	}
}
