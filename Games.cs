using Dawn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace BackLog__List
{
    internal class Games
    {

        class Game
        {

            public required string Name { get; set; }
            public Genre Genre { get; set; }
            public Tag Tag { get; set; }
            public int HoursToBeat { get; set; }
            public bool IsCompleted { get; set; }
            public int Grade { get; set; }

            public List<Game> BackLog = new List<Game>();

            public Game(string Name, Genre Genre, Tag Tag, int HoursToBeat, bool IsCompleted, int Grade)
            {
                this.Name = Guard.Argument(() => Name)
                                 .NotNull()
                                 .NotWhiteSpace()
                                 .NotEmpty();
                this.Genre = Guard.Argument(() => Genre)
                                  .In(Genre);
                this.HoursToBeat = Guard.Argument(() => HoursToBeat)
                                        .NotNegative();
                this.IsCompleted = IsCompleted;
                this.Grade = Guard.Argument(() => Grade)
                                  .InRange(0, 11);
                this.Tag = Guard.Argument(() => Tag)
                                .In(Tag);
            }
            public Game Game_Search(Game GameToFind)
            {
                Game GameToChange = Guard.Argument(() => GameToFind)
                                         .In(BackLog);
                return GameToChange;
            }
            public Game Game_To_Modify(Game Game, int ParametersToModify)
            {

                Game GameToModify = Game_Search(Game);
                Guard.Argument(() => ParametersToModify).InRange(0, 6);
                switch (ParametersToModify)
                {
                    //Modify the name of the game
                    case 0:
                        while (true)
                        {
                            Console.WriteLine($"What name would you like to change {GameToModify.Name} to?");
                            string? inputName = Console.ReadLine();
                            if (inputName is not null)
                            {
                                string VerifiedName = Guard.Argument(() => inputName)
                                                     .NotNull()
                                                     .NotWhiteSpace()
                                                     .NotEmpty();
                                Console.WriteLine($"You are going to change {GameToModify.Name} to {VerifiedName}. Are you sure Y for yes, N for no");
                                string? inputAnswer = Console.ReadLine();
                                inputAnswer = Guard.Argument(() => inputAnswer)
                                     .NotEmpty()
                                     .NotNull();
                                inputAnswer = inputAnswer.ToUpper();
                                if (inputAnswer == "Y")
                                {
                                    this.Name = VerifiedName;
                                    break;
                                }
                            }
                            else
                            {
                                throw new ArgumentNullException(inputName, "The name you are trying to enter is not valid.");
                            }
                            break;
                        }
                        break;
                    //Modify the genre of the game
                    case 1:
                        while (true)
                        {
                            Console.WriteLine($"What genre would you like to change {GameToModify.Name} to? Current: {GameToModify.Genre}");
                            string? inputGenre = Console.ReadLine();
                            if (inputGenre is not null)
                            {
                             Genre newGenre = Guard.Argument(()=>inputGenre)
                                  .NotEmpty()
                                  .NotWhiteSpace().Modify(arg=>;

                            }
                            break;
                        }
                        break;
                    //Modify the Tag of the game
                    case 2:
                        while (true)
                        {
                            Console.WriteLine();
                            break;
                        }
                        break;
                    //Modify the name of the game
                    case 3:
                        while (true)
                        {
                            Console.WriteLine();
                            break;
                        }
                        break;
                    //Modify the HoursToBeat of the game
                    case 4:
                        while (true)
                        {
                            Console.WriteLine();
                            break;
                        }
                        break;
                    //Modify the Grade of the game
                    case 5:
                        while (true)
                        {
                            Console.WriteLine();
                            break;
                        }
                        break;


                }
                return GameModified;
            }
        }

        enum Genre
        {
            Action, Adventure, Action_Adventure, Casual, Point_N_Click,
            Racing, RPG, Shooter, Souls_Like, Strategy, Simulator
        };
        enum Tag { BackLog, BeatenButNot100, MaybeList };
    }
}
