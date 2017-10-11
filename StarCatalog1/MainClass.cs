using System;
using System.Collections.Generic;
using System.Linq;

namespace StarCatalog
{
    public class MainClass
    {
        private static readonly MyCollection<Constellation> Constellations = new MyCollection<Constellation>();

        private static void Main(string[] args)
        {
            SetUp();
            Menu();
        }

        private static void Menu()
        {
            while (true)
            {
                Console.WriteLine("You are in main menu!");
                Console.WriteLine("1) Show list of all constellations");
                Console.WriteLine("2) Add new constellation");
                Console.WriteLine("3) Remove constellation");
                Console.WriteLine("4) Correct constellation info");
                Console.WriteLine("5) Show constellation info in details");
                Console.WriteLine("0) Exit");

                var choice = GetIntValue(0, 5);
                Console.WriteLine();
                switch (choice)
                {
                    case 1:
                        ShowAllNames(Constellations);
                        break;
                    case 2:
                        AddNewConstellation();
                        break;
                    case 3:
                        Remove(Constellations);
                        break;
                    case 4:
                        CorrectConstellationInfo();
                        break;
                    case 5:
                        ShowFullInfo(Constellations);
                        break;
                    case 0:
                        return;
                }
            }
        }

        private static void ShowAllNames<T>(ICollection<T> collection) where T : INameable
        {
            if (collection.Count == 0)
            {
                Console.WriteLine("None\n");
                return;
            }

            var i = 1;
            foreach (var element in collection)
            {
                Console.WriteLine($"{i}. " + element.Name);
                ++i;
            }

            Console.WriteLine();
        }

        private static void AddNewConstellation()
        {
            var newConstellation = new Constellation(
                name: GetName(),
                coordinates: GetCoordinates()
            );

            Constellations.Add(newConstellation);

            Console.WriteLine("Success!");
            Console.WriteLine("Press any button to return to the menu.\n");
            Console.ReadKey();
        }

        private static void Remove<T>(IList<T> collection) where T : INameable
        {
            ShowAllNames(collection);
            Console.WriteLine("0. Return to main menu");
            Console.WriteLine("What element do you want to remove?");
            var option = GetIntValue(0, Constellations.Count) - 1;

            if (option == -1)
                return;

            collection.RemoveAt(option);

            Console.WriteLine("Succesfully removed.");
        }

        private static void CorrectConstellationInfo()
        {
            ShowAllNames(Constellations);
            Console.WriteLine("0. Back to main menu");

            Console.WriteLine("Info of which element you want to correct?");
            var constellationIndex = GetIntValue(0, Constellations.Count) - 1;

            if (constellationIndex == -1)
                return;

            Console.WriteLine("What you want to do?");
            Console.WriteLine("1) Name");
            Console.WriteLine("2) Coordinates");
            Console.WriteLine("3) Add a star");
            Console.WriteLine("4) Remove star");
            Console.WriteLine("5) Correct star info");
            Console.WriteLine("0) Back to main menu");
            Console.WriteLine();

            var field = GetIntValue(0, 5);
            switch (field)
            {
                case 1:
                    Constellations[constellationIndex].Name = GetName();
                    break;
                case 2:
                    Constellations[constellationIndex].Coordinates = GetCoordinates();
                    break;
                case 3:
                    Constellations[constellationIndex].AddStar(
                        name: GetName(),
                        radius: GetFloatValue("Input radius: "),
                        mass: GetFloatValue("Input mass: "),
                        temperature: GetFloatValue("Input temperature: ")
                    );
                    break;
                case 4:
                    Remove(Constellations[constellationIndex].Stars);
                    break;
                case 5:
                    CorrectStarsInfo(Constellations[constellationIndex]);
                    break;
                case 6:
                    return;
            }
        }

        private static void CorrectStarsInfo(Constellation constellation)
        {
            ShowAllNames(constellation.Stars);
            Console.WriteLine("0. Back to main menu");

            Console.WriteLine("Info of which element you want to correct?");
            var starIndex = GetIntValue(0, constellation.Stars.Count) - 1;

            if (starIndex == -1)
                return;

            Console.WriteLine("What field you want to correct?");
            Console.WriteLine("1) Name");
            Console.WriteLine("2) Radius");
            Console.WriteLine("3) Temperature");
            Console.WriteLine("4) Mass");
            Console.WriteLine("5) Add planet");
            Console.WriteLine("6) Remove planet");
            Console.WriteLine("7) Correct planet info");
            Console.WriteLine("0) Back to main menu");
            Console.WriteLine();

            var field = GetIntValue(0, 7);
            switch (field)
            {
                case 1:
                    constellation.Stars[starIndex].Name = GetName();
                    break;
                case 2:
                    constellation.Stars[starIndex].Radius = GetFloatValue("Input raduis in metres: ");
                    break;
                case 3:
                    constellation.Stars[starIndex].Temperature = GetFloatValue("Input temperature in Kelvins: ");
                    break;
                case 4:
                    constellation.Stars[starIndex].Mass = GetFloatValue("Input mass in kg: ");
                    break;
                case 5:
                    constellation.Stars[starIndex].AddPlanet(
                        name: GetName(),
                        radius: GetFloatValue("Input radius in metres: "),
                        mass: GetFloatValue("Input mass in kg: "),
                        siderealDay: GetFloatValue("Input length of sideral day in seconds: "),
                        siderealYear: GetFloatValue("Input length of sideral year in seconds: "),
                        orbitRadius: GetFloatValue("Input radius of the orbit in metres: ")
                    );
                    break;
                case 6:
                    Remove(constellation.Stars[starIndex].Planets);
                    break;
                case 7:
                    CorrectPlanetInfo(constellation.Stars[starIndex]);
                    break;
                case 0:
                    return;
            }
        }

