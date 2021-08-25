using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameHUD : MonoBehaviour
{
    PlayerController player;

    [SerializeField] GameObject[] hearts;

    [SerializeField] private TMP_Text[] scoreTexts;

    [SerializeField] private GameObject loosePanel;

    [SerializeField] private TMP_Text scoreLable;

    [SerializeField] private AudioClip clickBtn;

    private void Awake()
    {
        GameController.Instance.Score = 0;

        CheckLanguage();
    }

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        for (int i = 0; i < scoreTexts.Length; i++)
        {
            scoreTexts[i].text = GameController.Instance.Score.ToString();
        }

        HealthControll();
    }

    public void ClickButton()
    {
        AudioSource.PlayClipAtPoint(clickBtn, transform.position, 10f);
    }

    void CheckLanguage()
    {
        if (PlayerPrefs.GetString("Language") == "ru_RU")
        {
            scoreLable.text = LanguageSystem.Lang.score;
        }
        else if (PlayerPrefs.GetString("Language") == "en_US")
        {
            scoreLable.text = LanguageSystem.Lang.score;
        }
        else if (PlayerPrefs.GetString("Language") == "de_DE")
        {
            scoreLable.text = LanguageSystem.Lang.score;
        }
        else if (PlayerPrefs.GetString("Language") == "fr_FR")
        {
            scoreLable.text = LanguageSystem.Lang.score;
        }
    }

    void HealthControll()
    {
        if (player.Health == 2)
        {
            hearts[2].SetActive(false);
        }
        else if (player.Health == 1)
        {
            hearts[1].SetActive(false);
        }
        else if (player.Health <= 0)
        {
            hearts[0].SetActive(false);
            Time.timeScale = 0f;
            loosePanel.SetActive(true);
        }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
    }

    public void Reload()
    {
        GameController.Instance.Score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}