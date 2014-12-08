using UnityEngine;
using System.Collections;

public class PirateSingerSceneItem : SceneItem
{
    public override void Use(InventoryItem item)
    {
        if (item == null)
        {
            MessageServer.SendMessage("song_text", Color.cyan);
        }
        else
        {
            base.Use(item);
        }
    }
}
