using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Stage Composition",
	menuName = "Scriptable Objects/Stage Composition")]
/// <summary>
/// Creates a file object that stores selected editable data from a 'stage'.
/// </summary>
public class StageComposition : ScriptableObject
{
	public Image background { get { return _background; } }
	[SerializeField] Image _background;

	public Image leftCharacter { get { return leftCharacter; } }
	[SerializeField] Image _leftCharacter;

	public Image rightCharacter { get { return _rightCharacter; } }
	[SerializeField] Image _rightCharacter;

	public Image dialogueBox { get { return _dialogueBox; } }
	[SerializeField] Image _dialogueBox;

	public string dialogue { get { return _dialogue; } }
		[SerializeField] string _dialogue;
}
