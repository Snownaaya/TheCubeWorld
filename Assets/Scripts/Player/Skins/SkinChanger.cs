using Assets.Scripts.Player.Skins;
using Assets.Scripts.Datas.Character;
using System;
using UnityEngine;

public class SkinChanger : MonoBehaviour
{
    [SerializeField] private SkinConfig _defaultSkin;

    private SkinView[] _skinViews;

    public event Action<CharacterSkins> SkinChanged;

    private void Awake()
    {
        _skinViews = GetComponentsInChildren<SkinView>(includeInactive: true);
        ActivateSkin(_defaultSkin.CharacterSkins);
    }

    public void Change(CharacterSkins skin)
    {
        ActivateSkin(skin);
        SkinChanged?.Invoke(skin);
    }

    private void ActivateSkin(CharacterSkins targetSkin)
    {
        foreach (SkinView skinView in _skinViews)
            skinView.gameObject.SetActive(skinView.SkinType == targetSkin);
    }
}