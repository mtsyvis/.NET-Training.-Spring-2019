## 23.04.2019.1

1. Форкнуть данный репозиторий.
2. Склонировать свою ветку к себе на десктоп.
3. Заполнить проекты EnumerableExtension и EnumerableExtension.Tests необходимой функциональностью.
4. Синхронизировать изменения с содержимым своего репозитория на gitub-e.
5. Сделать pull request к данному репозиторию.

## Постановка задания

[Done](https://github.com/mtsyvis/.NET-Training.-Spring-2019/tree/master/23.04.2019.1/PseudoEnumerable)
- Добавить в класс ArrayExtension (класс переименовать в EnumerableExtension) [Day 13 (Day 10)](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/tree/master/Day%2013%20-%2016.04.2019) перегруженные версии обобщенно-типизированных методов расширений типизированного интерфейса `IEnumerable<T>`, используя в качестве передаваемых параметов (стратегий фильтрации, трансформации, сравнения) соответствующие делегаты 
  - [`Predicate<T>`](https://docs.microsoft.com/en-us/dotnet/api/system.predicate-1?view=netframework-4.8) 
  - [`Converter<TInput,TOutput>`](https://docs.microsoft.com/en-us/dotnet/api/system.converter-2?view=netframework-4.8)
  - [`Comparison<T>`](https://docs.microsoft.com/en-us/dotnet/api/system.comparison-1?view=netframework-4.8)

[Done](https://github.com/mtsyvis/.NET-Training.-Spring-2019/blob/master/23.04.2019.1/PseudoEnumerable/EnumerableExtension.cs)
- При реализации "методов-двойников" использовать:
    - для методов (Filter, SortBy) с параметрами делегатами вызовы методов с параметром интерфейсом;
    - для метода (Transform) с параметром интерфейсом вызов метода с параметром делегатом.
    
[Done](https://github.com/mtsyvis/.NET-Training.-Spring-2019/blob/master/23.04.2019.1/PseudoEnumerable.Tests/EnumerableExtensionTests.cs)
- Проверить работу разработанных методов, используя различные типы данных.
