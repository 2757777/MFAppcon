using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScanCount : MonoBehaviour {


	void Start () {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(scanCount);

	}
	
    void scanCount()
    {
        //スキャン回数回復

	}
}
