using System.Collections;
using System.Collections.Generic;
using MiniJSON;
using System.IO;
using UnityEngine;

public static class LevelLoader{

    private static List<Event> eventQueue;

    private static void readLevel(string filepath) {
        string lvl = File.ReadAllText(filepath);
       
        var dict = Json.Deserialize(lvl) as Dictionary<string, object>;
        List<object> evnt = (List<object>)dict["events"];

        foreach (Dictionary<string, object> dict2 in evnt) {
            string str = dict2["delay"].ToString();
            float delay = float.Parse(str);
            ENEMYTYPE enemy = (ENEMYTYPE)System.Enum.Parse(typeof(ENEMYTYPE), dict2["enemy"].ToString());
            FORMATYPE forma = (FORMATYPE)System.Enum.Parse(typeof(FORMATYPE), dict2["forma"].ToString());
            Event e = new Event(delay, enemy, forma);
            eventQueue.Add(e);
        }
    }

    public static List<Event> getEvents(){
        eventQueue = new List<Event>();
        readLevel("Assets/_Scripts/Levels/lvl1");
        return eventQueue;
    }
}
