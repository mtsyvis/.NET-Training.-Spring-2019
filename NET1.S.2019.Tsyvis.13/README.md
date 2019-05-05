## Links

1. [ArrayExtensions](https://github.com/mtsyvis/.NET-Training.-Spring-2019/blob/master/NET1.S.2019.Tsyvis.07/NET1.S.2019.Tsyvis.07/ArrayExtension.cs)

2. - [BinarySearchTree](https://github.com/mtsyvis/.NET-Training.-Spring-2019/blob/master/NET1.S.2019.Tsyvis.13/ClassLibrary1/BinarySearchTree.cs)
   - [Tests](https://github.com/mtsyvis/.NET-Training.-Spring-2019/blob/master/NET1.S.2019.Tsyvis.13/NET1.S.2019.Tsyvis.13.Tests/BinarySearchTreeTests.cs)

3. [Collection table](https://docs.google.com/spreadsheets/d/1h2ZD5aAjgU053PbNcvxaUc1CcafBrsfsRuoOBZzBOdI/edit?usp=sharing)

## Задачи

1. (deadline - 20.04.2019, 24.00) Переобразовать методы класса ArrayExtension [Day 10](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/tree/master/Day%2010%20-%2009.04.2019) в обобщенно-типизированные методы расширений типизированного интерфейса `IEnumerable<T>`
      
            public static IEnumerable<TSource> Filter<TSource>(this IEnumerable<TSource> source, IPredicate<TSource> predicate) { }
            
            public static IEnumerable<TResult> Transform<TSource,TResult>(this IEnumerable<TSource>, ITransformer<TSource, TResult> transformer) { }
            
            public static IEnumerable<TSource> SortBy<TSource>(this IEnumerable<TSource>, IComparer<TSource> comparer) { }`
  
2. (deadline - 21.04.2019, 24.00) Разработать обобщенный класс-коллекцию BinarySearchTree (бинарное дерево поиска). Предусмотреть возможности использования подключаемого интерфейса для реализации отношения порядка. Реализовать три способа обхода дерева: прямой (preorder), поперечный (inorder), обратный (postorder): для реализации обходов использовать блок-итератор (yield). Протестировать разработанный класс, используя следующие типы:
  - System.Int32 (использовать сравнение по умолчанию и подключаемый компаратор);
  - System.String (использовать сравнение по умолчанию и подключаемый компаратор);
  - пользовательский класс Book, для объектов которого реализовано отношения порядка (использовать сравнение по умолчанию и подключаемый компаратор);
  - пользовательскую структуру Point, для объектов которого не реализовано отношения порядка (использовать подключаемый компаратор).
3. (deadline - 23.04.2019, 24.00) Заполните таблицу
