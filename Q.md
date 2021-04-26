# I

### Wie kann man auf die Unity Datenbanken zugreifen?

1. https://docs.unity3d.com/Manual/AssetDatabase.html
2. https://docs.unity3d.com/ScriptReference/AssetDatabase.html

### Wie kann man ein Objekt so programmieren, dass die Spielfigur dieses Objekt (einen Handspiegel) in die Hand nehmen kann?

Spiegel ist schon immer in der Hand (Child-Objekt von Spielfigur), aber zu beginn deaktiviert.
Wenn Spielfigur zu Objekt in der Welt geht (in einen Trigger, bei Input, etc.), Objekt in der Welt deaktivieren und Objekt in der Hand aktivieren. `GameObject.SetActive(True/False)`

# II

### Gibt es eine Möglichkeit grosse reflektierende Spiegel-Würfel (mit reflection Probe) genauer zu machen? Momentan wirkt es mehr wie eine Kamera wenn man gegen den Würfel läuft trifft man nicht auf sich selbst im 'Bild' wie in einem echten Spiegel sondern sieht sich von oben. Oder ist dies nicht auf irgendeine Art veränderbar.

Reflection Probes produzieren immer etwas merkwürdige Effekte. Was etwas helfen kann:

1. Reflection Probe auf Höhe der Kamera platzieren.
2. Bei der Reflection Probe "Box Projection" ausprobieren.

### Wir haben Blöcke die leicht hoch und runter schweben (die Bewegung ist im deltaTime loop) und sie bewegen sich flüssig. Wenn man jedoch auf dem block steht wackelt die Kamera. Liegt das Problem im update vom collider des players, also müsste man das player script abändern?

Das Problem könnte an einigen Sachen liegen. Meine Empfehlung: Einen anderen Controller ausprobieren 😅. Folgend ein paar:

1. First Person All-In-One (gratis): https://assetstore.unity.com/packages/tools/input-management/first-person-all-in-one-135316
2. Kinematic Character controller ($30): https://assetstore.unity.com/packages/tools/physics/kinematic-character-controller-99131

### Wenn man oft gegen einen collider springt wird man über die Welt teleportiert oder an den Start des levels.

Konnte ich nicht reproduzieren -- Sorry!
Hoffentlich verschwindet das Problem mit einem neuen Controller.

# III

### Ist es möglich eine Lichtquelle selber sichtbar zu machen? Sodass man beispielsweise ein Point Light als fliegende helle Kugel sehen würde?

Drei Ansätze:

1. Bei Licht "Draw Halo" einschalten.
2. Dem Lichtobjekt eine Kugel mit hellem Material unterordnen. (Für helles Material mit "Emission" arbeiten, evtl. mit Transparenz und/oder Texturen spielen!)
3. Post-Processing könnte cool sein: https://docs.unity3d.com/Packages/com.unity.postprocessing@3.1/manual/index.html
