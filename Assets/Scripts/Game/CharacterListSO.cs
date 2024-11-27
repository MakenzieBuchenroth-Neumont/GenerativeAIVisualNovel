using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CharacterListSO", menuName = "Scriptable Objects/CharacterListSO")]
public class CharacterListSO : ScriptableObject {
    public enum Characters {
        Null,
        MaleHumanPaladin,
		MaleHumanRouge,
		MaleHumanWizard,
		MaleHumanSorcerer,
		MaleHumanBard,
		MaleHumanArtificer,
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
		FemaleDragonbornWizard,
        FemaleHumanChild,
    }
	public Texture MaleHumanPaladin,
		MaleHumanRouge,
		MaleHumanWizard,
		MaleHumanSorcerer,
		MaleHumanBard,
		MaleHumanArtificer,
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
		FemaleDragonbornWizard,
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
			case Characters.MaleHumanRouge:
				return MaleHumanRouge;
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
