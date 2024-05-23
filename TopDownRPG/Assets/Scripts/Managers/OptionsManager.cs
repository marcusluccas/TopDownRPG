using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    public static OptionsManager instance { get; private set; }

    public GameObject options;

    public List<AudioSource> audioSources;

    public Slider sliderVolume;

    public Dropdown resolutionDropdown;

    private void Awake()
    {
        if (instance != null && instance != this.gameObject)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            options.SetActive(true);
            foreach (AudioSource source in audioSources)
            {
                if (source != audioSources[0])
                {
                    source.enabled = false;
                }
            }
            Time.timeScale = 0;
        }
    }

    public void ApplyOptions()
    {
        options.SetActive(false);
        foreach (AudioSource source in audioSources) {
            if (source != audioSources[0])
            {
                source.enabled = true;
            }
        }
        Time.timeScale = 1;
    }

    public void ApplyVolume()
    {
        foreach (AudioSource source in audioSources)
        {
            source.volume = sliderVolume.value;
        }
    }

    public void ApplyResolution()
    {
        if (resolutionDropdown.value == 0)
        {
            Screen.SetResolution(1920, 1080, false);
        }
        else if (resolutionDropdown.value == 1)
        {
            Screen.SetResolution(1366, 768, false);
        }
        else
        {
            Screen.SetResolution(1080, 720, false);
        }
    }
}
