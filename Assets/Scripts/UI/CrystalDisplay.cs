using TMPro;
using UnityEngine;

public class CrystalDisplay : MonoBehaviour
{
    [SerializeField]
    private PlayerStats _player;
    [SerializeField]
    private TMP_Text _text;

    private void OnEnable()
    {
        _player.CrystalCountChanged += OnCrystalCountChanged;   
    }

    private void OnDisable()
    {
        _player.CrystalCountChanged -= OnCrystalCountChanged;
    }

    private void OnCrystalCountChanged(int crystals)
    {
        _text.text = "Crystals: " + crystals.ToString();
    }
}
