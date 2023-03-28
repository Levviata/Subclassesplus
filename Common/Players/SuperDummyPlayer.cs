using Terraria.GameInput;
using Terraria.ModLoader;
using Subclassesplus.Common.Systems;
using Subclassesplus.Common.Configs.SuperDummy;

namespace Subclassesplus.Common.Playersz
{
	// See Common/Systems/KeybindSystem for keybind registration.
	public class SuperDummyPlayer : ModPlayer
	{
		public override void ProcessTriggers(TriggersSet triggersSet)
		{
            if (KeybindSystem.AddDummyDefenseKeybind.JustPressed)
            {
                int DefenseModifier = ModContent.GetInstance<SuperDummyConfig>().DefenseModifier;
				DefenseModifier++;
            }
        }		
	}
}
	
