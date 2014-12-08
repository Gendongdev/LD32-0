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
            if (item is OctoropeInventoryItem)
            {
                MessageServer.SendMessage("SCENE_ITEM_PIRATE_SINGER_COMBINE_OCTOROPE", Color.cyan);
            }
            else
            {
                MessageServer.SendMessage("SCENE_ITEM_PIRATE_SINGER_COMBINE_OTHER", Color.cyan);
            }
        }
    }
}
