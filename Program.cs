using System;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    partial class House
    {
        private static int counter;
        private const int currentYear = 2021;

        public int Id { get; }
        public int FlatNumber { get; set; }
        public float Square { get; set; }
        public int Floor { get; set; }
        public int NumberOfRooms { get; set; }
        public string Street { get; set; }
        public string BuildingType { get; set; }
        public int Lifetime { get; set; }

        public House()
        {
            counter++;
            Id = counter;
        }

        public House(int flatNumber, float square, int floor, int numberOfRooms,
            string street, string buildingType, int lifetime)
        {
            counter++;
            Id = counter;
            FlatNumber = flatNumber;
            Square = square;
            Floor = floor;
            NumberOfRooms = numberOfRooms;
            Street = street;
            BuildingType = buildingType;
            Lifetime = lifetime;
        }

        public House(string street = "Свердлова")
        {
            counter++;
            Id = counter;
            Street = street;
        }

        static House()
        {
            counter++;
        }

        private House(int flatNumber)
        {
            counter++;
            Id = counter;
            FlatNumber = 45;
        }

        public void Number( ref int number, out int o)
        {
            new House(number);
            o = 20;
        }

        public static void HouseInfo()
        {
            Console.WriteLine(typeof(House));
        }

        public override bool Equals(object obj)
        {
            var house = obj as House;
            return house != null &&
                Id == house.Id &&
                FlatNumber == house.FlatNumber &&
                Square == house.Square &&
                Floor == house.Floor &&
                NumberOfRooms == house.NumberOfRooms &&
                Street == house.Street &&
                BuildingType == house.BuildingType &&
                Lifetime == house.Lifetime ;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Id.GetHashCode();
                hash = hash * 23 + Square.GetHashCode();
                hash = hash * 23 + FlatNumber.GetHashCode();
                hash = hash * 23 + Floor.GetHashCode();
                hash = hash * 23 + NumberOfRooms.GetHashCode();
                hash = hash * 23 + Lifetime.GetHashCode();
                if (Street != null)                      
                    hash = hash * 23 + Street.GetHashCode();
                if (BuildingType != null)
                    hash = hash * 23 + BuildingType.GetHashCode();
                return hash;
            }
        }

        public override string ToString()
        {
            return typeof(House).ToString();
        }
    }
}
