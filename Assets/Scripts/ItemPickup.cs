using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ItemPickup : MonoBehaviour, IPickupable
{
    public PrankItem item;
    private bool fetched;

    public void Pickup()
    {
        Destroy(gameObject);
    }

    // Use this for initialization
    void Start()
    {
        //var getImage = UnityEditor.AssetPreview.GetMiniThumbnail(this.gameObject);
       // Sprite mySprite = Sprite.Create(getImage, new Rect(0.0f, 0.0f, getImage.width, getImage.height), new Vector2(0.5f, 0.5f), 100.0f);
        //item.Icon = mySprite;

    }

    // Update is called once per frame
    void Update()
    {
        if (!fetched)
        {
            CheckIfNull();
        }
        

    }

    void CheckIfNull()
    {

        /*
                var instance = this.gameObject.GetInstanceID();
                if (UnityEditor.AssetPreview.IsLoadingAssetPreview(instance))
                {
                    Debug.Log("Still fetching");
                }
                else
                {
                    var getAssetPreview = UnityEditor.AssetPreview.GetAssetPreview(gameObject);

                    if (getAssetPreview == null)
                    {
                        return;
                    }

                    Sprite mySprite = Sprite.Create(getAssetPreview, new Rect(0.0f, 0.0f, getAssetPreview.width, getAssetPreview.height), new Vector2(0.5f, 0.5f), 100.0f);
                    if (mySprite == null)
                    {
                        return;
                    }
                    item.Icon = mySprite;
                    fetched = true;
                }
             */
    }
}
