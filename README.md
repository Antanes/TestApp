Проект выполнен в програмной среде Visual Studio 2022 Community с использованием чистой архитектуры, Dependency Injection, библиотеки Automapper, паттерна CQRS и библиотеки MediatR (паттерн Посредник). 
В проекте присутствуют три основных уровня Core, Infrastructure, Presentation. Core содержит в себе два подуровня Domain и Application. Domain содержит Enterprice-логику, а Application бизнес-логику. Infrastructure содержит всё, что относится к взаимодействию с БД. Presentation - уровень представления, стандартный MVC проект. Presentation и Infrastructure зависят от Core, а Core не содержит прямых зависимостей, а только через интерфейсы и абстракции.

Слой Domain хранит в себе классы сущностей Drink, Coin и Machine. Все последующие слои будут хранить ссылку на слой Domain, но сам Domain ничего не знает о других слоях.

Слой Application:

-Содержит всю логику запросов получения, создания, редактирования сущностей (сценарии использования)

-Хранит ссылку на слой Domain

-Содержит интерфейс IDrinksDbContext, который реализуется в Persistence слое, т.е. интерфейс - это часть приложения, а реализация - во вне

-В папке Common содержится generic интерфейс IMapWith с реализацией по умолчанию. Класс AssemblyMappingProfile применяет маппинг из сборки при помощи метода ApplyMappingsFromAssembly, он сканирует сборку и ищет любые типы, которые реализуют интерфейс IMapWith

-Содержит Feature папки Drinks, Coins, Machines в которых содержатся запросы и команды над данными сущностями

-Классы команд реализуют generic интерфейс IRequest из библиотеки MediatR и помечают результат выполнения данной команды и возвращают результат определенного типа, а также содержат необходимую информацию для выполнения команды. Классы обработчиков команд реализуют интерфейс IRequestHandler с типом запроса и ответа и на основе информации из класса команды содержат логику выполнения команды, которая содержится в методе Handle. Также обработчик использует внедрение зависимости на контекст БД через конструктор для сохранения изменений в БД

-Папка запроса содержит View модель, класс который описывает, что будет возвращаться пользователю при запросе. А также в папке содержится класс сзапроса и обработчика запроса.

Слой Persistence содержит папку EntityTypeConfigurations, в ней содержится все что относится к конфигурации сущностей. Она содержит классы, реализующие интерфейс IEntityTypeConfiguration из пространства имен Microsoft.EntityFrameworkCore. Такой подход позволяет разделять конфигурации сущностей на отдельный классы, а не в методе OnModelCreating, а также достигается концептуальное разделение.  Класс DrinksDbContext реализает интерфейс IDrinksDbContext, а также наследующийся от класса DbContext из Microsoft.EntityFrameworkCore. Мы не используем паттерн Репозиторий и UnitOfWork. DbContext работает как UnitOfWork, DbSet как репозиторий. Класс DbInitializer содержит один метод Initialize, который при старте приложения проверяет создана ли БД, а если нет, то она будет создана на основе DrinksDbContext.

В папке Views содержатся представления страницы пользователя и администратора, а также частичные представления создания/изменения и удаления напитка. Для входа на страницу администратора нужно передать переменной p значение 123456 в адресной строке.

Файл параметр appsettings.json, в котором указывается строка подключения к файлу базы данных. Класс Program - главный файл приложения, с которого и начинается его выполнение. Код этого файла настраивает и запускает веб-приложение. Папка wwwroot содержит подключаемые библиотеки bootstrap, jquery, изображения и т.д. Папка App_Data содержит в себе файл базы данных Slots.mdf.

В Program.cs нужно прописать свой путь к файлу базы данных.
