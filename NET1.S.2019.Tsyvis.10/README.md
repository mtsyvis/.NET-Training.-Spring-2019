## Links
1. - [Generic refactoring](https://github.com/mtsyvis/.NET-Training.-Spring-2019/tree/master/NET1.S.2019.Tsyvis.07/NET1.S.2019.Tsyvis.07)
2. - [Transform string to number in the desired number system](https://github.com/mtsyvis/.NET-Training.-Spring-2019/blob/master/NET1.S.2019.Tsyvis.07/NET1.S.2019.Tsyvis.07/Transform/TransformRules/TransformStringToNumberRule.cs)
  - [NumeralSystem class](https://github.com/mtsyvis/.NET-Training.-Spring-2019/blob/master/NET1.S.2019.Tsyvis.07/NET1.S.2019.Tsyvis.07/Transform/NumeralSystem.cs)
  - [Tests](https://github.com/mtsyvis/.NET-Training.-Spring-2019/blob/master/NET1.S.2019.Tsyvis.07/NET1.S.2019.Tsyvis.07.Tests/ArrayExtensionTests.cs)

## Читать
- C# in Depth. Jon Skeet. Manning Publications Co. 2013. Chapter 14. Dynamic binding in a static language.

## Tasks

- Переобразовать методы расширения класса ArrayExtension [Day 7](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/tree/master/Day%207%20-%2002.04.2019) в обобщенно-типизированные методы
      
      public static TSource[] Filter(this TSource[] source, IPredicate<TSource> predicate) { }
      
      public static TResult[] Transform(this TSource[] source, ITransformer<TSource, TResult> transformer) { }
      
      public static TSource[] SortBy(this TSource[] source, IComparer<TSource> comparer) { } 
  
- Проверить работу полученных методов, используя в качестве тест-кейсов постановки задач из [Day 7](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/tree/master/Day%207%20-%2002.04.2019)
- Набор целочисленных зачений представлен массивом строк, каждая из которых является представлением соответствующего целого числа в p-ичной (2<=p<=16) системе счисления. Получить набор целочисленных значений.
