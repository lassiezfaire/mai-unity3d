# The Shooter With No Name

Ретро-шутер от первого лица с визуальным стилем и звуковым сопровождением, отсылающими к видеоигре The Town With No Name (Commodore CDTV, 1992)

 - Платформы: Windows, скачать: https://drive.google.com/file/d/1EVXDrd8EdZaeEAvYzdJupYp6aZ9CK1IA/view?usp=sharing

# GDD

### Концепия

Шутер от третьего лица в стилистике начала 90-х (DOOM, Heretic, Hexen) и отсылками к широко известной в узких кругах видеоигре The Town With No Name, проявляющимися в характерных UI, дизайне окружения, врагов и звукового сопровождения.

### Визуальный стиль
- [x] Единственно возможное разрешение экрана: 640 x 240 (как у консоли, для которой была разработана The Town With No Name)
- [ ] Сеттинг: небольшой городок на Диком Западе (конец 19 в.)
- [x] Low-poly окружение и спрайтовые враги в стиле оригинальной игры
- [ ] Интерфейс основан на оригинальной игре и копирует её решения (дизайн кнопок и "иммерсивность")
![игра имеет характерный для ранних трёхмерных игр стиль](https://i.ytimg.com/vi/WeV18bZGMqc/maxresdefault.jpg)

### Жизненный цикл
- [x] Появление на уровне с полным здоровьем и базовым оружием
- [x] Исследование уровня с целью поиска ключа для перехода на следующий уровень
- [x] Исследованию мешают враги
- [x] Каждый точный выстрел снимает долю здоровья
- [x] После смерти уровень начинается сначала
- [x] Помимо ключа, на уровне можно найти лучшее оружие, патроны и аптечки
- [x] Победа засчитывает, если игрок нашёл ключ и прошёл на следующий уровень
- [x] Поражение засчитывается, если игрок умер три раза 
![примерный вид шутера тех лет](https://playminigames.net/content/gameimagecontent/heretic_golems_aeb6cc3c-db88-4b42-bf97-1e86bfbe3f88.png)

### Основные механики
- [x] ИИ врагов - перемещаются по карте, увидев / услышав игрока открывают стрельбу по нему
- [x] Сбор предметов - игрок может подбирать квестовые предметы (ключи), а также оружие, патроны и аптечки

### Дополнительные механики
- [ ] Главный герой комментирует некоторые найденные на уровне объекты
- [ ] Катсцены

### Juice-механики
- [ ] Ремиксы на OST из оригинальной игры (если найду способ сделать их быстро)