using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface EventsListener {

	void receivedEvent(string eventId, params object[] args);
}
