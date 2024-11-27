using System.Collections.Generic;
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
		CastleTower,
		ForestClearing,
		ScaryForest,
		WheatFields,
		ForestFire,
		MistyForest,
		MountainRange,
		ForestPath,
		ForestRuins,
		SnowyForest,
		WizardTowerOutside,
		DenseForest,
		Village,
		VillageInnInside,
		VillageTavernInside,
		VillageShopInside,
		Lake,
		River,
		Waterfall

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
		CastleTower,
		ForestClearing,
		ScaryForest,
		WheatFields,
		ForestFire,
		MistyForest,
		MountainRange,
		ForestPath,
		ForestRuins,
		SnowyForest,
		WizardTowerOutside,
		DenseForest,
		Village,
		VillageInnInside,
		VillageTavernInside,
		VillageShopInside,
		Lake,
		River,
		Waterfall;

	public static List<Backgrounds> charactersnames = new List<Backgrounds>();

	private void Awake() {
		for (int i = 1; (Backgrounds)i != Backgrounds.Waterfall; i++) {
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
			case Backgrounds.CastleTower:
				return CastleTower;
			case Backgrounds.ForestClearing:
				return ForestClearing;
			case Backgrounds.ScaryForest:
				return ScaryForest;
			case Backgrounds.WheatFields:
				return WheatFields;
			case Backgrounds.ForestFire:
				return ForestFire;
			case Backgrounds.MistyForest:
				return MistyForest;
			case Backgrounds.MountainRange:
				return MountainRange;
			case Backgrounds.ForestPath:
				return ForestPath;
			case Backgrounds.ForestRuins:
				return ForestRuins;
			case Backgrounds.SnowyForest:
				return SnowyForest;
			case Backgrounds.WizardTowerOutside:
				return WizardTowerOutside;
			case Backgrounds.DenseForest:
				return DenseForest;
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
			case Backgrounds.River:
				return River;
			case Backgrounds.Waterfall:
				return Waterfall;
			case Backgrounds.Beach:
				return Beach;
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
