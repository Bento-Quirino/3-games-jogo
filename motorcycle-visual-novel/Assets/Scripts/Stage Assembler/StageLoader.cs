using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageLoader : MonoBehaviour
{
	//Elementos fixos na cena do Stage Skeleton
	[SerializeField] Image _background;
	[SerializeField] Image _leftCharacter;
	[SerializeField] Image _rightCharacter;
	[SerializeField] Image _dialogueBox;

	void Start()
	{
		_background.color = Color.white;
		_leftCharacter.color = Color.white;
		_rightCharacter.color = Color.white;
		_dialogueBox.color = Color.white;
	}

	public void Load(StageComposition stage)
	{
		Set(_background, stage.background);
		Set(_leftCharacter, stage.leftCharacter);
		Set(_rightCharacter, stage.rightCharacter);
		Set(_dialogueBox, stage.dialogueBox);
	}

	void Set(Image selected, Sprite incoming)
	{
		if(incoming == null)
		{
			selected.color = Color.clear;
			return;
		}

		selected.sprite = incoming;
	}
}
