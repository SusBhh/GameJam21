using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State { 
    Rock,
    Stretch,
    Shorten
}

public class GameManagerSc : MonoBehaviour
{
    private State state;
    private Vector3 dir;
    private Transform wand;
    private Transform light;
    private Transform sparkle;
    private float lightLength;

    public State GetState { 
        set { state = value; }
        get { return state; }
    }
    // Start is called before the first frame update
    void Start()
    {
        state = State.Rock;
        dir = Vector3.back;
        wand = transform.GetChild(0);
        light = wand.GetChild(0);
        sparkle = light.GetChild(0).GetChild(0);
        lightLength = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.Rock)
        {
            Rock();
            if (Input.GetKeyDown("space")) {
                state = State.Stretch;
            }
        }
        else if (state == State.Stretch)
        {
            Stretch();
        }
        else if (state == State.Shorten) {
            Shorten();
        }
    }

    private void Rock() {
        if (wand.localRotation.z <= -0.9) {
            dir = Vector3.forward;
        }
        else if (wand.localRotation.z >= -0.4) {
            dir = Vector3.back;
        }
        wand.Rotate(dir * 40 * Time.deltaTime);
    }

    private void Stretch() {
        if (lightLength >= 97) {
            state = State.Shorten;
            return;
        }
        lightLength += Time.deltaTime * 60;
        light.localScale = new Vector3(light.localScale.x, lightLength, light.localScale.z);
        sparkle.localScale = new Vector3(light.localScale.x, 1/lightLength, light.localScale.z);
    }
    
    private void Shorten() {
        if (lightLength < 1) {
            state = State.Rock;
            return;
        }
        lightLength -= Time.deltaTime * 60;
        light.localScale = new Vector3(light.localScale.x, lightLength, light.localScale.z);
        sparkle.localScale = new Vector3(light.localScale.x, 1 / lightLength, light.localScale.z);
    }
}
