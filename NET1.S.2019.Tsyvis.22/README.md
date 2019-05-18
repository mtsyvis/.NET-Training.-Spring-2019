## Links
[ConsoleApp](https://github.com/mtsyvis/.NET-Training.-Spring-2019/blob/master/NET1.S.2019.Tsyvis.22/ConsoleApp/Program.cs)

[UriToXmlExportService (main class)](https://github.com/mtsyvis/.NET-Training.-Spring-
2019/blob/master/NET1.S.2019.Tsyvis.22/BLL/UriToXmlExportService.cs)

[Tests])(https://github.com/mtsyvis/.NET-Training.-Spring-2019/blob/master/NET1.S.2019.Tsyvis.22/BLL.Tests/UriToXmlExportServiceTests.cs)

## Задачи (deadline -)
  В текстовом файле построчно хранится информация об URL-адресах, представленных в виде
  
  ![Scheme](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/Scheme.png)

где сегмент parameters - это набор пар вида key=value, при этом сегменты URL‐path и parameters  или сегмент parameters могут отсутствовать. 
Разработать (в соответствии в принципами SOLID) систему типов для экспорта данных, полученных на основе разбора информации текстового файла в XML-документ по следующему правилу, например, для текстового файла с URL-адресами 
 
  - https://github.com/AnzhelikaKravchuk?tab=repositories 
  - https://github.com/AnzhelikaKravchuk/2017-2018.MMF.BSU
  - https://habrahabr.ru/company/it-grad/blog/341486/      

результирующим является XML-документ вида (можно использовать любую XML технологию без ограничений).

![XML-результат](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/XML.Task.png)

Для тех URL-адресов, которые не совпадают с указанным паттерном, залогировать информацию (предусмотреть возможность замены лог-фреймворка, в качестве дефолтного использовать NLog), отметив указанные строки, как необработанные. Для работы с URL можно использовать [Uri Class](https://msdn.microsoft.com/ru-ru/library/system.uri(v=vs.110).aspx).
  
Продемонстрировать работу на примере консольного приложения. 

При реализации solution-а для организации проектов использовать Stairway-паттерн.

Для разрешения зависимостей использовать Ninject. 

Для тетирования основой функциональности использовать NUnit и Moq фреймворки.

При реализации системы типов учитывать возможность их использования в случае, когда в исходном текстовом файле информация об URL-адресах изменится на другую, иерархически представимую информацию.
