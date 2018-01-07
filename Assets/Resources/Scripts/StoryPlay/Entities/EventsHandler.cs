using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Events handler. 
/// </summary>
public class EventsHandler {

	private static EventsHandler _instance;
	private IList<EventsListener> listeners;

	private EventsHandler(){

	}

	public static EventsHandler get(){
		if (_instance != null)
			_instance = new EventsHandler ();
		return _instance;
	}
}
