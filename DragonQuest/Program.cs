using DragonQuest.Rendering;
using DragonQuest.Misc;

ConfigMarkup omaygot = new ConfigMarkup("./Assets/items/skibidi");
Console.WriteLine(omaygot.values.Count);
Console.WriteLine(omaygot.fields.Count);

/*while (true) {

    Console.WriteLine(Console.ReadKey().Key);

}*/

/*

im gonna write documentation here:


DGHSDIOSDJGSJFOSFH

so basically
all
uhm
containers, mobs and items are ENTIDIESSSSS


*/

/*

note for myself: there needs to be a relation between items and mobs, as all items that are on the map and can be picked up (and also have an on-map texture) are treated as entities with no brain

*/

Console.WriteLine("skibidi skibidi skibidi skibidi skibidi\n\n\n\nAMBATUKAMMMM\n\n\n\n");

RandomValue rv = new RandomValue("2-6;69;45-50");
for (int i = 0; i < 100; i++) Console.WriteLine(rv.GetInt());