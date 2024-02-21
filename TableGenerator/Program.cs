using TableGenerator;
using TableGeneratorLibrary;

var car = new Car
{
    Manufacturer = "Audi",
    MaxSpeed = 100,
    Model = "R8",
    Weight = 1000.5f,
};

var table = new Table<Car>(new Car[] {car});
foreach(var property in table.GetHeaders())
{
    Console.WriteLine(property);
}
Console.WriteLine();
Console.WriteLine(table.Show());
