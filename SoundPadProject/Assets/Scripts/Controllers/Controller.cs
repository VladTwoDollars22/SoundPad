using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    [SerializeField] private SoundPad _soundPad;
    
    public void SwitchPauseState() => AudioSystem.Instance.SwitchPauseState();
    public void Open() => _soundPad.Open();
    public void Close() => _soundPad.Close();
    public void Next() => AudioSystem.Instance.NextTrack();
    public void Previous() => AudioSystem.Instance.PreviousTrack();
    public void OnVolumeChanged()
    {
        AudioSystem.Instance.SetVolume(_soundPad.ScrollBar.value);
    }
    private void Start()
    {
        _soundPad.Open();
    }

}
