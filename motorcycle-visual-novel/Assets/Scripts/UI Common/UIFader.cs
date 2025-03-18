using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Utility.EasingEquations;

/// <summary>
/// Controls the fade of a UI object (it must have a component that inherits Graphic class)
/// </summary>
public class UIFader : MonoBehaviour
{
	Graphic graphic;
	[SerializeField] float initialAlpha;

	public float alpha
	{
		get { return graphic.color.a; }
		set { Color c = graphic.color; c.a = value; graphic.color = c; }
	}

	private void Awake()
	{
		graphic = GetComponentInChildren<Graphic>();
		alpha = initialAlpha;
	}

	#region Transition

	Coroutine transition;
	[SerializeField] float speed = 1;

	float time { get { return scaledTime ? Time.deltaTime : Time.unscaledTime; } }
	[SerializeField] bool scaledTime = true;

	public bool inTransition { get; private set; }

	// IEnumerator define um tipo de método que permite ser pausado
	//e resumido posteriormente
	IEnumerator Transition(float end)
	{
		inTransition = true;

		float start = alpha;
		float t = 0;
		while (t < 1.01f)
		{
			alpha = EasingFloatEquations.Linear(start, end, t);
			t += speed * time;
			yield return null; //pausa o método por um frame
		}
		alpha = end;

		inTransition = false;
	}

	/// <summary>
	/// Increase alpha
	/// </summary>
	public void In()
	{
		if (transition != null)
		{ StopCoroutine(transition); }
		transition = StartCoroutine(Transition(1));
	}

	/// <summary>
	/// Decrease alpha
	/// </summary>
	public void Out()
	{
		if (transition != null)
		{ StopCoroutine(transition); }
		transition = StartCoroutine(Transition(0));
	}

	/// <summary>
	/// Fade alpha to a given value
	/// </summary>
	/// <param name="value"></param>
	public void ToValue(float value)
	{
		if (transition != null)
		{ StopCoroutine(transition); }
		transition = StartCoroutine(Transition(value));
	}

	#endregion
}
