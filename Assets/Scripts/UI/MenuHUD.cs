using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuHUD : MonoBehaviour
{
    [SerializeField] private TMP_Text bestScore;
    public TMP_Text scoreText;
    [SerializeField] private TMP_Text playText;
    [SerializeField] private TMP_Text settingsText;
    [SerializeField] private TMP_Text creatText;
    [SerializeField] private TMP_Text soundText;

    [SerializeField] private GameObject soundOn;
    [SerializeField] private GameObject soundOff;

    [SerializeField] private GameObject[] selects;

    [SerializeField] private AudioClip clickBtn;

    private static MenuHUD menu_instance;

    public static MenuHUD Menu_instance { get => menu_instance; }

    private void Awake()
    {
        if (menu_instance == null)
            menu_instance = this;
        
        CheckLanguage();

        if (AudioListener.volume == 1.0f)
        {
            soundOn.SetActive(true);
            soundOff.SetActive(false);
        }
        else if (AudioListener.volume == 0.0f)
        {
            soundOff.SetActive(true);
            soundOn.SetActive(false);
        }
    }

    public void ClickButton()
    {
        AudioSource.PlayClipAtPoint(clickBtn, transform.position, 10f);
    }

    public void CreatBall()
    {
        Application.OpenURL("https://www.piskelapp.com/");
    }

    private void CheckLanguage()
    {
        if (PlayerPrefs.GetString("Language") == "ru_RU")
        {
            bestScore.text = LanguageSystem.Lang.best_s;
            bestScore.fontSize = 190;
            playText.text = LanguageSystem.Lang.play;
            playText.fontSize = 140;
            settingsText.text = LanguageSystem.Lang.settings;
            settingsText.fontSize = 110;
            creatText.text = LanguageSystem.Lang.creat;
            creatText.fontSize = 82;
            soundText.text = LanguageSystem.Lang.sound;
            selects[0].SetActive(false);
        }
        else if (PlayerPrefs.GetString("Language") == "en_US")
        {
            bestScore.text = LanguageSystem.Lang.best_s;
            bestScore.fontSize = 240;
            playText.text = LanguageSystem.Lang.play;
            playText.fontSize = 160;
            settingsText.text = LanguageSystem.Lang.settings;
            settingsText.fontSize = 160;
            creatText.text = LanguageSystem.Lang.creat;
            creatText.fontSize = 160;
            soundText.text = LanguageSystem.Lang.sound;
            selects[1].SetActive(false);
        }
        else if (PlayerPrefs.GetString("Language") == "de_DE")
        {
            bestScore.text = LanguageSystem.Lang.best_s;
            bestScore.fontSize = 190;
            playText.text = LanguageSystem.Lang.play;
            playText.fontSize = 140;
            settingsText.text = LanguageSystem.Lang.settings;
            settingsText.fontSize = 120;
            creatText.text = LanguageSystem.Lang.creat;
            creatText.fontSize = 120;
            soundText.text = LanguageSystem.Lang.sound;
            selects[2].SetActive(false);
        }
        else if (PlayerPrefs.GetString("Language") == "fr_FR")
        {
            bestScore.text = LanguageSystem.Lang.best_s;
            bestScore.fontSize = 190;
            playText.text = LanguageSystem.Lang.play;
            playText.fontSize = 140;
            settingsText.text = LanguageSystem.Lang.settings;
            settingsText.fontSize = 130;
            creatText.text = LanguageSystem.Lang.creat;
            creatText.fontSize = 120;
            soundText.text = LanguageSystem.Lang.sound;
            selects[3].SetActive(false);
        }
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SoundControl()
    {
        if (soundOn.activeInHierarchy)
        {
            soundOn.SetActive(false);
            soundOff.SetActive(true);
            AudioListener.volume = 0.0f;
        }
        else if (soundOff.activeInHierarchy)
        {
            soundOff.SetActive(false);
            soundOn.SetActive(true);
            AudioListener.volume = 1.0f;
        }
    }

    public void ENGButton()
    {
        bestScore.text = LanguageSystem.Lang.best_s;
        bestScore.fontSize = 240;
        playText.text = LanguageSystem.Lang.play;
        playText.fontSize = 160;
        settingsText.text = LanguageSystem.Lang.settings;
        settingsText.fontSize = 160;
        creatText.text = LanguageSystem.Lang.creat;
        creatText.fontSize = 160;
        soundText.text = LanguageSystem.Lang.sound;
    }

    public void RUSButton()
    {
        bestScore.text = LanguageSystem.Lang.best_s;
        bestScore.fontSize = 190;
        playText.text = LanguageSystem.Lang.play;
        playText.fontSize = 140;
        settingsText.text = LanguageSystem.Lang.settings;
        settingsText.fontSize = 110;
        creatText.text = LanguageSystem.Lang.creat;
        creatText.fontSize = 82;
        soundText.text = LanguageSystem.Lang.sound;
    }

    public void GERButton()
    {
        bestScore.text = LanguageSystem.Lang.best_s;
        bestScore.fontSize = 190;
        playText.text = LanguageSystem.Lang.play;
        playText.fontSize = 140;
        settingsText.text = LanguageSystem.Lang.settings;
        settingsText.fontSize = 120;
        creatText.text = LanguageSystem.Lang.creat;
        creatText.fontSize = 120;
        soundText.text = LanguageSystem.Lang.sound;
    }

    public void FRCButton()
    {
        bestScore.text = LanguageSystem.Lang.best_s;
        bestScore.fontSize = 190;
        playText.text = LanguageSystem.Lang.play;
        playText.fontSize = 140;
        settingsText.text = LanguageSystem.Lang.settings;
        settingsText.fontSize = 130;
        creatText.text = LanguageSystem.Lang.creat;
        creatText.fontSize = 120;
        soundText.text = LanguageSystem.Lang.sound;
    }
}