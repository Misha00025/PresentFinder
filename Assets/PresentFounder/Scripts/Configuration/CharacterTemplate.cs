using UnityEngine;

[CreateAssetMenu(fileName = "CharacterTemplate", menuName = "Character/CharacterTemplate")]
public class CharacterTemplate : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField] public int MaxHealth { get; private set; }
}
