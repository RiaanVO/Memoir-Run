using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MemoryManager : MonoBehaviour {

	public static int memories;
	Text memoryCounter;

	void Start(){
		//memoryCounter = GetComponent<Text> ();
		memories = 0;
	}

	void Update(){
		if (memories < 0) {
			memories = 0;
		}

		//memoryCounter.text = "" + memories;
	}

	public static void AddMemories(int memoriesToAdd){
		memories += memoriesToAdd;
	}

	public static void Reset(){
		memories = 0;
	}
}
