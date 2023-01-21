using System;
using System.Collections.Generic;
using System.IO;

// ====================================================================
// Student Number : S10223421, S10223527
// Student Name : Syahmi Mirhan Bin Zulkiflee, Luismika Lim Chieng Hee
// Module Group : T02
// ====================================================================

namespace SingaCineplex
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Movie> movieList = new List<Movie>();
            List<Cinema> cinemaList = new List<Cinema>();
            List<Screening> screeningList = new List<Screening>();
            List<Order> orderList = new List<Order>();
            int orderNo = 0;
            AddMovieList(movieList);
            AddCinemaList(cinemaList);
            AddScreeningList(screeningList, cinemaList, movieList);
            Console.WriteLine("Welcome to Singa Cineplex");
            Console.WriteLine("-------------------------");
            while (true)
            {
                DisplayMainMenu();
                Console.Write("\nSelect an option: ");
                string option = Console.ReadLine();
                if (option == "1")
                {
                    DisplayAllMovies(movieList);
                }
                else if (option == "2")
                {
                    ListMovieScreening(movieList, screeningList);
                }
                else if (option == "3")
                {
                    AddMovieScreening(screeningList, cinemaList, movieList);
                }
                else if (option == "4")
                {
                    DeleteScreening(screeningList);
                }
                else if (option == "5")
                {
                    OrderMovieTicket(movieList, screeningList, orderNo, orderList);
                    orderNo += 1;
                }

            }

        }

        static void DisplayMainMenu()
        {
            Console.WriteLine("[1] Show Available Movies \n[2] Show Movie Screenings \n[3] Add Movie Screening" +
                "\n[4] Delete Movie Screening \n[5] Order Movie Ticket");
        }
        static void AddMovieList(List<Movie> mList) // Creating a Movie List with Movie objects
        {
            List<string> genreList = new List<string>();
            string[] movieArray = File.ReadAllLines("Movie.csv"); // Reading data from file
            for (int i = 1; i < movieArray.Length; i++) // Adding movie objects
            {
                string[] movieInfo = movieArray[i].Split(',');
                Movie movie = new Movie(movieInfo[0], Convert.ToInt32(movieInfo[1]), movieInfo[3], Convert.ToDateTime(movieInfo[4]), genreList);
                mList.Add(movie);
                movie.AddGenre(movieInfo[2]);
            }
        }
        static void AddCinemaList(List<Cinema> cList) // Creating a Cinema List with Cinema objects
        {
            string[] cinemaArray = File.ReadAllLines("Cinema.csv");
            for (int i = 1; i < cinemaArray.Length; i++)
            {
                string[] cinemaInfo = cinemaArray[i].Split(',');
                cList.Add(new Cinema(cinemaInfo[0], Convert.ToInt32(cinemaInfo[1]), Convert.ToInt32(cinemaInfo[2])));
            }
        }

        static void AddScreeningList(List<Screening> sList, List<Cinema> cList, List<Movie> mList) // Creating a Screening List with Screening objects
        {
            string[] screeningArray = File.ReadAllLines("Screening.csv");
            for (int i = 1; i < screeningArray.Length; i++)
            {
                string[] screeningInfo = screeningArray[i].Split(',');
                string cName = screeningInfo[2];
                int hallNo = Convert.ToInt32(screeningInfo[3]);
                string movie = screeningInfo[4];
                Cinema cinemaObj = SearchCinema(cList, cName, hallNo);
                Movie movieObj = SearchMovie(mList, movie);
                Screening screeningObj = new Screening(i + 1000, Convert.ToDateTime(screeningInfo[0]), screeningInfo[1], cinemaObj, movieObj);
                screeningObj.SeatsRemaining = cinemaObj.Capacity;
                sList.Add(screeningObj);
                movieObj.AddScreening(screeningObj);
            }
        }
        static void DisplayAllMovies(List<Movie> mList) // Display all movies from list
        {
            Console.WriteLine();
            Console.WriteLine("{0, -26}{1, -18}{2, -27}{3, -17}{4}", "Title of Movie", "Duration (mins)", "Genre of Movie", "Classification",
                    "Opening Date");
            Console.WriteLine("{0, -26}{1, -18}{2, -27}{3, -17}{4}", "--------------", "---------------", "--------------", "--------------",
                    "------------");
            for (int i = 0; i < mList.Count; i++)
            {
                Console.WriteLine("{0, -26}{1, -18}{2, -27}{3, -17}{4}", mList[i].Title, mList[i].Duration, mList[i].GenreList[i],
                    mList[i].Classification, (mList[i].OpeningDate).ToString("dd/MM/yyyy"));
                Console.WriteLine();
            }
        }
        static void ListMovieScreening(List<Movie> mList, List<Screening> sList)
        {
            DisplayAllMovies(mList);
            Console.Write("Select a movie: ");
            string movie = Console.ReadLine();
            Movie movieObj = SearchMovie(mList, movie);
            if (movieObj.ScreeningList.Count == 0)
            {
                Console.WriteLine("\nNo screening sessions for this movie.\n");
            }
            else
            {
                DisplayScreeningHeading();
                for (int i = 0; i < movieObj.ScreeningList.Count; i++)
                {
                    DisplayScreening(movieObj.ScreeningList[i]);
                }
                Console.WriteLine();
            }
        }
        static bool NoScreening(List<Screening> sList, string movie)
        {
            for (int i = 0; i < sList.Count; i++)
            {
                if (movie == sList[i].Movie.Title)
                {
                    return false;
                }
            }
            return true;
        }
        static Cinema SearchCinema(List<Cinema> cList, string cName, int hallNo)
        {
            for (int i = 0; i < cList.Count; i++)
            {
                if (cName == cList[i].Name && hallNo == cList[i].HallNo)
                {
                    return cList[i];
                }
            }
            return null;
        }
        static Movie SearchMovie(List<Movie> mList, string movie)
        {
            for (int i = 0; i < mList.Count; i++)
            {
                if (movie == mList[i].Title)
                {
                    return mList[i];
                }
            }
            return null;
        }
        static Screening SearchScreening(List<Screening> sList, List<Movie> mList, List<Cinema> cList, string movie, string cName, int hallNo)
        {
            Movie movieObj = SearchMovie(mList, movie);
            Cinema cinemaObj = SearchCinema(cList, cName, hallNo);
            for (int i = 0; i < sList.Count; i++)
            {
                if (sList[i].Movie == movieObj && sList[i].Cinema == cinemaObj)
                {
                    return sList[i];
                }
            }
            return null;
        }
        static bool ScreeningAvailability(List<Screening> sList, List<Cinema> cList, Movie movieObj, Cinema cinemaObj,
            DateTime screenDateTime, string movie)
        {
            for (int i = 0; i < sList.Count; i++)
            {
                if (sList[i].Movie == movieObj && sList[i].Cinema == cinemaObj)
                {
                    TimeSpan timeDiff = screenDateTime.Subtract(sList[i].ScreeningDateTime);
                    double minutesDiff = timeDiff.TotalMinutes;
                    if (minutesDiff >= movieObj.Duration + 60)
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        static void AddMovieScreening(List<Screening> sList, List<Cinema> cList, List<Movie> mList)
        {
            DisplayAllMovies(mList);
            Console.Write("Select a movie: ");
            string movie = Console.ReadLine();
            Console.Write("Select type of screening [2D/3D]: ");
            string screenType = Console.ReadLine();
            Console.Write("Select date and time of screening [dd/MM/yyyy]: ");
            DateTime screenDateTime = Convert.ToDateTime(Console.ReadLine());
            if (NoScreening(sList, movie))
            {
                DisplayAllCinema(cList);
                Console.Write("Select a cinema name: ");
                string cName = Console.ReadLine();
                Console.Write("Select a hall number: ");
                int hallNo = Convert.ToInt32(Console.ReadLine());
                Cinema cinemaObj = SearchCinema(cList, cName, hallNo);
                Movie movieObj = SearchMovie(mList, movie);
                sList.Add(new Screening(sList.Count + 1001, screenDateTime, screenType, cinemaObj, movieObj));
                Console.WriteLine("\nMovie screening session is created successfully.\n");
            }
            else
            {
                Movie movieObj = SearchMovie(mList, movie);
                if ((screenDateTime - movieObj.OpeningDate).Days >= 0)
                {
                    DisplayAllCinema(cList);
                    Console.Write("\nSelect a cinema name: ");
                    string cName = Console.ReadLine();
                    Console.Write("Select a hall number: ");
                    int hallNo = Convert.ToInt32(Console.ReadLine());
                    Cinema cinemaObj = SearchCinema(cList, cName, hallNo);
                    if (ScreeningAvailability(sList, cList, movieObj, cinemaObj, screenDateTime, movie))
                    {
                        Screening screeningObj = new Screening(sList.Count + 1001, screenDateTime, screenType, cinemaObj, movieObj);
                        sList.Add(screeningObj);
                        movieObj.AddScreening(screeningObj);
                        screeningObj.SeatsRemaining = cinemaObj.Capacity;
                        Console.WriteLine("\nMovie screening session is created successfully.\n");
                    }
                    else
                    {
                        Console.WriteLine("\nFailed to create movie screening session. Please choose another date and time.\n");
                    }
                }
                else
                {
                    Console.WriteLine("\nFailed to continue. Please choose another date and time.\n");
                }
            }

        }

        static void DisplayAllCinema(List<Cinema> cList) // Display all cinema halls from list
        {
            Console.WriteLine("\n{0, -16}{1, -14}{2, -27}", "Cinema Name", "Hall Number", "Maximum Capacity");
            Console.WriteLine("{0, -16}{1, -14}{2, -27}", "-----------", "-----------", "----------------");
            for (int i = 0; i < cList.Count; i++)
            {
                Console.WriteLine("{0, -16}{1, -14}{2, -27}", cList[i].Name, cList[i].HallNo, cList[i].Capacity);
                Console.WriteLine();
            }

        }
        static void DisplayScreeningHeading() // Display all movies from list
        {
            Console.WriteLine();
            Console.WriteLine("{0, -13}{1, -24}{2, -17}{3, -18}{4, -15}{5}", "Screening", "Title of Movie", "Screening Type", "Cinema Name",
                "Hall Number", "Date and time");
            Console.WriteLine("{0, -13}{1, -24}{2, -17}{3, -18}{4, -15}{5}", "---------", "--------------", "--------------", "-----------",
                "-----------", "-------------");
        }
        static void DisplayScreening(Screening s)
        {
            Console.WriteLine("{0, -13}{1, -24}{2, -17}{3, -18}{4, -15}{5}", s.ScreeningNo, s.Movie.Title, s.ScreeningType,
                    s.Cinema.Name, s.Cinema.HallNo, s.ScreeningDateTime.ToString("dd/MM/yyyy H:mm"));
            Console.WriteLine();
        }
        static void DeleteScreening(List<Screening> sList)
        {
            int count = 0;
            int heading = 0;
            for (int i = 0; i < sList.Count; i++)
            {
                if (sList[i].SeatsRemaining == sList[i].Cinema.Capacity && count == 0)
                {
                    if (heading == 0)
                    {
                        DisplayScreeningHeading();
                        heading += 1;
                    }
                    DisplayScreening(sList[i]);
                }
                else
                {
                    count += 1;
                    if (count == sList.Count)
                    {
                        Console.WriteLine("\nNo movie screenings to delete.\n");
                        break;
                    }
                }
            }
            if (count != sList.Count)
            {
                Console.Write("Select screening number: ");
                int screeningNo = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < sList.Count; i++)
                {
                    if (screeningNo == sList[i].ScreeningNo)
                    {
                        sList[i].Movie.ScreeningList.Remove(sList[i]);
                        sList.Remove(sList[i]);
                        Console.WriteLine("\nScreening session has been deleted successfully.\n");
                        for (int n = 0; n < sList.Count; n++)
                        {
                            if (screeningNo < sList[n].ScreeningNo)
                            {
                                sList[n].ScreeningNo -= 1;
                            }
                        }
                    }
                }
            }

        }
        static void OrderMovieTicket(List<Movie> mList, List<Screening> sList, int orderNo, List<Order> oList)
        {
            DisplayAllMovies(mList);
            Console.Write("Select a movie: ");
            string movieTitle = Console.ReadLine();
            DisplayScreeningHeading();
            for (int i = 0; i < sList.Count; i++)
            {
                if (sList[i].Movie.Title == movieTitle)
                {
                    Console.WriteLine("{0, -13}{1, -24}{2, -17}{3, -18}{4, -15}{5}", sList[i].ScreeningNo, sList[i].Movie.Title, sList[i].ScreeningType,
                    sList[i].Cinema.Name, sList[i].Cinema.HallNo, sList[i].ScreeningDateTime.ToString("dd/MM/yyyy H:mm"));
                }
            }
            Console.WriteLine();
            Console.Write("Select a movie screening by its screening number: ");
            int sNo = Convert.ToInt32(Console.ReadLine());
            DisplayScreeningHeading();
            for (int i = 0; i < sList.Count; i++)
            {
                if (sList[i].ScreeningNo == sNo)
                {
                    Console.WriteLine("{0, -13}{1, -24}{2, -17}{3, -18}{4, -15}{5}", sList[i].ScreeningNo, sList[i].Movie.Title, sList[i].ScreeningType,
                    sList[i].Cinema.Name, sList[i].Cinema.HallNo, sList[i].ScreeningDateTime.ToString("dd/MM/yyyy H:mm"));
                    Console.Write("Number of tickets you would like to purchase: ");
                    int noTickets = Convert.ToInt32(Console.ReadLine());
                    if (noTickets > sList[i].SeatsRemaining)
                    {
                        Console.WriteLine("No of tickets exceed the number of seats remaining");
                    }
                    else
                    {
                        sList[i].SeatsRemaining = sList[i].SeatsRemaining - noTickets;
                    }
                    Console.Write("Do all the ticket holders meet the classification requirements (Y/N):  ");
                    string cRequirement = Console.ReadLine();
                    while (true)
                    {
                        if (cRequirement == "Y" || cRequirement == "y")
                        {
                            int noOfAdults = 0;
                            int noOfStudents = 0;
                            int noOfSeniors = 0;
                            Order newOrder = new Order(oList.Count, DateTime.Now);
                            newOrder.Status = "Unpaid";
                            newOrder.Amount = 0;
                            newOrder.TicketList = new List<Ticket>();
                            for (int n = 0; n < noTickets; n++)
                            {
                                Console.Write("Type of ticket (adult/ student/ senior citizen): ");
                                string ticketType = Console.ReadLine();
                                if (ticketType == "adult" || ticketType == "Adult")
                                {
                                    Popcorn();
                                    newOrder.TicketList.Add(new Adult(sList[i], Popcorn()));
                                    noOfAdults += 1;
                                }
                                else if (ticketType == "student" || ticketType == "Student")
                                {
                                    Console.WriteLine("Level of study (Primary, Secondary, Tertiary): ");
                                    string lvlOfStudy = Console.ReadLine();
                                    newOrder.TicketList.Add(new Student(sList[i], lvlOfStudy));
                                    noOfStudents += 1;
                                }
                                else if (ticketType == "senior citizen" || ticketType == "Senior citizen" || ticketType == "Senior Citizen")
                                {
                                    Console.Write("Year of birth: ");
                                    int birthDate = Convert.ToInt32(Console.ReadLine());
                                    newOrder.TicketList.Add(new SeniorCitizen(sList[i], birthDate));
                                    noOfSeniors += 1;
                                }
                            }
                            double price = 0;
                            for (int x = 0; x < newOrder.TicketList.Count; x++)
                            {
                                price += newOrder.TicketList[x].CalculatePrice();
                            }
                            Console.WriteLine("Total amount payable: $" + price);
                            Console.Write("Press any key to make payment");
                            Console.ReadLine();
                            newOrder.Amount = price;
                            newOrder.Status = "Paid";
                            break;
                        }
                        else if (cRequirement == "N" || cRequirement == "n")
                        {
                            Console.WriteLine("Sorry, as some ticket holders do not meet the classification requirements, we are unable to proceed." +
                                " Please select another movie.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid input, please try again.");
                        }
                    }
                }
            }
        }
        static bool Popcorn()
        {
            Console.WriteLine("Do you want popcorn (Y/N): ");
            string choice = Console.ReadLine();
            if (choice == "Y" || choice == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
