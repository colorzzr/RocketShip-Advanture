using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour{
    enum State {
        Die,
        Alive,
        Transaction,
    };
    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float levelLoadDelay = 2f;

    // sound output dereference
    [SerializeField] AudioClip thrustSound;
    [SerializeField] AudioClip successSound;
    [SerializeField] AudioClip deadSound;

    [SerializeField] ParticleSystem thrustParti;
    [SerializeField] ParticleSystem successParti;
    [SerializeField] ParticleSystem deadParti;

    Rigidbody rb;
    AudioSource audioSource;
    State state = State.Alive;
    int level = 0;


    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void processInput() {
        // apply thrust
        if (Input.GetKey(KeyCode.Space)) {
            print("Space Press!");
            // according to the its own space
            rb.AddRelativeForce(Vector3.up * mainThrust);
            // play the sound and particle eff
            if (!audioSource.isPlaying) audioSource.PlayOneShot(thrustSound);
            thrustParti.Play();
        }
        else {
            audioSource.Stop();
            thrustParti.Stop();
        }

        // rotate the rocket
        rb.freezeRotation = true;
        // we want rocket to rotate at current frame
        float rotateThisFrame = rcsThrust * Time.deltaTime;
        //make sure we can rotate in thrust
        if (Input.GetKey(KeyCode.A)) {
            print("Left Press!");
            transform.Rotate(Vector3.forward * rotateThisFrame);
        }
        else if (Input.GetKey(KeyCode.D)) {
            print("Right Press!");
            transform.Rotate(-Vector3.forward * rotateThisFrame);
        }

        rb.freezeRotation = false;
    }

    // report while hit something
    private void OnCollisionEnter(Collision collision) {
        print("Collide?");

        // we short the collision check for only one die
        if (state != State.Alive) return;


        switch (collision.gameObject.tag) {
            case "Platform":
                state = State.Alive;
                print("platform");
                //if (!audioSource.isPlaying) audioSource.PlayOneShot(tt);
                break;
            case "Landing":
                print("Landing");
                //level = 1;
                state = State.Transaction;

                // play the sound and particle eff
                successParti.Play();
                audioSource.Stop();
                audioSource.PlayOneShot(successSound);

                // switch to next
                //Invoke("nextLevel", levelLoadDelay);
                Invoke("reloadScene", levelLoadDelay);
                break;
            default:
                print("DIe!");
                // reset level
                //level = 0;
                state = State.Die;

                // play the sound and particle eff
                deadParti.Play();
                audioSource.Stop();
                audioSource.PlayOneShot(deadSound);

                // switch to next
                //Invoke("nextLevel", levelLoadDelay);
                Invoke("reloadScene", levelLoadDelay);
                break;
        }
    }

    // test function for reload scene
    void reloadScene() {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    void nextLevel() {
        SceneManager.LoadScene(level);
    }

    // Update is called once per frame
    void Update(){
        if(state == State.Alive) processInput();
        //if(audioSource.isPlaying) 
    }
}
