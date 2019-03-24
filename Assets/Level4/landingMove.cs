using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class landingMove : MonoBehaviour
{

    Vector3 movementVec = new Vector3(10f, 10f, 10f);
    //float period = 2f;
    //float moveFactor;

    Vector3 startVector;
    int count = 0;

    // Start is called before the first frame update
    void Start() {
        startVector = transform.position;
    }


    // Update is called once per frame
    void Update(){
        if(count == 50) {
            transform.position = startVector + new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(0f, 5.0f));
            count = 0;
        }
        else {
            count++;
        }
        
    }
}
