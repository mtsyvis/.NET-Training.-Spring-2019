## Links

2. [Book](https://github.com/mtsyvis/.NET-Training.-Spring-2019/blob/master/NET1.S.2019.Tsyvis.19/Book.cs)

3. - [BookFormatProviderTest](https://github.com/mtsyvis/.NET-Training.-Spring-2019/blob/master/NET1.S.2019.Tsyvis.19/NET1.S.2019.Tsyvis.19.Tests/BookFormatProviderTest.cs)
   - [Tests](https://github.com/mtsyvis/.NET-Training.-Spring-2019/blob/master/NET1.S.2019.Tsyvis.19/NET1.S.2019.Tsyvis.19.Tests/BookTests.cs)
   
4. - [BinaryRepresentationFormatProvider](https://github.com/mtsyvis/.NET-Training.-Spring-2019/blob/master/NET1.S.2019.Tsyvis.04/NET1.S.2019.Tsyvis.04/BinaryRepresentationFormatProvider.cs)
   - [Tests](https://github.com/mtsyvis/.NET-Training.-Spring-2019/blob/master/NET1.S.2019.Tsyvis.04/NET1.S.2019.Tsyvis.04.Tests/BinaryRepresentationFormatProviderTests.cs)

## Задания

2. **(deadline - 03.04.2019, 24.00)** Для объектов класса Book, у которого есть свойства Title, Author, Year, PublishingHous, Edition, Pages и Price (за основу можно взять класс, разработанный ранее) реализовать
возможность строкового представления различного вида. Например, для объекта со значениями
    Title = "C# in Depth", 
    Author = "Jon Skeet", 
    Year = 2019, 
    PublishingHous = "Manning", 
    Edition = 4, 
    Pages = 900, 
    Price = 40$.
могут быть следующие варианты:
 - Book record: Jon Skeet, C# in Depth, 2019, "Manning", 
 - Book record: Jon Skeet, C# in Depth, 2019
 - Book record: Jon Skeet, C# in Depth
 - Book record: C# in Depth, 2019, "Manning"
 - Book record: C# in Depth и т.д.
 
Разработать модульные тесты.

3. **(deadline - 03.04.2019, 24.00)** Не изменяя класс Book, добавить для объектов данного класса дополнительную (любую не существующую у класса изначально) возможность 
форматирования, не предусмотренную классом. Разработать модульные тесты.

4. **(deadline - 02.04.2019, 24.00)** Представить решение задачи [Day 4 - 26.03.2019. Task 3](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/tree/master/Day%204%20-%2026.03.2019) в виде дополнительной возможности форматного вывода вещественного числа. Разработать модульные тесты.
