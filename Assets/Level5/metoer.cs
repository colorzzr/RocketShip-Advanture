using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class metoer : MonoBehaviour{

    public GameObject starObj;

    // Start is called before the first frame update
    void Start(){
        InvokeRepeating("createMetoe", 0f, 5f);
    }

    void createMetoe() {
        // random position
        float xOffest = Random.Range(-30f, 10f);
        Vector3 newPos = new Vector3 (xOffest, 30f, 0f);

        // take the object create it
        GameObject clone = (GameObject)Instantiate(starObj, newPos, starObj.transform.rotation);

        // destory it
        Destroy(clone, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
