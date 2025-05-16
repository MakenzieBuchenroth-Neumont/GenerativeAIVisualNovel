
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "BackgroundListSO", menuName = "Scriptable Objects/BackgroundListSO")]
public class BackgroundListSO : ScriptableObject {
    public enum Backgrounds {
        Beach,
		BirchForest,
		OutsideCastle,
		CastleBallroom,
		CastleGarden,
		CastleHallway,
		CastleKitchen,
		CastlePathway,
		CastleRoad,
		CastlePrison,
		CastleRuins,
		CastleStairCase,
		CastleThroneRoom,
		ForestClearing,
		ScaryForest,
		WheatFields,
		MountainRange,
		ForestPath,
		ForestRuins,
		SnowyForest,
		Village,
		VillageInnInside,
		VillageTavernInside,
		VillageShopInside,
		Lake,
		AncientLibrary,
		UndergroundCavern,
		MysticAltar,
		DesertOasis,
		HauntedGraveyard,
		FloatingIsland,
		MarketplaceSquare,
		PirateCove,
		AbandonedMine,
		VolcanoSummit,
		HiddenCaveWaterfall,
		SunkenShipwreck,
		EnchantedGlade,
		BattlefieldRuins,
		IceCavern,
		UndergroundDungeon,
		TempleRuins,
		FairyGrove,
		DragonsLair,
		ObservatoryTower

    }
	public Texture Beach,
		BirchForest,
		OutsideCastle,
		CastleBallroom,
		CastleGarden,
		CastleHallway,
		CastleKitchen,
		CastlePathway,
		CastleRoad,
		CastlePrison,
		CastleRuins,
		CastleStairCase,
		CastleThroneRoom,
		ForestClearing,
		ScaryForest,
		WheatFields,
		MountainRange,
		ForestPath,
		ForestRuins,
		SnowyForest,
		Village,
		VillageInnInside,
		VillageTavernInside,
		VillageShopInside,
		Lake,
		AncientLibrary,
		UndergroundCavern,
		MysticAltar,
		DesertOasis,
		HauntedGraveyard,
		FloatingIsland,
		MarketplaceSquare,
		PirateCove,
		AbandonedMine,
		VolcanoSummit,
		HiddenCaveWaterfall,
		SunkenShipwreck,
		EnchantedGlade,
		BattlefieldRuins,
		IceCavern,
		UndergroundDungeon,
		TempleRuins,
		FairyGrove,
		DragonsLair,
		ObservatoryTower;

	public static List<Backgrounds> charactersnames = new List<Backgrounds>();

	private void Awake() {
		for (int i = 1; (Backgrounds)i != Backgrounds.ObservatoryTower; i++) {
			charactersnames.Add((Backgrounds)i);
		}
	}

	public Texture getCharacter(Backgrounds character) {
		switch (character) {
			default:
			case Backgrounds.BirchForest:
				return BirchForest;
			case Backgrounds.OutsideCastle:
				return OutsideCastle;
			case Backgrounds.CastleBallroom:
				return CastleBallroom;
			case Backgrounds.CastleGarden:
				return CastleGarden;
			case Backgrounds.CastleHallway:
				return CastleHallway;
			case Backgrounds.CastleKitchen:
				return CastleKitchen;
			case Backgrounds.CastlePathway:
				return CastlePathway;
			case Backgrounds.CastleRoad:
				return CastleRoad;
			case Backgrounds.CastlePrison:
				return CastlePrison;
			case Backgrounds.CastleRuins:
				return CastleRuins;
			case Backgrounds.CastleStairCase:
				return CastleStairCase;
			case Backgrounds.CastleThroneRoom:
				return CastleThroneRoom;
			case Backgrounds.ForestClearing:
				return ForestClearing;
			case Backgrounds.ScaryForest:
				return ScaryForest;
			case Backgrounds.WheatFields:
				return WheatFields;
			case Backgrounds.MountainRange:
				return MountainRange;
			case Backgrounds.ForestPath:
				return ForestPath;
			case Backgrounds.ForestRuins:
				return ForestRuins;
			case Backgrounds.SnowyForest:
				return SnowyForest;
			case Backgrounds.Village:
				return Village;
			case Backgrounds.VillageInnInside:
				return VillageInnInside;
			case Backgrounds.VillageTavernInside:
				return VillageTavernInside;
			case Backgrounds.VillageShopInside:
				return VillageShopInside;
			case Backgrounds.Lake:
				return Lake;
			case Backgrounds.Beach:
				return Beach;
			case Backgrounds.AncientLibrary:
				return AncientLibrary;
			case Backgrounds.UndergroundCavern:
				return UndergroundCavern;
			case Backgrounds.MysticAltar:
				return MysticAltar;
			case Backgrounds.DesertOasis:
				return DesertOasis;
			case Backgrounds.HauntedGraveyard:
				return HauntedGraveyard;
			case Backgrounds.FloatingIsland:
				return FloatingIsland;
			case Backgrounds.MarketplaceSquare:
				return MarketplaceSquare;
			case Backgrounds.PirateCove:
				return PirateCove;
			case Backgrounds.AbandonedMine:
				return AbandonedMine;
			case Backgrounds.VolcanoSummit:
				return VolcanoSummit;
			case Backgrounds.HiddenCaveWaterfall:
				return HiddenCaveWaterfall;
			case Backgrounds.SunkenShipwreck:
				return SunkenShipwreck;
			case Backgrounds.EnchantedGlade:
				return EnchantedGlade;
			case Backgrounds.BattlefieldRuins:
				return BattlefieldRuins;
			case Backgrounds.IceCavern:
				return IceCavern;
			case Backgrounds.UndergroundDungeon:
				return UndergroundDungeon;
			case Backgrounds.TempleRuins:
				return TempleRuins;
			case Backgrounds.FairyGrove:
				return FairyGrove;
			case Backgrounds.DragonsLair:
				return DragonsLair;
			case Backgrounds.ObservatoryTower:
				return ObservatoryTower;

		}
	}

	public static Backgrounds valueOf(string value) {
		if (value == null || value.Length == 0 || value.ToLower().Equals(Backgrounds.BirchForest.ToString().ToLower())) {
			return Backgrounds.BirchForest;
		}
		foreach (var c in GameManager.Backgrounds) {
			if (value.ToLower().Equals(c.ToString().ToLower())) {
				return c;
			}
		}
		return Backgrounds.BirchForest;
	}
}
