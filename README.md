# DOKUMENTACJA GRY QUIZ
Projekt ten jest realizowany przez Dawid Malca i Krystiana Smolenia.<br>
## Jak włączyć projekt?
Należy sklonować grę(git clone), następnie uruchomić projekt w środowisku Visual Studio.<br>
## WAŻNE!!!
**Projekt korzysta z zewnętrznych bibliotek, należy je pobrać za pomocą NuGet.**
### Jak to zrobić? 

Po sklonowaniu repozytorium należy kliknąć prawym przyciskiem myszy na '**Solution**' i wybrać opcje '**Restore NuGet packages**'. Po wykonaniu tej czynności należy ponownie kliknąć prawym przyciskiem myszy na '**Solution**' i wybrać opcje "**Manage NuGet Packages for Solution**". Po wybraniu tej opcji wyświetli się okno z pakietami, należy je dodać do projektu zaznaczając checkboxa w okienku..

## Aspekty techniczne:
### Formularze
Projekt jest tworzony z użyciem Windows Forms(WinForms). Posiada dwa formularze(okienka).  
#### Formularz 1:
Odpowiedzialny jest za :
- Pobranie nazwy gracza
- Wyświetlenie menu
- Pokazanie okna(GroupBox) z grą
<br>
**Pola**:
- AnswerButtons – przechowuje przyciski odpowiedzi
- QuizGame – obiekt pozwalający nam rozpocząć gre
- secondForm – formularz odpowiedzialny za ranking
<br>
**Metody**:
- Button_Start_Game_Click – włącz grę
- Form1 – konstruktor w którym inicjujemy komponent i dodajemy przyciski do listy AnsweButtons
- Button_Ranking_Click – pokazuje ranking
- Button_Quit_Click – wyłącza grę
- Button_Question_Click – ta metoda jest używana przy wciśnięciu przycisku z odpowiedzią w celu sprawdzenia poprawności odpowiedzi.

#### Formularz 2:
Odpowiedzialny jest za ranking.<br>
**Pola**:
- Leaderboard – obiekt klasy połączenia z baza danych
- addedRank – zmienna sprawdza czy ranking został już dodany
<br>
**Metody**:
- Form2_Load – odpowiedzialny za załadowanie z bazy rankingu do obiektu ListView.

####Baza
 Do projektu jest podpięta baza danych typu SQLite, która dostarcza pytania do aplikacji, jak i również przechowuje wyniki graczy w celu wyświetlenia ich w rankingu. Baza posiada 3 tabele:
- Answers
- Questions
- Leaderboard
<br>
Tabela Questions jest połączona relacją z tabelą Answers jeden do wielu(1..n). Tabela Leaderboard jest niezależna i służy tylko do przechowywania rankingu graczy.
Schemat bazy przedstawiony jest na rysunku pod tym [linkiem](https://imgur.com/a/5Wqv5GO)

Do komunikowania się z baza została stworzona klasa ‘Database’. Która zawiera **metody**:<br>
- Database – konstruktor domyślny który inicjuje połączenie z bazą
- OpenConnection – otwiera połączenie z bazą
- CloseConnection – zamyka połączenie z bazą
- GetRandomQuestion – pobiera losowe pytanie z bazy
- GetQuestion – pobiera pytanie z bazy
- GetAnswers – pobiera odpowiedzi z bazy
- DisplayLeaderboard – wyświetla ranking
- AddToLeaderboard – dodaje gracza do rankingu

## Klasa – główna logika gry
Główna logika gry została umieszczona w klasie o nazwie QuizGame. <br>
Zawiera ona prywatne **pola** takie jak: 
- Name – nazwa gracza
- Score – punkty gracza
- counterQuestions – licznik pytan
- quizDatabase – obiekt klasy bazy, który umożliwi nam łączenie się z naszą bazą.
<br>
**Opis metod**:
- getName, setName -umożliwia pobranie i ustawienie nazwy gracza
- setAnswers – umieszcza pytania w przyciskach w formularzu 1
- KoniecGry – funkcja, odpowiedzialna za skończenie gry i pokazanie graczowi jego wynik punktowy i również dodanie go do rankingu.
- CheckAnswer – funkcja sprawdza poprawność odpowiedzi gracza
- Play – najważniejsza metoda odpowiedzialna za grę, w niej otwieramy połączenie z baza danych i wypełniamy nasz formularz pytaniami jak i również sprawdzamy czy gra powinna się skończyć.

## Użyte pakiety zewnętrzne
Do realizacji bazy danych zostały użyte takie **pakiety** jak:
- Dapper 
- System.Data.SQLite
- System.Data.SQLite.Core

## ENJOY

