using Terraria.GameInput;
using Terraria.ModLoader;
using Subclassesplus.Common.Systems;
using Subclassesplus.Common.Configs.SuperDummy;
using Subclassesplus.Content.SuperDummy.NPCs;

namespace Subclassesplus.Common.Playersz
{
	// See Common/Systems/KeybindSystem for keybind registration.
	public class SuperDummyPlayer : ModPlayer
	{
		public override void ProcessTriggers(TriggersSet triggersSet)
		{
            if (KeybindSystem.AddDummyDefenseKeybind.JustPressed)
            {
                var DefenseModifierPlayer = SuperDummyNPC.DefenseModifierNPC;
				DefenseModifierPlayer++;
            }
        }		
	}
}
	
