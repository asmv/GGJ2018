using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public float time;
	public float levelDuration{get; protected set;}
	public Queue<KeyValuePair<float, string>> eventQueue;
	public Dictionary<int, Enemy> enemies;

	public SpawnZone SZ;

	public Transform enemyPrefabRoot;

	/// <summary>
	/// Provides the completion percentage of this level at any given time.
	/// </summary>
	/// <returns>Float value between 0 and 1 representing the fraction of level that was completed.</returns>
	float getLevelProgress(){
		return time/levelDuration;
	}

	// Use this for initialization
	void Start () {
		time = 0;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if(time >= levelDuration){
			levelWin();
		}else{
			KeyValuePair<float, string> q = eventQueue.Peek();
			if(q.Key >= time){
				deserializeEvent(q.Value);
				eventQueue.Dequeue();
			}
		}
	}

	public void setlevelDuration(float duration){
		this.levelDuration = duration;
	}

	public void levelWin(){

	}

	public void levelFail(){

	}

	public List<Enemy> instantiateFromEnumeration(List<ENEMYTYPE> types){
		List<Enemy> ret = new List<Enemy>();
		foreach(ENEMYTYPE type in types){
			GameObject EnemyGO = Instantiate(enemyPrefabRoot.Find(type.ToString()).gameObject);
			EnemyGO.SetActive(false); //ideally should be inactive in prefab anyway 
			Enemy enemy = EnemyGO.GetComponent<Enemy>();
			ret.Add(enemy);
		}
		if(types.Count < ret.Count){
			Debug.Log("Warning, not all Enemies were instantiated.");
		}
		return ret;
	}

	public void spawnEnemy(List<Enemy> enemyArr, float minSeparationDistance){
		float enemyAggregateWidth = 0;
		float maxEnemyHeight = 0;
		foreach(Enemy e in enemyArr){
			enemies.Add(e.objectId, e);
			BoxCollider2D col = e.GetComponent<BoxCollider2D>();
			enemyAggregateWidth += col.bounds.size.x;
			float eHeight = col.bounds.size.y;
			if(eHeight > maxEnemyHeight){
				maxEnemyHeight = eHeight;
			}
		}
	}

	public Enemy getClosestToLocation(Vector2 location){
		KeyValuePair<float, Enemy> closest = new KeyValuePair<float, Enemy>(float.MaxValue, null);
		foreach(Enemy e in enemies.Values){
			float dist = Vector2.Distance(location, e.get2DCoordinates());
			if(dist > closest.Key){
				closest = new KeyValuePair<float, Enemy>(dist, e);
			}
		}
		return closest.Value;
	}

	public void deserializeEvent(string eventString){
		//create enemies, etc.
	}
}
