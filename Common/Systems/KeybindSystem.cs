using Terraria.ModLoader;

namespace Subclassesplus.Common.Systems
{
	// Acts as a container for keybinds registered by this mod.
	// See Common/Players/ExampleKeybindPlayer for usage.
	public class KeybindSystem : ModSystem
	{
		public static ModKeybind AddDummyDefenseKeybind { get; private set; }
		public static ModKeybind RetractDummyDefenseKeybind { get; private set; }

		public override void Load() {
            // Registers a new keybind
            AddDummyDefenseKeybind = KeybindLoader.RegisterKeybind(Mod, "Add Defense Super Dummy", "OemComma");

            RetractDummyDefenseKeybind = KeybindLoader.RegisterKeybind(Mod, "Retract Defense Super Dummy", "OemPeriod");
        }

		// Please see ExampleMod.cs' Unload() method for a detailed explanation of the unloading process.
		/*public override void Unload() {
            // Not required if your AssemblyLoadContext is unloading properly, but nulling out static fields can help you figure out what's keeping it loaded.
            AddDummyDefenseKeybind = null;
		}*/
	}
}
