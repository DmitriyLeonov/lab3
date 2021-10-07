using System;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            House house1 = new House();
            House house2 = new House(28);
            House house3 = new House(25, 42.4f, 3, 2, "Пушкина", "панельный", 40);
            int o = 0, number = 23, numberOfRooms = 0, minFloor = 0, maxFloor = 0;
            house1.Number(ref number, out o);
            Console.WriteLine(house1.ToString());
            Console.WriteLine(house3.GetHashCode());
            Console.WriteLine(house1.Equals(house2));
            Console.WriteLine("{0}\n{1}", house3.BuildingType, house3.Floor);

            House[] houses = new House[5] {house3,
                new House(2, 32f, 4, 1, "Пушкина", "панельный", 40),
                new House(5, 44.2f, 2, 2, "Ленина", "панельный", 60),
                new House(55, 62.4f, 1, 3, "Сурганова", "панельный", 50),
                new House(22, 142.4f, 5, 5, "Кирова", "кирпичный", 77)
            };
            numberOfRooms = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            foreach(House house in houses)
            {
                if(house.NumberOfRooms == numberOfRooms)
                {
                    Console.WriteLine("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}\n{7}",
                        house.FlatNumber, house.Square, house.Floor, house.NumberOfRooms,
                        house.Street, house.BuildingType, house.Lifetime, house.BuildYear);
                    Console.WriteLine(house.IsRepairNeeded());
                    Console.WriteLine("---------------------------");
                }
            }
            numberOfRooms = Convert.ToInt32(Console.ReadLine());
            minFloor = Convert.ToInt32(Console.ReadLine());
            maxFloor = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            foreach (House house in houses)
            {
                if (house.NumberOfRooms == numberOfRooms && house.Floor >= minFloor && house.Floor <= maxFloor)
                {
                    Console.WriteLine("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}\n{7}",
                        house.FlatNumber, house.Square, house.Floor, house.NumberOfRooms,
                        house.Street, house.BuildingType, house.Lifetime, house.BuildYear);
                    Console.WriteLine("---------------------------");
                }
            }

            var house4 = new { FlatNumber = 25, Square = 42.4f, Floor = 3, NumberOfRooms = 2,
                Street = "Пушкина",BuildingType =  "панельный", Lifetime = 45 };
            Console.WriteLine("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}",
                       house4.FlatNumber, house4.Square, house4.Floor, house4.NumberOfRooms,
                       house4.Street, house4.BuildingType, house4.Lifetime);

            Console.Read();
        }
    }

    partial class House
    {
        private static int counter;
        private const int currentYear = 2021;

        private int flatnumber;
        private float square;
        private int floor;
        private int numberofrooms;
        private string street;
        private string buildingtype;
        private int lifetime;


        public int Id { get; }
        public int FlatNumber { 
            get { return flatnumber; }
            set {
                if (value <= 0)
                    Console.WriteLine("Номер квартиры должен быть больше 0");
                else
                    flatnumber = value;
            }
        }
        public float Square
        {
            get { return square; }
            set
            {
                if (value <= 0)
                    Console.WriteLine("Площадь должена быть больше 0");
                else
                    square = value;
            }
        }
        public int Floor
        {
            get { return floor; }
            set
            {
                if (value <= 0)
                    Console.WriteLine("Этаж должен быть больше 0");
                else
                    floor = value;
            }
        }
        public int NumberOfRooms
        {
            get { return numberofrooms; }
            set
            {
                if (value <= 0)
                    Console.WriteLine("Количество комнат должено быть больше 0");
                else
                    numberofrooms = value;
            }
        }
        public string Street
        {
            get { return street; }
            set
            {
                if (value == null)
                    Console.WriteLine("Улица не болжна быть null");
                else
                    street = value;
            }
        }
        public string BuildingType
        {
            get { return buildingtype; }
            set
            {
                if (value == null)
                    Console.WriteLine("Тип здания не болжен быть null");
                else
                    buildingtype = value;
            }
        }
        public int Lifetime
        {
            get { return lifetime; }
            set
            {
                if (value <= 0)
                    Console.WriteLine("Срок эксплуатации должен быть больше 0");
                else
                    lifetime = value;
            }
        }
        public int BuildYear { get; }

        Random rnd = new Random();

        public House()
        {
            counter++;
            Id = counter;
            Lifetime = 40;
            BuildYear = rnd.Next(1950, 2000);
        }

        public House(int flatNumber, float square, int floor, int numberOfRooms,
                     string street, string buildingType,int lifetime)
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
            Lifetime = 40;
            BuildYear = rnd.Next(1950, 2000);
        }

        public House( int flatNumber , string street = "Свердлова")
        {
            counter++;
            Id = counter;
            FlatNumber = flatNumber;
            Street = street;
            Lifetime = 40;
            BuildYear = rnd.Next(1950, 2000);
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
            Lifetime = 40;
            BuildYear = rnd.Next(1950, 2000);
        }

        public void Number( ref int number, out int o)
        {
            number = number + 15;
            new House(number);
            o = 20;
        }

        public static void HouseInfo()
        {
            Console.WriteLine(typeof(House));
        }

        public bool IsRepairNeeded()
        {
            if ((currentYear - this.BuildYear) > this.Lifetime)
                return true;
            return false;
        }

    }

    partial class House
    {
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
                Lifetime == house.Lifetime;
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
