using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Singleton.
/// </summary>
/// <seealso cref="MonoBehaviour" />
public class Singleton : MonoBehaviour
{
    public static Singleton instance;

    public EntityPlayer entityPlayer;
    public bool isPaused;
    public int difficulty;

    // Awake is called when the script instance is being loaded
    public void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;

            entityPlayer = (EntityPlayer)ScriptableObject.CreateInstance(typeof(EntityDefault));
            isPaused = false;
            difficulty = 0;

            DontDestroyOnLoad(gameObject);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0.0f;
        this.isPaused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        this.isPaused = false;
    }
}
