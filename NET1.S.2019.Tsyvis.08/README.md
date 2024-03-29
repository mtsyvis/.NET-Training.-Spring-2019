## Links
1. - [Task1 #1.dll](https://github.com/mtsyvis/.NET-Training.-Spring-2019/tree/master/NET1.S.2019.Tsyvis.08/NET1.S.2019.Tsyvis.08) 
   - [Task1 #2.dll Refactored GCD version 3](https://github.com/mtsyvis/.NET-Training.-Spring-2019/tree/master/NET1.S.2019.Tsyvis.08/GcdCalculationDecorator)
   - [GCDCalculatorTests](https://github.com/mtsyvis/.NET-Training.-Spring-2019/blob/master/NET1.S.2019.Tsyvis.08/NET1.S.2019.Tsyvis.08.Tests/GCDCalculatorTests.cs)

2. - [Task2 Corrected jugged array sort](https://github.com/mtsyvis/.NET-Training.-Spring-2019/tree/master/NET1.S.2019.Tsyvis.07/NET1.S.2019.Tsyvis.07/Sort%20jagged%20array)
   - [ArrayExtension Task2](https://github.com/mtsyvis/.NET-Training.-Spring-2019/blob/master/NET1.S.2019.Tsyvis.07/NET1.S.2019.Tsyvis.07/ArrayExtension.cs)

3. - [Task3](https://github.com/mtsyvis/.NET-Training.-Spring-2019/tree/master/NET1.S.2019.Tsyvis.08/BookService)
   - [BookListService](https://github.com/mtsyvis/.NET-Training.-Spring-2019/blob/master/NET1.S.2019.Tsyvis.08/BookService/Services/BookListService.cs)
   - [BookWebUI](https://github.com/mtsyvis/.NET-Training.-Spring-2019/tree/master/NET1.S.2019.Tsyvis.08/BookWebUI)

## Tasks

1. **(deadline - 05.04.2019, 24.00)**(*"3-ий перезапуск" НОД-а*) Есть унификация алгоритма нахождения НОД-а для двух целочисленных значений в виде интерфейса 

		 public interface IGcdAlgorithm
		 {
		     int Calculate(int first, int second);
		 }
		 
c реализацией в виде классов EuclideanGcdAlgorithm и BinaryGcdAlgorithm (доступ к коду классов для их измения не возможен, назовем эту сборку условно *#1.dll*). Предложить варианты расширения функциональности существующих (и новых) алгоритмов вычисления НОД-а, предлагающие возможность при вычислении определять показания времени работы алгоритма, рассмотреть возможность настройки алгоритма в контексте предоставления различных реализаций измерения времени.(Решения поместить в сборку *#2.dll*) 

2. **(deadline - 06.04.2019 24.00)** Добавить в статический класс ArrayExtension ([Day 7](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/tree/master/Day%207%20-%2002.04.2019)) метод расширения для сортировки непрямоугольного ("jagged") целочисленного массива (матрицы) таким образом, чтобы была возможность, в частности, упорядочить строки матрицы:
   - в порядке возрастания(убывания) сумм элементов ее строк;
   - в порядке возрастания(убывания) максимальных элементов ее строк;
   - в порядке возрастания(убывания) минимальных элементов ее строк.
   
   Разработать unit-тесты.

3. **(deadline - 07.04.2019 24.00)** 
- Разработать класс Book (ISBN, автор, название, издательство, год издания, количество страниц, цена), переопределив для него необходимые методы класса Object. Для объектов класса реализовать отношения эквивалентности и порядка (используя соответствующие интерфейсы). 

		public class Book : IEquatable<Book>, IComparable<Book>
		{
		    public string Author { get; set; }
		    public string Title { get; set; }
		    ...
		}
		
Для выполнения основных операций со набором книг, который можно загрузить (Load) и, если возникнет необходимость, сохранить (Save) в некоторое хранилище BookListStorage разработать класс BookListService (как сервис для работы с коллекцией книг) с функциональностью Add (добавить книгу, если такой книги нет, в противном случае выбросить исключение); Remove (удалить книгу, если она есть, в противном случае выбросить исключение); FindByTag (найти книги по заданному критерию); SortBy (отсортировать список книг по заданному критерию), при реализации делегаты не использовать! 
		
		public interface IBookListStorage
		{
		    IEnumerable<Book> Load();
		    void Save(IEnumerable<Book> books);
		}
		
- В качестве хранилища пока использовать FakeBookListStorage как обертку для списка книг, который хранится в памяти ("in memory dataset"). Данное хранилище пока используется для целей тестирования. В дальнейшем хранилище будет изменяться.
- **(deadline - 08.04.2019 24.00)** Продемонстрировать возможности работы с системой типов в ASP.NET MVC приложении.
   
