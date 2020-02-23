using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    private static LevelManager _instance;
    public static LevelManager instance => _instance;
    public int level;

    void Awake()
    {

        if (_instance == null)
        {

            _instance = this;
            // DontDestroyOnLoad(this.gameObject);

            //Rest of your Awake code

        }
        else
        {
            Destroy(this);
        }
    }
    void Start()
    {
        switch (level)
        {
            case 1:
                PlayerManager.instance.soundManage.playMusicPart2();
                break;
            case 2:
                PlayerManager.instance.soundManage.playMusicPart4();
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("InvisiblePlayer"))
        {
            NextScene();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("InvisiblePlayer"))
        {
            GameOver();
        }
    }
    public void NextScene()
    {
        Debug.Log("next");
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
