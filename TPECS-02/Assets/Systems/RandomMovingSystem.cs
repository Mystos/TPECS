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
		go.transform.position = new Vector3((Random.value - 0.5f) * 7,
			(Random.value - 0.5f) * 5.2f);
		go.GetComponent<RandomTarget>().target = go.transform.position;
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
				rt.target = new Vector3((Random.value - 0.5f) * 7,
			(Random.value - 0.5f) * 5.2f);
            }
            else
            {
				go.transform.position = Vector3.MoveTowards(go.transform.position, rt.target, go.GetComponent<Move>().speed * Time.deltaTime);
            }
        }
	}
}