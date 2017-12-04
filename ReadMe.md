Технологии: OAuth, OData, Identity, Unity, EntityFramework.

Особые Требования: SqlExpress.

* Mikolaitis.Api.Authorization - Сервер Авторизации
* Mikolaitis.Api.Users - Сервер Данных пользователей
* Mikolaitis.Api.Core - Ядро
* Mikolaitis.Api.Database - Code First Entity Framework база данных


База данных после инициализации будет заполнена пользователями.
Список пользователей и их пароль: Mikolaitis.Api.Database.Migrations.AddUsers
Пароли шифруются функцией формирования ключа.

В файле MyRequests.PostmanCollection.json находится коллекция из трех запросов для PostMan(Можно импортировать и быстро проверить апи на работоспособность). Порты могут отличаться.

Регистрируемся

http://localhost:56774/api/account/registeruser

Авторизируемся

http://localhost:56774/token

Получаем список пользователей

http://localhost:56983/Users?$orderby=UserName&$skip=20



Комментарий от себя: 

Web Api, OData, Identity, Unity пользуюсь первый раз.
Большую часть времени занимался изучением этих технологий.
Читал Документацию, StackOverflow, Блоги разработчиков.
Прошелся по большому кол-ву граблей :).
В общей сложности потратил 20 часов на выполнение задания. 

В конце концов доволен приобритенными знаниями!