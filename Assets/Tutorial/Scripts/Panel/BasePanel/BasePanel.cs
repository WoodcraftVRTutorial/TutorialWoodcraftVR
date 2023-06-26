using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using System;

[RequireComponent(typeof(TextMeshProUGUI))]
public abstract class BasePanel : MonoBehaviour
{
    [Serializable]
    protected class PagesWrapper
    {
        public List<BasePanelPage> Pages = new List<BasePanelPage>();
    }
    [SerializeField]
    protected List<PagesWrapper> _pages = new List<PagesWrapper>();
    [SerializeField]
    protected GameObject _spawnParent;

    public UnityEvent OnNextEventPostUpdate;
    public UnityEvent OnNextEventPreUpdate;

    public UnityEvent OnPreviousEventPostUpdate;
    public UnityEvent OnPreviousEventPreUpdate;

    public UnityEvent OnReset;
    public int SetLanguage
    {
        set { _currentPageLanguage = value; }
    }

    protected List<GameObject> _spawnedPool = new List<GameObject>();
    protected int _currentPageIndex = 0;
    protected TextMeshProUGUI _pageText;
    protected int _currentPageLanguage = 0;

    public virtual void Awake()
    {
        _pageText = GetComponent<TextMeshProUGUI>();
    }

    public virtual void Start()
    {
        UpdatePanel();
    }

    public int CurrentPageIndex
    {
        get { return _currentPageIndex; }
        set { _currentPageIndex = value; }
    }

    public virtual void ChangePanelTextByDelim(string delim, string replacementText)
    {
        _pageText.text = _pageText.text.Replace(delim,replacementText);
    }

    public virtual void NextPage()
    {
        NextPage(_currentPageIndex + 1);
    }

    public virtual void NextPage(int index)
    {

        if (_currentPageIndex < _pages[_currentPageLanguage].Pages.Count - 1)
        {
            _currentPageIndex = index;

            if (OnNextEventPreUpdate != null)
                OnNextEventPreUpdate.Invoke();
            UpdatePanel();
            if (OnNextEventPostUpdate != null)
                OnNextEventPostUpdate.Invoke();
        }
    }

    public virtual void PreviousPage()
    {
        PreviousPage(_currentPageIndex - 1);
    }

    public virtual void PreviousPage(int index)
    {

        if (_currentPageIndex > 0)
        {
            _currentPageIndex = index;

            if (OnPreviousEventPreUpdate != null)
                OnPreviousEventPreUpdate.Invoke();
            UpdatePanel();
            if (OnPreviousEventPostUpdate != null)
                OnPreviousEventPostUpdate.Invoke();
        }
    }

    public virtual void ResetPanel()
    {
        if (OnReset != null)
            OnReset.Invoke();

        _currentPageIndex = 0;
        UpdatePanel();
    }

    public virtual void UpdatePanel()
    {
        SetPageText();
    }

    protected void SetPageText()
    {
        _pageText.text = _pages[_currentPageLanguage].Pages[_currentPageIndex].PageText;
    }
}
