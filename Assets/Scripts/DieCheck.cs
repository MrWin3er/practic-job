using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieCheck : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.name == "dieCheck")
						Application.LoadLevel (Application.loadedLevel);
	}
}
