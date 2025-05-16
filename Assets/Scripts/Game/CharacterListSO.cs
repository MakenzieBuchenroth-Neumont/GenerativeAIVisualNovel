using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CharacterListSO", menuName = "Scriptable Objects/CharacterListSO")]
public class CharacterListSO : ScriptableObject {
    public enum Characters {
        Null,
        MaleHumanPaladin,
        FemaleHumanPaladin,
		MaleHumanRogue,
		FemaleHumanRogue,
		MaleHumanWizard,
		MaleHumanSorcerer,
		FemaleHumanSorcerer,
		MaleHumanBard,
		FemaleHumanBard,
		MaleHumanArtificer,
		FemaleHumanArtificer,
		MaleHumanKnight,
		FemaleHumanKnight,
		MaleHumanRanger,
		FemaleHumanRanger,
		MaleHumanKing,
		FemaleHumanQueen,
		MaleHumanCivilian,
		FemaleHumanCivilian,
        MaleHumanChild,
		MaleDragonbornArtificer,
		FemaleDragonbornArtificer,
		MaleDragonbornBard,
		FemaleDragonbornBard,
		MaleDragonbornKnight,
		FemaleDragonbornKnight,
		MaleDragonbornPaladin,
		FemaleDragonbornPaladin,
		MaleDragonbornRanger,
		FemaleDragonbornRanger,
		MaleDragonbornRogue,
		FemaleDragonbornRogue,
		MaleDragonbornRoyalty,
		FemaleDragonbornRoyalty,
		MaleDragonbornWarlock,
		FemaleDragonbornWarlock,
		MaleDragonbornWizard,
		FemaleDragonbornWizard, MaleElfPaladin,
		FemaleElfPaladin,
		MaleElfRogue,
		FemaleElfRogue,
		MaleElfWizard,
		FemaleElfWizard,
		MaleElfSorcerer,
		FemaleElfSorcerer,
		MaleElfBard,
		FemaleElfBard,
		MaleElfArtificer,
		FemaleElfArtificer,
		MaleElfKnight,
		FemaleElfKnight,
		MaleElfRanger,
		FemaleElfRanger,
		MaleElfKing,
		FemaleElfQueen,
		MaleElfCivilian,
		FemaleElfCivilian,
		Bear,
		DireWolf,
		BlueDragon,
		GoldDragon,
		GreenDragon,
		RedDragon,
		BronzeDragon,
		GiantEagle,
		GiantSpider,
		MaleGoblin,
		Illithid,
		ChestMimic,
		OwlBear,
		Skeleton,
		SlimeCube,
		WingedLion,
		FemaleHumanChild,
    }
	public Texture MaleHumanPaladin,
		FemaleHumanPaladin,
		MaleHumanRogue,
		FemaleHumanRogue,
		MaleHumanWizard,
		MaleHumanSorcerer,
		FemaleHumanSorcerer,
		MaleHumanBard,
		FemaleHumanBard,
		MaleHumanArtificer,
		FemaleHumanArtificer,
		MaleHumanKnight,
		FemaleHumanKnight,
		MaleHumanRanger,
		FemaleHumanRanger,
		MaleHumanKing,
		FemaleHumanQueen,
		MaleHumanCivilian,
		FemaleHumanCivilian,
		MaleHumanChild,
		FemaleHumanChild, 
		MaleDragonbornArtificer,
		FemaleDragonbornArtificer,
		MaleDragonbornBard,
		FemaleDragonbornBard,
		MaleDragonbornKnight,
		FemaleDragonbornKnight,
		MaleDragonbornPaladin,
		FemaleDragonbornPaladin,
		MaleDragonbornRanger,
		FemaleDragonbornRanger,
		MaleDragonbornRogue,
		FemaleDragonbornRogue,
		MaleDragonbornRoyalty,
		FemaleDragonbornRoyalty,
		MaleDragonbornWarlock,
		FemaleDragonbornWarlock,
		MaleDragonbornWizard,
		FemaleDragonbornWizard, MaleElfPaladin,
FemaleElfPaladin,
MaleElfRogue,
FemaleElfRogue,
MaleElfWizard,
		FemaleElfWizard,
MaleElfSorcerer,
FemaleElfSorcerer,
MaleElfBard,
FemaleElfBard,
MaleElfArtificer,
FemaleElfArtificer,
MaleElfKnight,
FemaleElfKnight,
MaleElfRanger,
FemaleElfRanger,
MaleElfKing,
FemaleElfQueen,
MaleElfCivilian,
FemaleElfCivilian,
		Bear,
		DireWolf,
		BlueDragon,
		GoldDragon,
		GreenDragon,
		RedDragon,
		BronzeDragon,
		GiantEagle,
		GiantSpider,
		MaleGoblin,
		Illithid,
		ChestMimic,
		OwlBear,
		Skeleton,
		SlimeCube,
		WingedLion,

		Null;
	public static List<Characters> charactersnames = new List<Characters>();

	private void Awake() {
		for (int i = 1; (Characters)i != Characters.FemaleHumanChild; i++) {
			charactersnames.Add((Characters)i);
		}
	}

