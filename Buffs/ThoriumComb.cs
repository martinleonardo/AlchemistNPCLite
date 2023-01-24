using System.Linq;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;

namespace AlchemistNPCLite.Buffs
{
	public class ThoriumComb : ModBuff
	{
		private string[] BuffList = {
			"AssassinBuff",
			"BloodRush",
			"Frenzy",
			"RadiantBoost",
			"HolyBonus",
			"CreativityDrop",
			"EarwormBuff",
			"InspirationReach",
			"HydrationBuff"
        };
		public override bool IsLoadingEnabled(Mod mod)
		{
			ModLoader.TryGetMod("ThoriumMod", out Mod Thorium);
			return Thorium != null;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Thorium Combination");
			Description.SetDefault("Perfect sum of Thorium buffs"
			+"\nAssassin, Blood, Frenzy, Creativity, Earworm, Inspirational Reach, Glowing, Holy, Hydration");
			Main.debuff[Type] = false;
			BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Комбинация Ториума");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Идеальное сочетание баффов Ториум мода");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "瑟银药剂包");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "完美结合了瑟银药剂的Buff：\n精准药剂、嗜血药剂、战斗药剂、狂怒药剂、光辉药剂、圣洁药剂以及动能药剂");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			ModLoader.TryGetMod("ThoriumMod", out ThoriumMod);
			foreach (string BuffString in BuffList)
            {
                if (ThoriumMod.TryFind<ModBuff>(BuffString, out ModBuff buff))
                    player.buffImmune[buff.Type] = true;
            }

			if (ThoriumMod != null)
			{
				ThoriumBoosts(player, ref buffIndex);
			}
		}

		private void ThoriumBoosts(Player player, ref int buffIndex)
        {
			ModLoader.TryGetMod("ThoriumMod", out ThoriumMod);
			foreach (string BuffString in BuffList)
            {
                if (ThoriumMod.TryFind<ModBuff>(BuffString, out ModBuff buff))
                    buff.Update(player, ref buffIndex);
            }
        }
		private Mod ThoriumMod;
	}
}
