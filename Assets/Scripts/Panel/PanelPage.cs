using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Localization;
using System;

[CreateAssetMenu(fileName = "PanelPage", menuName = "HitLab/PanelObject")]
public class PanelPage : BasePanelPage
{
    public enum Language
    {
        Dutch = 0,
        English,
        French,
        German,
        Greek,
        Turkish,
    }

    [Serializable]
    public class ImagePanelObject
    {
        public Sprite Image;
        public Vector2 Position = Vector2.zero;
        public Vector2 Scale = Vector2.one;
        public float Rotation = 0.0f;
        public bool LocalizeImage = false;
        public string LocalizedKey = "";
        public string LocalizedTable = "";
    }

    [Serializable]
    public class ButtonPanelObject
    {
        public GameObject Button;
        public Vector2 Position = Vector2.zero;
        public Vector2 Scale = Vector2.one;
    }
    public Language PageLanguage = Language.Dutch;
    public AudioClip Clip;
    public bool AutoPlay = false;
    
    public List<ImagePanelObject> ImagePool = new List<ImagePanelObject>();
    public List<ButtonPanelObject> ButtonPool = new List<ButtonPanelObject>();
    public List<GameObject> SfxPool = new List<GameObject>();
}
