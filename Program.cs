using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


    }
}
