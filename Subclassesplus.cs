using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Subclassesplus.Content.SuperDummy.NPCs;

//Thanks Boaphlipsy for this code (https://github.com/Boaphlipsy/SuperDummy)

namespace Subclassesplus.Content.SuperDummy
{
    public class Subclassesplus : Mod
    {
        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            byte messageType = reader.ReadByte();

            switch (messageType)
            {
                case 1:
                    if (Main.netMode == NetmodeID.Server)
                    {
                        for (int i = 0; i < Main.maxNPCs; i++)
                        {
                            if (Main.npc[i].active && Main.npc[i].type == ModContent.NPCType<SuperDummyNPC>())
                            {
                                NPC npc = Main.npc[i];
                                npc.life = 0;
                                npc.HitEffect();
                                npc.StrikeNPCNoInteraction(int.MaxValue, 0, 0, false, false, false);

                                if (Main.netMode == NetmodeID.Server)
                                {
                                    NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, i);
                                }
                            }
                        }
                    }
                    break;

                default:
                    break;
            }
        }
    }
}