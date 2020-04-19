using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageLibraryLibrary : MonoBehaviour
{
    public string activeLibraryName;
    public PictureLibrary activeLibrary;

    public PictureLibrary[] pictureLibraryLib;
    public Image image;
    public Text desc;

    public int page;


    // Start is called before the first frame update
    void Start()
    {
        activeLibraryName = PlayerPrefs.GetString("PicLibrary");
        foreach (PictureLibrary i in pictureLibraryLib)
        {
            if (i.name == activeLibraryName)
            {
                activeLibrary = i;
            }
            else
            {
                continue;
            }
        }
        page = 0;
        updateUI();
    }

    public void GoForward()
    {
        page += 1;
        if(page > activeLibrary.images.Length)
        {
            page = 0;
        }
        updateUI();
    }

    public void GoBack()
    {
        page -= 1;
        if (page < 0)
        {
            page = activeLibrary.images.Length;
        }
        updateUI();
    }

    void updateUI()
    {
        image.sprite = activeLibrary.images [page];
        desc.text = activeLibrary.description [page];
    }
}
