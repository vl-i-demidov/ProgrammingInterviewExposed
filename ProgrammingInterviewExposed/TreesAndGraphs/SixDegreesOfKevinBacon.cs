using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingInterviewExposed.TreesAndGraphs
{
    /*
      PROBLEM The game “Six Degrees of Kevin Bacon” involves trying to find the
      shortest connection between an arbitrarily selected actor and Kevin Bacon. Two
      actors are linked if they appeared in the same movie. The goal of the game is to
      connect the given actor to Kevin Bacon using the fewest possible links.
      Given a list of all major movies in history and their casts (assume that the names
      of movies and actors are unique identifiers), describe a data structure that could
      be constructed to efficiently solve Kevin Bacon problems. Write a routine that
      uses your data structure to determine the Bacon number (the minimum number
      of links needed to connect to Kevin Bacon) for any actor.
     */


    class ActorNode
    {
        public string Name { get; set; }
        public List<MovieNode> Movies { get; set; }
    }

    class MovieNode
    {
        public string Title { get; set; }
        public List<ActorNode> Actors { get; set; }
    }


    class BaconDegreeResolver
    {
        private ActorNode[] _actors;

        public void LoadData(Dictionary<string, string[]> actorWithMovies)
        {
            var movieMap = new Dictionary<string, MovieNode>();

            var actors = new List<ActorNode>();
            foreach (var kv in actorWithMovies)
            {
                var actor = new ActorNode
                {
                    Name = kv.Key,
                    Movies = new List<MovieNode>()
                };

                foreach (var movieTitle in kv.Value)
                {
                    if (!movieMap.ContainsKey(movieTitle))
                    {
                        movieMap.Add(movieTitle, new MovieNode { Title = movieTitle, Actors = new List<ActorNode>() });
                    }

                    var movie = movieMap[movieTitle];
                    movie.Actors.Add(actor);
                    actor.Movies.Add(movie);
                }

                actors.Add(actor);
            }

            _actors = actors.ToArray();
        }

        public int GetBaconDegree(string actorName)
        {
            var actorNode = GetActorNode(actorName);

            var successResults = new List<int>();

            bool firstAttempt = true;

            var skipQueue = new Queue<string>();

            while (true)
            {
                var visitedActors = new List<string> { actorNode.Name };
                if (!firstAttempt)
                {
                    visitedActors.Add(skipQueue.Dequeue());
                }

                var visitedMovies = new List<string>();

                int steps = FindPath(actorNode.Movies, visitedActors, visitedMovies, 0);

                //no path
                if (steps == -1 && firstAttempt)
                {
                    break;
                }

                //shortest possible path, no more tries needed
                if (steps == 0)
                {
                    successResults.Add(steps);
                    break;
                }

                //on next attempts avoid actors from first found path to find the shorter one
                //THIS IS DEFINITELY NOT THE RIGHT APPROACH AND WILL NOT WORK ALWAYS
                if (firstAttempt)
                {
                    skipQueue = new Queue<string>(visitedActors.Where(a => a != actorNode.Name));
                }

                if (steps >= 0)
                {
                    successResults.Add(steps);
                }

                if (skipQueue.Count == 0)
                {
                    break;
                }

                firstAttempt = false;
            }

            return successResults.Count > 0 ? successResults.OrderBy(s => s).First() : -1;
        }

        private int FindPath(List<MovieNode> movies, List<string> visitedActors, List<string> visitedMovies, int steps)
        {
            foreach (var movie in movies)
            {
                if (!visitedMovies.Contains(movie.Title))
                {
                    visitedMovies.Add(movie.Title);

                    if (movie.Actors.Any(a => a.Name == "Bacon"))
                    {
                        return steps;
                    }

                    foreach (var actor in movie.Actors)
                    {
                        if (!visitedActors.Contains(actor.Name))
                        {
                            visitedActors.Add(actor.Name);
                            return FindPath(actor.Movies, visitedActors, visitedMovies, steps + 1);
                        }
                    }
                }
            }

            return -1;
        }

        private ActorNode GetActorNode(string actorName)
        {
            return _actors.First(a => a.Name == actorName);
        }
    }
}
