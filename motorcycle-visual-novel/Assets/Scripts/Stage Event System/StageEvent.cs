using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Utility.EventCommunication;

[CreateAssetMenu(fileName = "New Stage Composition",
	menuName = "Scriptable Objects/Stage Composition")]
/// <summary>
/// Creates a file object that stores selected editable data from a 'stage'.
/// </summary>
public class StageEvent : ScriptableObject
{
	public Sprite background { get { return _background; } }
	[SerializeField] Sprite _background;

	public Sprite leftCharacter { get { return _leftCharacter; } }
	[SerializeField] Sprite _leftCharacter;

	public Sprite rightCharacter { get { return _rightCharacter; } }
	[SerializeField] Sprite _rightCharacter;

	public Sprite dialogueBox { get { return _dialogueBox; } }
	[SerializeField] Sprite _dialogueBox;

	public string dialogue { get { return _dialogue; } }
	[SerializeField][TextArea] string _dialogue;

	public UnityEvent<string> hubEvent;

	public static void TriggerHub(string eventName)
	{
		EventHub.Publish(eventName);
	}
}