	public Texture getCharacter(Characters character) {
		switch (character) {
			default:
			case Characters.Null:
				return Null;
			case Characters.MaleHumanPaladin:
				return MaleHumanPaladin;
			case Characters.MaleHumanRogue:
				return MaleHumanRogue;
			case Characters.MaleHumanWizard:
				return MaleHumanWizard;
			case Characters.MaleHumanSorcerer:
				return MaleHumanSorcerer;
			case Characters.MaleHumanBard:
				return MaleHumanBard;
			case Characters.MaleHumanArtificer:
				return MaleHumanArtificer;
			case Characters.MaleHumanCivilian:
				return MaleHumanCivilian;
			case Characters.FemaleHumanCivilian:
				return FemaleHumanCivilian;
			case Characters.MaleHumanChild:
				return MaleHumanChild;
			case Characters.FemaleHumanChild:
				return FemaleHumanChild;
			case Characters.MaleDragonbornArtificer:
				return MaleDragonbornArtificer;
			case Characters.FemaleDragonbornArtificer:
				return FemaleDragonbornArtificer;
			case Characters.MaleDragonbornBard:
				return MaleDragonbornBard;
			case Characters.FemaleDragonbornBard:
				return FemaleDragonbornBard;
			case Characters.MaleDragonbornKnight:
				return MaleDragonbornKnight;
			case Characters.FemaleDragonbornKnight:
				return FemaleDragonbornKnight;
			case Characters.MaleDragonbornPaladin:
				return MaleDragonbornPaladin;
			case Characters.FemaleDragonbornPaladin:
				return FemaleDragonbornPaladin;
			case Characters.MaleDragonbornRanger:
				return MaleDragonbornRanger;
			case Characters.FemaleDragonbornRanger:
				return FemaleDragonbornRanger;
			case Characters.MaleDragonbornRogue:
				return MaleDragonbornRogue;
			case Characters.FemaleDragonbornRogue:
				return FemaleDragonbornRogue;
			case Characters.MaleDragonbornRoyalty:
				return MaleDragonbornRoyalty;
			case Characters.FemaleDragonbornRoyalty:
				return FemaleDragonbornRoyalty;
			case Characters.MaleDragonbornWarlock:
				return MaleDragonbornWarlock;
			case Characters.FemaleDragonbornWarlock:
				return FemaleDragonbornWarlock;
			case Characters.MaleDragonbornWizard:
				return MaleDragonbornWizard;
			case Characters.FemaleDragonbornWizard:
				return FemaleDragonbornWizard;
			case Characters.FemaleHumanPaladin:
				return FemaleHumanPaladin;
			case Characters.FemaleHumanRogue:
				return FemaleHumanRogue;
			case Characters.FemaleHumanSorcerer:
				return FemaleHumanSorcerer;
			case Characters.FemaleHumanBard:
				return FemaleHumanBard;
			case Characters.FemaleHumanArtificer:
				return FemaleHumanArtificer;
			case Characters.MaleHumanKnight:
				return MaleHumanKnight;
			case Characters.FemaleHumanKnight:
				return FemaleHumanKnight;
			case Characters.MaleHumanRanger:
				return MaleHumanRanger;
			case Characters.FemaleHumanRanger:
				return FemaleHumanRanger;
			case Characters.MaleHumanKing:
				return MaleHumanKing;
			case Characters.FemaleHumanQueen:
				return FemaleHumanQueen;
			case Characters.MaleElfPaladin:
				return MaleElfPaladin;
			case Characters.FemaleElfPaladin:
				return FemaleElfPaladin;
			case Characters.MaleElfRogue:
				return MaleElfRogue;
			case Characters.FemaleElfRogue:
				return FemaleElfRogue;
			case Characters.MaleElfWizard:
				return MaleElfWizard;
			case Characters.FemaleElfWizard:
				return FemaleElfWizard;
			case Characters.MaleElfSorcerer:
				return MaleElfSorcerer;
			case Characters.FemaleElfSorcerer:
				return FemaleElfSorcerer;
			case Characters.MaleElfBard:
				return MaleElfBard;
			case Characters.FemaleElfBard:
				return FemaleElfBard;
			case Characters.MaleElfArtificer:
				return MaleElfArtificer;
			case Characters.FemaleElfArtificer:
				return FemaleElfArtificer;
			case Characters.MaleElfKnight:
				return MaleElfKnight;
			case Characters.FemaleElfKnight:
				return FemaleElfKnight;
			case Characters.MaleElfRanger:
				return MaleElfRanger;
			case Characters.FemaleElfRanger:
				return FemaleElfRanger;
			case Characters.MaleElfKing:
				return MaleElfKing;
			case Characters.FemaleElfQueen:
				return FemaleElfQueen;
			case Characters.MaleElfCivilian:
				return MaleElfCivilian;
			case Characters.FemaleElfCivilian:
				return FemaleElfCivilian;
			case Characters.Bear:
				return Bear;
			case Characters.DireWolf:
				return DireWolf;
			case Characters.BlueDragon:
				return BlueDragon;
			case Characters.GoldDragon:
				return GoldDragon;
			case Characters.GreenDragon:
				return GreenDragon;
			case Characters.RedDragon:
				return RedDragon;
			case Characters.BronzeDragon:
				return BronzeDragon;
			case Characters.GiantEagle:
				return GiantEagle;
			case Characters.GiantSpider:
				return GiantSpider;
			case Characters.MaleGoblin:
				return MaleGoblin;
			case Characters.Illithid:
				return Illithid;
			case Characters.ChestMimic:
				return ChestMimic;
			case Characters.OwlBear:
				return OwlBear;
			case Characters.Skeleton:
				return Skeleton;
			case Characters.SlimeCube:
				return SlimeCube;
			case Characters.WingedLion:
				return WingedLion;

		}
	}

	public static Characters valueOf(string value) {
		if (value == null || value.Length == 0 || value.ToLower().Equals(Characters.Null.ToString().ToLower())) {
			return Characters.Null;
		}
		foreach (var c in GameManager.charactersnames) {
			if (value.ToLower().Equals(c.ToString().ToLower())) {
				return c;
			}
		}
		return Characters.Null;
	}
}