        private static void CorrectPlanetInfo(Star star)
        {
            ShowAllNames(star.Planets);
            Console.WriteLine("0. Back to main menu");

            Console.WriteLine("Info of which element you want to correct?");
            var planetIndex = GetIntValue(0, star.Planets.Count) - 1;

            if (planetIndex == -1)
                return;

            Console.WriteLine("What field you want to correct?");
            Console.WriteLine("1) Name");
            Console.WriteLine("2) Radius");
            Console.WriteLine("3) Mass");
            Console.WriteLine("4) Sideral day");
            Console.WriteLine("5) Sideral year");
            Console.WriteLine("6) Orbit radius");
            Console.WriteLine("0) Back to main menu");

            var option = GetIntValue(0, 6);
            switch (option)
            {
                case 1:
                    star.Planets[planetIndex].Name = GetName();
                    break;
                case 2:
                    star.Planets[planetIndex].Radius = GetFloatValue("Input planets radius in metres: ");
                    break;
                case 3:
                    star.Planets[planetIndex].Mass = GetFloatValue("Input planets mass in kg: ");
                    break;
                case 4:
                    star.Planets[planetIndex].SiderealDay = GetFloatValue("Input planets sideral day in seconds: ");
                    break;
                case 5:
                    star.Planets[planetIndex].SiderealYear = GetFloatValue("Input planets sideral year in seconds: ");
                    break;
                case 6:
                    star.Planets[planetIndex].OrbitRadius = GetFloatValue("Input planets orbit radius in metres: ");
                    break;
                case 0:
                    return;
            }
        }

        private static void ShowFullInfo<T>(IList<T> collection) where T: INameable
        {
            ShowAllNames(collection);
            Console.WriteLine("0. Back to main menu");

            Console.WriteLine("Full info of which element you want to see?");
            var elementIndex = GetIntValue(0, collection.Count) - 1;

            if (elementIndex == -1)
                return;

            var elementInfo = collection[elementIndex].ToString();
            Console.WriteLine(elementInfo);

            Console.WriteLine("Press any button to return to main menu.");
            Console.ReadKey();
        }

        private static Coordinates GetCoordinates()
        {
            var declination = GetAngle("Input declination (between -90 and 90 degrees): ", f => (f >= -90f && f <= 90f));
            var rightAscension = GetAngle("Input right ascension (between 0 and 360 degrees): ", f => (f >= 0f && f <= 360f));
            return new Coordinates(declination, rightAscension);
        }

        private static string GetName() => GetFromConsole("Input name: ", s => s.All(IsLetterOrSpace));

        public static bool IsLetterOrSpace(char ch) => Char.IsLetter(ch) || ch == ' ';

        private static Angle GetAngle(string message, Predicate<float> predicate)
        {
            var input = GetFromConsole(message, s => Single.TryParse(s, out float f) &&
                                                     predicate(f));

            var floatValue = Convert.ToSingle(input);
            return new Angle(floatValue);
        }

        private static int GetIntValue(int min, int max)
        {
            var input = GetFromConsole("Input a number: ", s => Int32.TryParse(s, out int v) && 
                                                                min <= v && v <= max);

            var intValue = Convert.ToInt32(input);
            return intValue;
        }

        private static float GetFloatValue(string message)
        {
            var input = GetFromConsole(message, s => Single.TryParse(s, out float v) && 
                                                     v > 0);

            var floatValue = Convert.ToSingle(input);
            return floatValue;
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
                    coordinates: new Coordinates(
                        new Angle(20.23f),
                        new Angle(10.643f)
                ));

            constellation1.AddStar("Castor", 1.1e8f, 1.4e29, 4.43e28f);
            constellation1.AddStar("Pollux", 2.1e8f, 1.1e29, 3.3e28f);

            constellation1.Stars[0].AddPlanet("Planet1", 1.1e4f, 4.8e21,  1.8e4f,   7.3e5f, 1.1e8f);
            constellation1.Stars[0].AddPlanet("Planet2", 2.2e4f, 3.21e21, 1.28e4f, 17.3e5f, 4.1e8f);

            constellation1.Stars[1].AddPlanet("Planet1", 2.1e4f, 3.1e21, 3.48e4f, 1.3e5f, 4e4f);

            // Second constellation.
            var constellation2 =
                new Constellation(
                    name: "Orion",
                    coordinates: new Coordinates(
                        new Angle(-10.231f),
                        new Angle(67.98f)
                ));

            constellation2.AddStar("Bitelguse", 1.1e8f, 1.4e29, 4.43e28f);
            constellation2.AddStar("Mintaka", 2.1e8f, 1.1e29, 3.3e28f);

            constellation2.Stars[1].AddPlanet("Planet1", 2.1e4f, 3.1e21, 3.48e4f, 1.3e5f, 4e4f);


            Constellations.Add(constellation1);
            Constellations.Add(constellation2);
        }
    }
}
