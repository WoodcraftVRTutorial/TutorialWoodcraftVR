using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class NormalTextPanel : BasePanel
{
    [SerializeField]
    private bool _useAudio = true;
    [SerializeField]
    private bool _isDebug = false;
    private AudioSource _audioSource;
    private bool _playOnStart = true;

    public bool UseAudio
    {
        get { return _useAudio; }
        set { _useAudio = value; }
    }

    public override void Awake()
    {
        base.Awake();
        _audioSource = this.GetComponent<AudioSource>();

        
    }
    private void Update()
    {
        if (_isDebug)
        {
            CleanupObjects();
            UpdatePanel();
        }
    }

    public override void Start()
    {
        base.Start();          
    }

    public override void NextPage()
    {
        CleanupObjects();
        base.NextPage();
    }

    public override void UpdatePanel()
    {
        base.UpdatePanel();
        SpawnImages();
        if (_useAudio)
            SpawnAudio();
        SpawnButtons();
        SpawnEffects();
        
        string key = _pages[_currentPageLanguage].Pages[_currentPageIndex].PageText;

    }

    private void SpawnImages()
    {

        foreach (var image in ((PanelPage)_pages[_currentPageLanguage].Pages[_currentPageIndex]).ImagePool)
        {


            var parent = _spawnParent == null ? this.transform.parent : _spawnParent.transform;
            var imageObj = new GameObject();
            imageObj.transform.SetParent(parent);

            imageObj.AddComponent<UnityEngine.UI.Image>().sprite = image.Image;

            imageObj.transform.localScale = image.Scale;
            imageObj.transform.localPosition = image.Position;
            imageObj.transform.localEulerAngles = new Vector3(0, 0, image.Rotation);
            _spawnedPool.Add(imageObj);
        }
    }

    private void SpawnButtons()
    {
        foreach (var button in ((PanelPage)_pages[_currentPageLanguage].Pages[_currentPageIndex]).ButtonPool)
        {
            var parent = _spawnParent == null ? this.transform.parent : _spawnParent.transform;
            var buttonObj = Instantiate(button.Button);
            buttonObj.transform.SetParent(parent);
            buttonObj.transform.localPosition = button.Position;
            buttonObj.transform.localScale = button.Scale;
            buttonObj.transform.localEulerAngles = Vector3.zero;
            _spawnedPool.Add(buttonObj);
        }
    }

    private void SpawnEffects()
    {
        foreach (var effect in ((PanelPage)_pages[_currentPageLanguage].Pages[_currentPageIndex]).SfxPool)
        {
            var parent = _spawnParent == null ? this.transform.parent : _spawnParent.transform;
            var spawnedEffect = Instantiate(effect);
            spawnedEffect.transform.SetParent(parent);
            spawnedEffect.transform.localPosition = Vector3.zero;
            spawnedEffect.transform.localScale = Vector3.one;
            spawnedEffect.transform.localEulerAngles = Vector3.zero;
            _spawnedPool.Add(spawnedEffect);
        }
    }

    private void SpawnAudio()
    {
        var audioObject = ((PanelPage)_pages[_currentPageLanguage].Pages[_currentPageIndex]).Clip;
        if(audioObject != null)
        {
            _audioSource.clip = audioObject;
            if (((PanelPage)_pages[_currentPageLanguage].Pages[_currentPageIndex]).AutoPlay)
            {
                _audioSource.Play();
            }
        }
    }

    public void PlayCurrentAudioSource()
    {
        _audioSource.Play();
    }

    public void CleanupObjects()
    {
        foreach (var obj in _spawnedPool)
        {
            Destroy(obj);
        }
       
        _audioSource.clip = null;
    }
}
