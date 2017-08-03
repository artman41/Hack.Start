using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWindow : MonoBehaviour {

    public GameObject Target;

	public void Close() {
        Destroy(Target);
    }
}
