using UnityEngine;
using FYFY;
using System.Security.Cryptography;

public class RandomMovingSystem : FSystem {
	// Use this to update member variables when system pause. 
	// Advice: avoid to update your families inside this function.
	private Family randomMovingGO = FamilyManager.getFamily(new AllOfComponents(typeof(Move), typeof(RandomTarget)));

    public RandomMovingSystem()
    {
        foreach (GameObject gameObject in randomMovingGO)
        {
			onGOEnter(gameObject);
        }
    }

	private void onGOEnter(GameObject go)
    {
		go.GetComponent<RandomTarget>().target = GetRandomPoint(go);
    }

	private Vector3 GetRandomPoint(GameObject go)
    {
		RandomTarget rt = go.GetComponent<RandomTarget>();
		return new Vector3(Random.Range(-rt.size, rt.size), Random.Range(-rt.size, rt.size), 0);
    }


	protected override void onPause(int currentFrame) {
	}

	// Use this to update member variables when system resume.
	// Advice: avoid to update your families inside this function.
	protected override void onResume(int currentFrame){
	}

	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
        foreach (GameObject go in randomMovingGO)
        {
			RandomTarget rt = go.GetComponent<RandomTarget>();

            if (rt.target.Equals(go.transform.position))
            {
				rt.target = GetRandomPoint(go);
            }
            else
            {
				go.transform.position = Vector3.MoveTowards(go.transform.position, rt.target, go.GetComponent<Move>().speed * Time.deltaTime);
            }
        }
	}
}