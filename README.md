# Zombieland-map-editor


## Правила импорта папок и спрайтов
-   Для UnityEditor спрайты кидать в папку ```Resources/свое_название_папки```, тайлы в папку ```Tiles```.
-   Для билда спрайты кадать в ```ZombielandMapEditor_Data\Resources```, тайлы в папку ```Tiles```.
-   Папок может быть сколько угодно, а в каждой папке может находиться произвольное количество спрайтов.
-   Варианты одного объекта должны быть в одной папе с оригиналом, в их названии должно содержатся название оригинала и строка ```_variant_```.
> Важно:  В названии оригинала не должно быть строки ```_variant_```, иначе все спрайты будут считаться вариантами вместе с оригиналом, и ни один не будет отображаться в меню с объектами.

## Горячие клавиши
 - V - сменить вариацию объект.
 - F+X - отзеркалить по горизонтали.
 - F+Y - отзеркалить по вертикали.
 - Удерживать X или Y - перемещение только по одной из координат
 - ESC - выход
