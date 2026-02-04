using Assets.Scripts.Player.Skins;
using Assets.Scripts.Datas.Character;
using System;
using UnityEngine;
using Reflex.Attributes;

public class SkinChanger : MonoBehaviour
{
    private SkinView[] _skinViews;
    private IPersistentCharacterData _persistentCharacterData;

    private void Start()
    {
        _skinViews = GetComponentsInChildren<SkinView>(includeInactive: true);
        CharacterSkins savedSkin = _persistentCharacterData.SelectedCharacterSkin;
        ActivateSkin(savedSkin);
    }

    [Inject]
    private void Construct(IPersistentCharacterData persistentCharacterData) =>
        _persistentCharacterData = persistentCharacterData;

    public void Change(CharacterSkins skin) =>
        ActivateSkin(skin);

    private void ActivateSkin(CharacterSkins targetSkin)
    {
        foreach (SkinView skinView in _skinViews)
            skinView.gameObject.SetActive(skinView.SkinType == targetSkin);
    }
}