## 23.04.2019.2

1. Форкнуть данный репозиторий.
2. Склонировать свою ветку к себе на десктоп.
3. Заполнить проекты Enumerable и Enumerable.Tests необходимой функциональностью.
4. Синхронизировать изменения с содержимым своего репозитория на gitub-e.
5. Сделать pull request к данному репозиторию.

## Постановка задания

[Done](https://github.com/mtsyvis/.NET-Training.-Spring-2019/blob/master/23.04.2019.2/PseudoEnumerable/Enumerable.cs)
- Как альтернативу классу [EnumerableExtension](https://github.com/AnzhelikaKravchuk/23.04.2019.1/blob/master/PseudoEnumerable/EnumerableExtension.cs) создать класс Enumerable, в который добавить следующие методы расширения интерфеса `IEnumerable<T>`:
  - методы для фильтрации и трансформации последовательности, использующие в качестве параметров соответсвующие версии типа делегат [`Func<T>`](https://docs.microsoft.com/en-us/dotnet/api/system.func-2?view=netframework-4.8);
  - метод SortBy, использующий стратегию сортировки по ключу (сортировка по возрастанию) (*не стратегию сравнения двух элементов!*);
  - метод SortBy, использующий стратегию сравнения двух ключей (сортировка по возрастанию);
  - метод CastTo, получающий на основе последовательности нетипизированных элементов типизированную последовательность, при этом в случае невозможности приведения хотя бы одного элемента в последовательности, выбрасывается исключение InvalidCastException;
  - метод ForAll, определяющий соответствие всех элементов последовательности заданному предикату;
  - **метод SortByDescending, использующий стратегию сортировки по ключу (сортировка по убыванию);**
  - **метод SortByDescending, использующий стратегию сравнения двух ключей (сортировка по убыванию);**
  - **метод-генератор последовательности count целых чисел, начиная с некоторого целочисленного значения start.**

[Done](https://github.com/mtsyvis/.NET-Training.-Spring-2019/blob/master/23.04.2019.2/PseudoEnumerable.Tests/EnumerableTests.cs)
- Проверить работу разработанных методов, используя различные типы данных.
