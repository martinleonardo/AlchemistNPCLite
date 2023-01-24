using Terraria;
using System.Linq;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.ID;

using Terraria.Chat;
using Microsoft.Xna.Framework;

namespace AlchemistNPCLite.Buffs
{
    public class NinjaSkill : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ninja");
            Description.SetDefault("You are a true ninja!");
            Main.debuff[Type] = false;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ниндзя");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Вы - истинный ниндзя!");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "忍者");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "现在你是个真正的忍者了!");
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetDamage(DamageClass.Generic) += 0.05f;
            player.GetCritChance(DamageClass.Melee) += 5;
            player.GetCritChance(DamageClass.Ranged) += 5;
            player.GetCritChance(DamageClass.Magic) += 5;
            player.GetCritChance(DamageClass.Throwing) += 5;
            player.blackBelt = true;
            player.spikedBoots = 2;
            ModLoader.TryGetMod("ThoriumMod", out ThoriumMod);
            if (ThoriumMod != null)
            {
                ThoriumBoosts(player);
            }
            // IMPLEMENT WHEN WEAKREFERENCES FIXED
            /*
            if (ModLoader.GetMod("Redemption") != null)
            {
                RedemptionBoost(player);
            }
			*/
            ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
            if (Calamity != null)
            {
                Calamity.Call("AddRogueCrit", player, 5);
            }
        }

        private void CalamityBoost(Player player)
        {
			// CalamityMod.CalPlayer.CalamityPlayer CalamityPlayer = player.GetModPlayer<CalamityMod.CalPlayer.CalamityPlayer>();
            player.GetDamage(DamageClass.Throwing) += 5;
        }
        // private readonly ModLoader.TryGetMod("CalamityMod", out Mod Calamity);

        // IMPLEMENT WHEN WEAKREFERENCES FIXED
        /*
        private void RedemptionBoost(Player player)
        {
            Redemption.Items.DruidDamageClass.DruidDamagePlayer RedemptionPlayer = player.GetModPlayer<Redemption.Items.DruidDamageClass.DruidDamagePlayer>();
            Redemptionplayer.GetDamage(DamageClass.druid) += 5;
        }
        private readonly Mod Redemption = ModLoader.GetMod("Redemption");

		*/
        private void ThoriumBoosts(Player player)
        {
            ModLoader.TryGetMod("ThoriumMod", out ThoriumMod);
            ThoriumMod.Call("BonusBardDamageFlat", player, 5);
            ThoriumMod.Call("BonusHealerDamageFlat", player, 5);
        }
        private Mod ThoriumMod;
    }
}
