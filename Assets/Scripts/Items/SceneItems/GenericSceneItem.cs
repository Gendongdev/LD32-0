using UnityEngine;
using System.Collections;

public class GenericSceneItem : SceneItem {
    public string m_keyMessage;

    public override void Use(InventoryItem item)
    {
        base.Use(item);
    }
    public override void Look()
    {
        MessageServer.SendMessage(m_keyMessage,Color.white);
    }

}
