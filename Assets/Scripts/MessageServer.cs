using UnityEngine;
using System.Collections;

public static class MessageServer
{
	public delegate void MessageDelegate(string message, Color color);
	public static event MessageDelegate OnMessage;
	public static void SendMessage(string message, Color color)
	{
		if (OnMessage != null)
		{
			OnMessage (message, color);
		}
	}
}
