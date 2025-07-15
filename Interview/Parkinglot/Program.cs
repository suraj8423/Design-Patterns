using System;
using System.Collections.Generic;
using System.Threading;
namespace Interview.Parkinglot;
class Program
{
    static void Main()
    {
        var parkingLot = ParkingLotClass.Instance;

        // --------------------------
        // Create parking floors
        // --------------------------
        var floor1Spots = new List<ParkingSpot>
        {
            ParkingSpotFactory.CreateParkingSpot(ParkingSpotType.Compact, "F1-C1"),
            ParkingSpotFactory.CreateParkingSpot(ParkingSpotType.Large, "F1-L1"),
            ParkingSpotFactory.CreateParkingSpot(ParkingSpotType.Bike, "F1-B1")
        };

        var floor2Spots = new List<ParkingSpot>
        {
            ParkingSpotFactory.CreateParkingSpot(ParkingSpotType.Compact, "F2-C1"),
            ParkingSpotFactory.CreateParkingSpot(ParkingSpotType.Large, "F2-L1"),
            ParkingSpotFactory.CreateParkingSpot(ParkingSpotType.Bike, "F2-B1")
        };

        parkingLot.AddFloor(new ParkingFloor(1, floor1Spots));
        parkingLot.AddFloor(new ParkingFloor(2, floor2Spots));

        // --------------------------
        // Set fee strategy
        // --------------------------
        var rates = new Dictionary<VehicleType, double>
        {
            { VehicleType.Car, 15 },
            { VehicleType.Bike, 5 },
            { VehicleType.Truck, 25 }
        };
        parkingLot.SetFeeStrategy(new VehicleBasedFeeStrategy(rates));
        // Or use flat fee: parkingLot.SetFeeStrategy(new FlatRateFeeStrategy());

        // --------------------------
        // Park vehicles
        // --------------------------
        var bike = new Bike("BIKE-123");
        var car = new Car("CAR-456");
        var truck = new Truck("TRUCK-789");

        var bikeTicket = parkingLot.ParkVehicle(bike);
        Console.WriteLine($"Bike parked at {bikeTicket.ParkingSpot.SpotId}");

        var carTicket = parkingLot.ParkVehicle(car);
        Console.WriteLine($"Car parked at {carTicket.ParkingSpot.SpotId}");

        var truckTicket = parkingLot.ParkVehicle(truck);
        Console.WriteLine($"Truck parked at {truckTicket.ParkingSpot.SpotId}");

        // --------------------------
        // Simulate parking duration
        // --------------------------
        Console.WriteLine("Waiting for 2 seconds to simulate parking duration...");
        Thread.Sleep(2000);

        // --------------------------
        // Unpark vehicles and print fees
        // --------------------------
        var bikeFee = parkingLot.UnparkVehicle("BIKE-123");
        Console.WriteLine($"Bike unparked. Fee: {bikeFee}");

        var carFee = parkingLot.UnparkVehicle("CAR-456");
        Console.WriteLine($"Car unparked. Fee: {carFee}");

        var truckFee = parkingLot.UnparkVehicle("TRUCK-789");
        Console.WriteLine($"Truck unparked. Fee: {truckFee}");
    }
}
