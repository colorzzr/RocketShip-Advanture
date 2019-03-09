using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour{

    Rigidbody rb;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void processInput() {
        if (Input.GetKey(KeyCode.Space)) {
            print("Space Press!");
            // according to the its own space
            rb.AddRelativeForce(Vector3.up);
            // play the sound
            if(!audioSource.isPlaying) audioSource.Play();
        }
        else {
            audioSource.Stop();
        }

        rb.freezeRotation = true;
        //make sure we can rotate in thrust
        if (Input.GetKey(KeyCode.A)) {
            print("Left Press!");

            transform.Rotate(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.D)) {
            print("Right Press!");

            transform.Rotate(-Vector3.forward);
        }

        rb.freezeRotation = false;
    }

    // report while hit something
    private void OnCollisionEnter(Collision collision) {
        print("Collide?");
        switch (collision.gameObject.tag) {
            case "Platform":
                print("platform");
                break;
            case "Landing":
                print("Landing");
                // switch to next
                SceneManager.LoadScene(1);
                break;
            default:
                print("DIe!");
                // switch to next
                SceneManager.LoadScene(0);
                break;
        }
    }

    // Update is called once per frame
    void Update(){
        processInput();
        //if(audioSource.isPlaying) 
    }
}
