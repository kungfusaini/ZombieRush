using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCollider : Object
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    protected override void Update() {
        if (GameManager.instance.PlayerActive) {
            base.Update();
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "player") {
            GameManager.instance.IncreaseScore();
        }
    }
}
