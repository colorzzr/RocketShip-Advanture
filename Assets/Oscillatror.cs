using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// in case we put two same component
[DisallowMultipleComponent]
public class Oscillatror : MonoBehaviour{

    [SerializeField] Vector3 movementVec = new Vector3(10f, 10f, 10f);
    [SerializeField] float period = 2f;
    [SerializeField] [Range(0, 1)]float moveFactor;

    Vector3 startVector;

    // Start is called before the first frame update
    void Start(){
        startVector = transform.position;
    }

    // Update is called once per frame
    void Update(){
        if (period == 0) period = 1;
        float cycle = Time.time / period;
        float sinWave = Mathf.Sin(cycle * Mathf.PI * 2);
        // offset  factor in 0 to 1
        moveFactor = sinWave / 2f + 0.5f;

        Vector3 move = movementVec * moveFactor;
        transform.position = startVector + move;
    }
}
