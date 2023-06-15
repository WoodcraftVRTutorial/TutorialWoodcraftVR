using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Localization;
//using UnityEngine.Localization.Settings;

public class SpawnableLanguageBtn : BaseSpawnableButton
{
    [SerializeField] private int _languageIdentifier = 0;
    private List<BasePanel> _allPanelsInScene = new List<BasePanel>();

    public override void Start()
    {
        base.Start();
        _allPanelsInScene = new List<BasePanel>(FindObjectsOfType<BasePanel>(true));
    }
    public override void onClick()
    {
        for (int i = 0; i < 5; i++)
        {
            LoadLocale(_languageIdentifier);
        }
    }

    public void LoadLocale(int languageIdentifier)
    {
        //LocalizationSettings settings = LocalizationSettings.Instance;
        //LocaleIdentifier localeCode = new LocaleIdentifier(languageIdentifier);
        //for (int i = 0; i < LocalizationSettings.AvailableLocales.Locales.Count; i++)
        //{
        //    Locale aLocale = LocalizationSettings.AvailableLocales.Locales[i];
        //    LocaleIdentifier anIdentifier = aLocale.Identifier;
        //    if (anIdentifier == localeCode)
        //    {
        //        LocalizationSettings.SelectedLocale = aLocale;
        //    }
        //}

        //AppManager.Instance.LanguageIdentifier = _languageIdentifier;

        //foreach (var panelInScene in _allPanelsInScene)
        //    panelInScene.SetLanguage = _languageIdentifier;
    }
}
