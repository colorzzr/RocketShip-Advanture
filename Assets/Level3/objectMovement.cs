using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectMovement : MonoBehaviour{

    [SerializeField] Vector3 movementVec = new Vector3(10f, 10f, 10f);
    [SerializeField] Quaternion rotateVec; 
    [SerializeField] float period = 2f;

    Vector3 startPos;
    Quaternion startOrient;
    // Start is called before the first frame update
    void Start(){
        startPos = transform.position;
        startOrient = transform.rotation;

        //transform.Rotate(Vector3.up, 50);
    }

    // Update is called once per frame
    void Update(){
        if (period == 0) period = 1;
        float cycle = Time.time / period;
        float sinWave = Mathf.Sin(cycle * Mathf.PI * 2);
        // offset  factor in 0 to 1
        float moveFactor = sinWave / 2f + 0.5f;
        
        // set the rotation and position
        transform.Rotate(Vector3.forward, startOrient.z + period/50 * rotateVec.z);
        Vector3 move = movementVec * moveFactor;
        transform.position = startPos + move;
    }
}
