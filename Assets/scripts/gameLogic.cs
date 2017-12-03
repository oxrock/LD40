using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class gameLogic : MonoBehaviour {

    public GameObject boxFab;
    int[] range = new int[2];
    float count = 0f;
    float limit = 5.5f;
    Vector2 nextSpot = new Vector2();
    public indicatorLight IL;
    public HingeJoint2D hinge;
    float hingeAngle = 0;
    JointMotor2D motor;
    public Text scoreText;
    float timeElapsed = 0f;
    string output;
    public AudioSource bgm;
    public GameObject GOScreen;
    public Text GOText;
    TimeSpan timeKeeper;
    public AudioSource bing;
    public AudioSource GO;
    public GameObject startMenu;

    public void startGame() {
        startMenu.SetActive(false);
        Time.timeScale = 1;
    }

    void timerHandler() {
        timeElapsed += Time.deltaTime;
        timeKeeper = TimeSpan.FromSeconds(timeElapsed);
        output = timeKeeper.ToString().Substring(3, 5);
        scoreText.text = output;
    }

    string textMaker() {
        int seconds = (int)(Mathf.Floor(timeElapsed));

        string result = "You lasted " + seconds.ToString() + 
            " seconds earning you a total of " + (seconds * 10).ToString() +
            " points. Press the restart button to try again.";
        return result;

    }

    public void endGame() {
        Time.timeScale = 0;
        //bgm.Stop();
        GO.Play();
        GOScreen.SetActive(true);
        GOText.text = textMaker();
    }

    public void restart() {
        SceneManager.LoadScene(0);
    }

    void countHandler() {
        count -= Time.deltaTime;
        if (count < 0) {
            bing.Play();
            spawnFab();
            count = limit;
        }
    }
    void updateIndicator() {
        IL.reset(new Vector2(nextSpot.x,93f),limit);
    }

    void pickNewPosition() {
        nextSpot = new Vector2((UnityEngine.Random.Range(range[0], range[1])), 104f);
    }

    void spawnFab() {
        GameObject pancake = Instantiate<GameObject>(boxFab);
        pancake.transform.position = nextSpot;
        pancake.GetComponent<pancakeLogic>().GL = this;
        pickNewPosition();
        updateIndicator();
    }

	void Start () {
        count = limit;
        range[0] = -100;
        range[1] = 100;
        pickNewPosition();
        updateIndicator();
        Time.timeScale = 0;
	}
    
    void Update() {
        countHandler();
        timerHandler();
    }
}
