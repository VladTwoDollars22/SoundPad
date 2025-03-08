using UnityEngine;

[CreateAssetMenu(fileName = "NewMusic", menuName = "Audio/Music")]
public class MusicData : ScriptableObject
{
    public string musicName;
    public string author;
    public AudioClip clip;
}
