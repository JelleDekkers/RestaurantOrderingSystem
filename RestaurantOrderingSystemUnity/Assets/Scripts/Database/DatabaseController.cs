using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseController : MonoBehaviour {

    public const string getScoresUrl = "http://studenthome.hku.nl/~jelle.dekkers/kernmodule4/getScores.php";

    public ScoreData[] scores;

    private void Start() {
        StartCoroutine(GetScores());
    }

    private IEnumerator GetScores() {
        using (WWW request = new WWW(getScoresUrl)) {
            yield return request;
            scores = CreateArrayFromJson(JsonHelper.FixJsonString(request.text));
        }
        Debug.Log("Done retrieving scores");
    }

    public ScoreData[] CreateArrayFromJson(string jsonArray) {
        return JsonHelper.FromJson<ScoreData>(jsonArray);
    }
}
