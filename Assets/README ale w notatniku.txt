Czas wykonania około: 8h
Zadanie było robione praktycznie w całoście 4 maja, wcześniej byłem poza domem bez możliwości pisania kodu.
Ciekawsze elementy i rozwiązania w projekcie:
⦁	Object Pooling dla pojawiających się przeszkód w celu usprawnienia wydajności,
⦁	Użycie korutyny do spawnowania przeszkód zamiast zwykłej funkcji update, która jest wolniejsza,
⦁	Implementacja New Input Systemu pozwala dodać funkcjonalność dla innych form obsługi typu kontroler lub ekran dotykowy,
⦁	Poruszanie postacią polega na wychyleniu myszki od środka ekranu, im większe odchylenie tym większa szybkość
⦁	AudioManager to singleton, chociaż niektórzy pewnie by powiedzieli że to zdrodnia przeciwko ludzkości. Według mnie do tego się akurat nadają singletony.

Miejsca w których projekt odstaje, ze względu na brak czasu:
⦁	Klasa Obstacles powinna się nazywać inaczej, ale nie mam pomysłu na słowo obejmujące przeszkody i powerupy na raz
⦁	Despawnowanie przeszkód możnaby zrobić lepiej niż ściana poza ekranem o którą się rozbiają, na przykład sprawdzanie czy są widoczne 
⦁	Generalnie wszystkie wartości zmiennych do których są suwaki pokroju szybkości przewijania tła lub prędkości przeszkód zostały ustalone na szybko i wymagałyby dostosowania
⦁	Obiekt tarczy do podniesienia nie ma swoje poola i jest wrzucony trochę "na sztywno". Przy obecnym założeniu, że power up jest tylko jednego typu i nie pojawia się w ilości większej niż jeden na ekranie nie ma to większego znaczenia. Przy większej ilości powerupów pewnie należałoby zrobić pool'a tak samo jak z przeszkodami.
⦁	Brak usystematyzowanych zależność z użyciem zenjecta

Muzyka: https://opengameart.org/users/trinnox

