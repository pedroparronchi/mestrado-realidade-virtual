using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
