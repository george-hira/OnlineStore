

using Factory;

VehicleFactory factory= new ConcreteVehicleFactory();

IDrivable scooter = factory.GetVehicle(VehicleType.Scooter);

scooter.Drive(50);
IDrivable bike = factory.GetVehicle(VehicleType.Bike);

bike.Drive(20);
Console.ReadKey();


