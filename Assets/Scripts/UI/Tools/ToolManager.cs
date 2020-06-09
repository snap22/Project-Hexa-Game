using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class ToolManager
{
    private List<ITool> tools;

    public ToolManager(Tilemap lockedTileMap, GameObject selectionPanel)
    {
        tools = new List<ITool>();

        tools.Add(new SelectionTool(selectionPanel));
        tools.Add(new BuildTool(lockedTileMap));
        tools.Add(new UnlockTool(lockedTileMap));
        tools.Add(new RemoveTool());
        
    }

    public ITool GetTool(int index)
    {
        if (index >= tools.Count || index < 0)
        {
            index = 0;
        }
        return tools[index];
    }
}
