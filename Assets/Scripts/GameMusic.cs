using UnityEngine;
using UnityEngine.SceneManagement;

//plays intial main menu music that persists between main menu, credits, how to play, and bonus/difficulty screen
public class GameMusic : MonoBehaviour
{
    int sceneBuildIndex;
    public AudioClip[] musicChoices;
    AudioSource music;
    private static GameMusic instance = null;
    public static GameMusic Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {

    }

    private void Update()
    {

    }

    public void playMusic()
    {
        GameMusic.instance.music = GetComponent<AudioSource>();
        sceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("called playmusic function");
        if (sceneBuildIndex == 0)
        {
            if (GameMusic.instance.music.clip != musicChoices[0])
            {
                GameMusic.instance.music.Stop();
                GameMusic.instance.music.clip = musicChoices[0];
                GameMusic.instance.music.Play();
            }
              
        }

        if (sceneBuildIndex == 2)
        {
            if (GameMusic.instance.music.clip != musicChoices[1])
            {
                GameMusic.instance.music.Stop();
                GameMusic.instance.music.clip = musicChoices[1];
                GameMusic.instance.music.Play();
            }
        }
    }
}
