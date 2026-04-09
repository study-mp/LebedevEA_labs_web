# Lab 8 — Ручные действия

Все файлы уже созданы. Ниже — команды, которые нужно выполнить вручную
в Visual Studio (Package Manager Console — PMC) или в PowerShell / CMD
из папки проекта `ContosoUniversity` (там, где лежит `ContosoUniversity.csproj`).

## 1. Установить `dotnet-ef` (один раз на машину)

В обычной консоли:

```
dotnet tool install --global dotnet-ef
```

Если уже установлен — обновить:

```
dotnet tool update --global dotnet-ef
```

## 2. Восстановить NuGet-пакеты и собрать проект

```
dotnet restore
dotnet build
```

## 3. Часть 4 — первая миграция (InitialCreate)

Из папки `ContosoUniversity` выполнить:

```
dotnet ef migrations add InitialCreate
dotnet ef database update
```

Запустить `dotnet run` и открыть `https://localhost:<порт>/Students` —
должен сработать `DbInitializer` и данные появятся.

## 4. Часть 5 — миграция усложнённой модели (ComplexDataModel)

После того как добавлены `Instructor`, `Department`, `OfficeAssignment`,
`CourseAssignment` и `Course.DepartmentID` — создать новую миграцию.
Т. к. структура БД меняется радикально, проще всего дропнуть БД:

```
dotnet ef database drop -f
dotnet ef migrations add ComplexDataModel
dotnet ef database update
```

## 5. Часть 8 — миграция ConcurrencyToken

После добавления свойства `ConcurrencyToken` в `Department`:

```
dotnet ef migrations add ConcurrencyToken
dotnet ef database update
```

## 6. Часть 9 — миграция наследования (Inheritance)

После рефакторинга `Student`/`Instructor` от базового `Person`:

```
dotnet ef migrations add Inheritance
dotnet ef database update
```

Если миграция падает из-за существующих данных (EF не сможет
автоматически смерджить таблицы `Student` и `Instructor` в `Person`),
проще дропнуть БД и пересоздать — `DbInitializer` заполнит её заново:

```
dotnet ef database drop -f
dotnet ef database update
```

## 7. Запуск приложения

```
dotnet run
```

или из Visual Studio — `F5`.

## Скриншоты для отчёта (рекомендуется)

Сохранять в `results/Lab8/`:

1. Главная страница (Home) — "Contoso University"
2. Home/About — Student Body Statistics (группировка по дате зачисления)
3. Students/Index — сортировка по фамилии
4. Students/Index — фильтрация по имени ("al")
5. Students/Index — пагинация (Previous / Next)
6. Students/Details — с таблицей Enrollments и оценками
7. Students/Create — добавление студента
8. Students/Edit — редактирование
9. Students/Delete — удаление
10. Courses/Index — список курсов с Department
11. Instructors/Index — преподаватели, Select → Courses Taught
12. Instructors/Index — Select course → Students Enrolled
13. Instructors/Edit — чекбоксы курсов (assigned)
14. Departments/Index — список департаментов
15. Departments/Edit — параллельное редактирование (2 вкладки → конфликт concurrency)
16. Departments/Delete — concurrency при удалении
17. SQL Server Object Explorer — таблица `Person` с колонкой-дискриминатором
