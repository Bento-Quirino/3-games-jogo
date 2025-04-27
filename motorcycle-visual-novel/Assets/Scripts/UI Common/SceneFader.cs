using System;
using System.Collections.Generic;
using Utility.EventCommunication;

public class SceneFader : UIFader
{
	public const string TriggerIn = "TriggerFadeIn";
	public const string TriggerOut = "TriggerFadeOut";

	public void Start()
	{
		EventHub.Subscribe(TriggerIn, FadeIn);
		EventHub.Subscribe(TriggerOut, FadeOut);
	}

	void FadeIn(EventData data)
	{
		In();
	}

	void FadeOut(EventData data)
	{
		Out();
	}

	private void OnDisable()
	{
		EventHub.UnSubscribe(TriggerIn, FadeIn);
		EventHub.UnSubscribe(TriggerOut, FadeOut);
	}
}
