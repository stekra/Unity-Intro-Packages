# Q&A


## Wie können wir ein 3D-Modell/File in Unity importieren?

3D Modell File (z.B. .fbx File) in den Project tab in Unity ziehen. Das importierte 3D Modell durch Drag and Drop vom Project Tab in die Szene oder Hierarchie ziehen, um es in der Szene zu haben.


## Wie kann man einstellen, dass die Kamera Postion während dem Spiel wechselt?

Eine einfache Methode ist, mehrere Kameras zu platzieren, und sie dann z.B. via `OnTriggerEnter` jeweils zu aktivieren/deaktivieren. Siehe das beigelegte Script `ActivateDeactivate.cs`.


## Was gibt es für Möglichkeiten, den Übergang von verschieden Kamera Positionen darzustellen? (Im Vergleich wie Filmschnitt)

Grundsätzlich alles möglich. Für etwas relativ simples vielleicht in die [Animationstools von Unity](https://learn.unity.com/tutorial/working-with-animations-and-animation-curves) reinschauen? Z.B. für ein Überblendungs-Effekt: https://www.youtube.com/watch?v=xeXW4RxlWmw


## Wie kann man kann man einen Umkreis-Trigger erstellen? (Wenn man einen Umkreis von einem Objekt betritt, dass sich die Kamera Position verändert)

Einem Objekt ein Collider anhängen (z.B. Sphere Collider, Box Collider, Mesh Collider, …) und nach belieben transformieren. Beim Collider "Is Trigger" aktivieren, um es für die Physik durchlässig zu machen. Ein Skript dem Objekt anhängen. Im Skript innerhalb der `OnTriggerEnter` Funktion gewünschtes Verhalten einfügen.

```c#
OnTriggerEnter(Collider other)
{
   //Verhalten hier drin wird jedes Mal beim betreten des Triggers ausgeführt
}
```

---

## In diesem Moment würden wir gerne ein Fenster, oder ähnliches erscheinen lassen und den Spieler fragen, um welches Gebäude es sich handelt. Eine Art Antwortbox in die man hinein läuft, welche einen Screenchange oder ein zusätzliches Fenster auslöst.

Unity UI's Input Field recherchieren (Sample Code unten). Das UI dann z.B. mit `ActivateDeactivate.cs` erscheinen lassen oder mit `ChangeSceneOnTrigger.cs` in eine Szene mit nur UI wechseln.

```c#
using UnityEngine.UI
```
```c#
public InputField inputField;
public string solution;

void Update()
{
   if (inputField.text == solution)
   {
      Debug.Log("Correct!");
   }
}
```


## Zusätzlich wäre noch die Frage, ob man den Startpunkt nach einem Zufallsprinzip gestalten könnte, sodass der Startpunkt des Spielers bei jeder Wiederholung anders ist.

Z.B. Viele Player-Objekte platzieren und bei Start einen zufälligen davon aktivieren, die anderen deaktivieren.

```c#
public GameObject[] listOfObjects;

void Start()
{
   int randomChoice = Random.Range(0, listOfObjects.Length);

   for (int i = 0; i < listOfObjects.Length; i++)
   {
      if (i == randomChoice)
      {
         listOfObjects[i].SetActive(true);
      }
      else
      {
         listOfObjects[i].SetActive(false);
      }
   }
}
```


---

## Ich habe das Skript und ich habe das Objekt auf Unity; wie wende ich das Skript an?

Das Skript via Drag and Drop oder via `Add Component` > Scripts > XYZ dem Objekt hinzufügen.  
Code innerhalb von `Start` wird einmal zu Beginn des Spiels ausgeführt.  
Code innerhalb von `Update` wird jeden Frame ausgeführt.  
Code innerhalb von `OnTriggerEnter` wird jedes Mal beim betreten eines Triggers auf dem Objekt ausgeführt.


## Wie importiere ich die gleichen Texturen in Unity, die ich in Blender verwendet habe?

Die Textur-Bilddatei in Unity importieren. Neues Material kreieren, dem Material die Textur als (z.B.) "Base Map" hinzufügen (kleines Quadrat links von "Base Map"). Material dem Objekt zuweisen.  
UV Texturkoordinaten sollten mit dem importierten Modell erhalten geblieben sein. Dementsprechend sollte die Textur korrekt/gleich wie in Blender aussehen.


## Wie kann man ein Unity file mit anderen Menschen verteilen ? (ich habe plötzlich eine ganze Reihe von Problemen, wenn ich zB der ganze UnityGame Folder auf Google Drive hochlade).

Den ganzen Projektordner zu teilen sollte funktionieren. Wird schnell gross, daher empfehlenswert, den "Library" Ordner auszulassen. Die einzigen wirklich notwendigen Ordner sind "Assets", "Packages" und "Project Settings", aber viele andere enthalten praktische Einstellungen. Auch empfehlenswert: Projektordner komprimieren vor dem Hochladen auf einen Server (in macOS via Rechtsclick > Compress, Windows via 7-Zip o.Ä.).
