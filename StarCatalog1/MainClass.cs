using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StarCatalog1
{
    public class MainClass
    {
        private static MyCollection<Constellation> _constellations = new MyCollection<Constellation>();

        private static void Main(string[] args)
        {
            SetUp();
            Menu();
        }

        private static void Menu()
        {
            while (true)
            {
                Console.WriteLine("1) Show list of all constellations");
                Console.WriteLine("2) Add new constellation");
                Console.WriteLine("3) Remove constellation");
                Console.WriteLine("4) Correct constellation info");
                Console.WriteLine("5) Show constellation info in details");
                Console.WriteLine("0) Exit");

                var choice = GetNumber(0, 9);
                Console.WriteLine();
                switch (choice)
                {
                    case 1: ShowAll(_constellations); break;
                    case 2: AddNew(); break;
                    case 3: Remove(); break;
                    case 4: CorrectConstellationInfo(); break;
                    //case 5: ShowInfo(); break;
                    case 0: break;
                }
            }
        }

        private static void CorrectConstellationInfo()
        {
            ShowAll(_constellations);
            Console.WriteLine("0) Back to menu");

            Console.WriteLine("Info of which element you want to correct?");
            var star = GetNumber(0, _constellations.Count);

            if (star == 0)
                return;

            Console.WriteLine("What field you want to correct?");
            Console.WriteLine("1) Name");
            Console.WriteLine("2) Coordinates");
            Console.WriteLine("3) Stars");

            var field = GetNumber(1, 3);
            switch (field)
            {
                case 1:
                    _constellations[star].Name = GetName();
                    break;
                case 2:
                    _constellations[star].Coordinates = GetCoordinates();
                    break;
                //case 3:
                    // TODO
            }
        }

        private static void Remove<T>(ICollection<T> collection) where T : INameable
        {
            ShowAll(collection);
            Console.WriteLine("Which one you want to remove?");
            var option = GetNumber(1, _constellations.Count - 1);
            var i = 1;
            foreach (var item in collection)
            {
                if (i != option)
                {
                    ++i;
                    continue;
                }

                collection.Remove(item);
                break;
            }

            Console.WriteLine("Succesfully removed.");
        }

        private static void ShowAll<T>(ICollection<T> collection) where T: INameable
        {
            var i = 1;
            foreach (var element in collection)
            {
                Console.WriteLine($"{i}.\n" + element.Name);
                ++i;
            }

            Console.WriteLine("Press any button to return to the menu.");
            Console.ReadKey();
        }

        private static void AddNew()
        {
            var newConstellation = new Constellation(
                name: GetName(),
                coordinates: GetCoordinates(),
                stars: new MyCollection<Star>()
            );

            _constellations.Add(newConstellation);

            Console.WriteLine("Success!");
            Console.WriteLine("Press any button to return to the menu.");
            Console.ReadKey();
        }

        private static EquatorialCoordinates GetCoordinates()
        {
            var declination = GetAngle("Input declination (between -90 and 90 degrees): ");
            var rightAscension = GetAngle("Input right ascension (between 0 and 360 degrees): ");
            return new EquatorialCoordinates(declination, rightAscension);
        }

        public static bool IsLetterOrSpace(char ch) => Char.IsLetter(ch) || ch == ' ';

        private static string GetName() => GetFromConsole("Input name: ", s => s.All(IsLetterOrSpace));

        private static Angle GetAngle(string message)
        {
            var input = GetFromConsole(message, s => Single.TryParse(s, out float _));
            var floatValue = Convert.ToSingle(input);
            return new Angle(floatValue);
        }

        private static int GetNumber(int min, int max)
        {
            var input = GetFromConsole("Input a number: ", 
                s => Int32.TryParse(s, out int v) && min <= v && v <= max);

            return Convert.ToInt32(input);
        }

        /// <summary>
        /// Get input, that satisfies passed predicate.
        /// </summary>
        /// <param name="message">Message that will be shown before input.</param>
        /// <param name="predicate">Predicate, that input must satisfy.</param>
        /// <returns></returns>
        private static string GetFromConsole(string message, Predicate<string> predicate)
        {
            while (true)
            {
                Console.Write(message);
                var input = Console.ReadLine();
                if (!String.IsNullOrEmpty(input) && predicate(input))
                    return input;

                Console.WriteLine("Wrong input!");
            }
        }

        private static void SetUp()
        {
            // First constellation.
            var constellation1 =
                new Constellation(
                    name: "Gemini",
                    coordinates: new EquatorialCoordinates(
                                    new Angle(20.23f),
                                    new Angle(10.643f)
                                    ), 
                    stars: new MyCollection<Star>
                    {
                        new Star("Castor", 1.1e8f, 1.4e29f, 4.43e28f, new MyCollection<Planet>()),
                        new Star("Pollux", 2.1e8f, 1.1e29f, 3.3e28f,  new MyCollection<Planet>())
                    }
                );

            constellation1.Stars[0].AddPlanet("Planet1", 1.1e4f, 4.8e21f,  1.8e4f,   7.3e5f, 1.1e8f);
            constellation1.Stars[0].AddPlanet("Planet2", 2.2e4f, 3.21e21f, 1.28e4f, 17.3e5f, 4.1e8f);

            constellation1.Stars[1].AddPlanet("Planet1", 2.1e4f, 3.1e21f, 3.48e4f, 1.3e5f, 4e4f);

            // Second constellation.
            var constellation2 =
                new Constellation(
                    name: "Orion",
                    coordinates: new EquatorialCoordinates(
                        new Angle(-10.231f),
                        new Angle(67.98f)
                    ),
                    stars: new MyCollection<Star>
                    {
                        new Star("Bitelguse", 1.1e8f, 1.4e29f, 4.43e28f, new MyCollection<Planet>()),
                        new Star("Mintaka", 2.1e8f, 1.1e29f, 3.3e28f,  new MyCollection<Planet>())
                    }
                );

            constellation1.Stars[1].AddPlanet("Planet1", 2.1e4f, 3.1e21f, 3.48e4f, 1.3e5f, 4e4f);


            _constellations.Add(constellation1);
            _constellations.Add(constellation2);
        }
    }
}
