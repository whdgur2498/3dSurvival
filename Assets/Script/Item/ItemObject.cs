using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public string GetInteracPrompt();
    public void OnInteract();
}

public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemData ItemData;

    public string GetInteracPrompt()
    {
        string str = $"{ItemData.displayname}\n{ItemData.description}";
        return str ;
    }

    public void OnInteract()
    {
        CharacterManager.Instance.Player.itemData = ItemData;
        CharacterManager.Instance.Player.additem?.Invoke();
        Destroy(gameObject);
    }
}
