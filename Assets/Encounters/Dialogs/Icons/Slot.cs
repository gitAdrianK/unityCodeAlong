using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Slot.
/// </summary>
/// <seealso cref="MonoBehaviour" />
public class Slot : MonoBehaviour
{
    private static Color DEFAULT_COLOUR = new Color(0.2358491f, 0.2358491f, 0.2358491f);
    private static Color OCCUPIED_COLOUR = new Color(0.4313726f, 0.8862746f, 0.3568628f);

    // The icon that is associated with this slot
    private GameObject icon;

    public GameObject Icon { get => icon; }

    /// <summary>
    /// Adds game object from the slot.
    /// </summary>
    /// <param name="obj">The game object.</param>
    public void AddGameObject(GameObject obj)
    {
        icon = obj;
        GetComponent<SpriteRenderer>().color = OCCUPIED_COLOUR;
    }

    /// <summary>
    /// Removes game object from the slot.
    /// </summary>
    public void RemoveGameObject()
    {
        icon = null;
        GetComponent<SpriteRenderer>().color = DEFAULT_COLOUR;
    }
}
