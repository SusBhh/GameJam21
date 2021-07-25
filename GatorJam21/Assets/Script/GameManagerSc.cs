using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private int grade;
    private int attempt;
    private int target;
    //public int level;
    public Text gradeText;
    public Text attemptText;
    public Text targetText;
    public Image exploreImage;
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
        grade = 0;
        attempt = 15;
        target = 100;
        //level = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (grade >= target) {
            //win and go to story
            //PlayerPrefs.SetInt("lev", 2);
            //level++;
            exploreImage.gameObject.SetActive(true);
        }
        if (attempt <= 0) { 
            //lose and reset current level
        }
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

        gradeText.text = grade.ToString();
        attemptText.text = attempt.ToString();
        targetText.text = target.ToString();
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
            attempt--;
            if (sparkle.childCount != 0)
            {
                grade += GetGrade(sparkle.GetChild(0).tag);
                Destroy(sparkle.GetChild(0).gameObject);
            }
            sparkle.GetComponent<Collider2D>().enabled = true;
            return;
        }
        lightLength -= Time.deltaTime * 60;
        light.localScale = new Vector3(light.localScale.x, lightLength, light.localScale.z);
        sparkle.localScale = new Vector3(light.localScale.x, 1 / lightLength, light.localScale.z);
    }

    private int GetGrade(string tag) {
        int num = 0;
        switch (tag) {
            case "red":
                num = 40;
                break;
            case "pink":
                num = 35;
                break;
            case "purple":
                num = 30;
                break;
            case "yellow":
                num = 30;
                break;
            case "blue":
                num = 25;
                break;
            case "green":
                num = 15;
                break;
        }
        return num;
    }


}
