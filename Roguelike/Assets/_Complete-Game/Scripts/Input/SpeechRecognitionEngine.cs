using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Completed;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class SpeechRecognitionEngine : MonoBehaviour
{
    public string[] keywords = new string[] { "up", "down", "left", "right"};
    public float speed = 1;
    public Player player;

    protected PhraseRecognizer recognizer;
    protected string word = "";

    private void Start()
    {
        if (keywords != null && recognizer == null)
        {
            recognizer = new KeywordRecognizer(keywords, ConfidenceLevel.Low);
            recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
            recognizer.Start();
        }
    }

    private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        word = args.text;
    }

    private void Update()
    {

        switch (word)
        {
            case "up":
                player.Move(0,1);
                Debug.Log("up");
                break;
            case "down":
                player.Move(0,-1);
                Debug.Log("down");
                break;
            case "left":
                player.Move(-1,0);
                Debug.Log("left");
                break;
            case "right":
                player.Move(1,0);
                Debug.Log("right");
                break;
        }
        word = "";
    }

    private void OnApplicationQuit()
    {
        if (recognizer != null && recognizer.IsRunning)
        {
            recognizer.OnPhraseRecognized -= Recognizer_OnPhraseRecognized;
            recognizer.Stop();
        }
    }
}
