using System.Collections;
using UnityEngine;
using System.IO;

public class LanguageSystem : MonoBehaviour
{
    private static LanguageSystem m_instance;
    public static LanguageSystem m_Instance { get => m_instance; }

    private string json;

    public static Lang Lang = new Lang();

    public int indexLang = 1;
    private string[] languageArray = { "en_US", "ru_RU", "de_DE", "fr_FR" };

    private void Awake()
    {
        if (m_instance == null)
            m_instance = this;
        
        if (!PlayerPrefs.HasKey("Language"))
        {
            //if (Application.systemLanguage == SystemLanguage.Russian || Application.systemLanguage == SystemLanguage.Ukrainian
            //    || Application.systemLanguage == SystemLanguage.Belarusian)
            //{
            //    PlayerPrefs.SetString("Language", "ru_RU");
            //}

            if (Application.systemLanguage == SystemLanguage.Russian)
            {
                PlayerPrefs.SetString("Language", "ru_RU");
            }
            else if (Application.systemLanguage == SystemLanguage.German)
            {
                PlayerPrefs.SetString("Language", "de_DE");
            }
            else if (Application.systemLanguage == SystemLanguage.French)
            {
                PlayerPrefs.SetString("Language", "fr_FR");
            }
            else PlayerPrefs.SetString("Language", "en_US");
        }

        LanguageLoad();
    }

    public void LanguageLoad()
    {
#if UNITY_ANDROID && !UNITY_EDITOR || UNITY_REMOTE
                string path = Path.Combine(Application.streamingAssetsPath, "Languages/" + PlayerPrefs.GetString("Language") + ".json");
                WWW reader = new WWW(path);
                while (!reader.isDone) { }
                json = reader.text;
                Lang = JsonUtility.FromJson<Lang>(json);
#endif

#if UNITY_EDITOR
        json = File.ReadAllText(Application.streamingAssetsPath + "/Languages/" + PlayerPrefs.GetString("Language") + ".json");

        Lang = JsonUtility.FromJson<Lang>(json);
#endif
    }

    public void SwitchLanguage(int langIndex)
    {
        indexLang = langIndex;
        if (langIndex != languageArray.Length)
            langIndex++;
        else langIndex = 1;

        PlayerPrefs.SetString("Language", languageArray[langIndex - 1]);

        LanguageLoad();
    }
}

public class Lang
{
    //���� ������� ����� ������������:
    public string play;
    public string best_s;
    public string settings;
    public string creat;
    public string sound;
    public string score;
}