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
        if (level == 1)
        {
            PlayerManager.instance.soundManage.playMusicPart3();
        }
        else
        {
            PlayerManager.instance.soundManage.playMusicPart4();
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("InvisiblePlayer"))
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
