using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapPointInfoSummon : MonoBehaviour
{
    public Info placeInfo;
    public PictureLibrary picture;
    public GameObject ui;
    public Button image;
    public Text placeName;
    public Text placeDescription;
    public GameObject shortcuts;
    public GameObject cameraPan;
    public ImageSceneLoader imageLoader;

    // Start is called before the first frame update
    void Start()
    {
        if (placeInfo.pictureLibrary != null)
        {
            picture = placeInfo.pictureLibrary;
        }
    }

    public void OnMouseDown()
    {
        onClickOpen();
    }

    public void onClickOpen()
    {
        shortcuts.SetActive(false);
        cameraPan.SetActive(false);
        ui.SetActive(true);
        if (picture != null)
        {
            image.image.sprite = picture.images[0];
            imageLoader = image.GetComponent<ImageSceneLoader>();
            imageLoader.activePictureLib = picture;
        }
        placeName.text = placeInfo.PlaceName;
        placeDescription.text = placeInfo.description;

    }

    public void onClickClose()
    {
        shortcuts.SetActive(true);
        cameraPan.SetActive(true);
        ui.SetActive(false);
    }
}
