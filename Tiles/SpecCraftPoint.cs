using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Enums;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ObjectData;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;

namespace AlchemistNPCLite.Tiles
{
	public class SpecCraftPoint : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSolidTop[Type] = false;
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileTable[Type] = true;
			Main.tileLavaDeath[Type] = false;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.Origin = new Point16(1, 2);
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.CoordinateHeights = new int[]{ 16, 16, 18 };
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Special Crafting Point");
			name.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "СпецКрафтовый Поинт");
            name.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "特殊手工位点");
            AddMapEntry(new Color(200, 200, 200), name);
			TileID.Sets.DisableSmartCursor[Type] = true;
			AdjTiles = new int[]
			{
			TileID.Sinks,
			TileID.LivingLoom,
			TileID.Solidifier,
			TileID.FleshCloningVat,
			TileID.GlassKiln,
			TileID.BoneWelder,
			TileID.Kegs,
			TileID.SteampunkBoiler,
			TileID.IceMachine,
			TileID.SkyMill,
			TileID.HoneyDispenser
			};
			DustType = 111;
			AnimationFrameHeight = 56;
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}
		
		public override void AnimateTile(ref int frame, ref int frameCounter)
		{
			frame = Main.tileFrame[TileID.FireflyinaBottle];
			frameCounter = Main.tileFrameCounter[TileID.FireflyinaBottle];
		}
		
		public override void KillMultiTile(int i, int j, int TileFrameX, int TileFrameY)
		{
			Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 16, ModContent.ItemType<Items.Placeable.SpecCraftPoint>());
		}
	}
}