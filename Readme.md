### Предусловия
- есть множество банковских счетов
- каждый счёт представлен отдельным внешним сервисом
- внешний сервис доступен по http
- внешний сервис предоставляет метод по списанию/зачислению денежных средств на счёт
- любой запрос к внешнему сервису может упасть с некоторой вероятностью из-за сетевой ошибки
- любой запрос к внешнему сервису может упасть с некоторой вероятностью из-за недоступности сервиса
- запрос на списание денежных средств может упасть с некоторой вероятностью из-за недостатка средств на счёте
- запрос к внешнему сервису может упасть из-за того что не найден счёт

### Задача
Создать web-приложение предоставляющее http api для осуществления денежных переводов между банковскими счетами. Приложение должно гарантировать, что в конечном итоге сохраняется баланс средств между счетами, т.е. деньги не должны появляться ниоткуда и пропадать никуда.

### Артефакты
- заготовка приложения ([TransferApp.sln](https://github.com/grimtod/TransferApp))
- заготовка контроллера ([TransfersController](https://github.com/grimtod/TransferApp/blob/master/TransferApp/Controllers/TransfersController.cs))
- мок имитирующий работу внешнего сервиса ([BankClientMock](https://github.com/grimtod/TransferApp/blob/master/TransferApp/Services/BankClientMock.cs))

### Условия
- фреймворк - ASP.NET Core 3.1 или ASP.NET Core 6
- СУБД (если понадобится) - MS SQL Server или PostgreSQL
- изменять поведение BankClientMock нельзя
