/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2017 GPLv3
 *  Level .......: Advanced
 *  Target ......: netcoreapp2.0 WslNeo4j.dll
 *  Description..: Movie query using WSL and Neo4j
 *  Requires ....: Neo4j Client package
 *                 Neo4j Driver package
 *                 Newtonsoft Json package
 *                 Neo4j Movie Data
 *
 *  Note: Check dbuser and db dbpasswd matches the database being connected to.
 *
 */
using System;
using Neo4jClient;
using Neo4j.Driver.V1;
using Newtonsoft.Json;

namespace Beam.Example.WslNeo4j
{
    #region Main Method

    class Program
    {
        static void Main(string[] args)
        {
            // edit these to match your Neo4j Database User and Password
            string dbuser = "neo4j";
            string dbpasswd = "neo4j";

            #region Database Connection via Neo4jClient

            var client = new GraphClient(new Uri("http://localhost:7474/db/data"), dbuser, dbpasswd);
            client.Connect();

            #endregion

            #region First Query <Movie, Year, TagLine>

            // Get the movies
            var movies = client.Cypher
                       .Match("(m:Movie)")
                       .Return(m => m.As<Movie>())
                       .Limit(4)
                       .Results;


            // set title
            Console.Title = "WSL Neo4j Demo Query";

            // clear screen
            Console.Clear();

            // print header
            Console.WriteLine();
            Console.WriteLine("List Movies (Limit = 4)");
            Console.WriteLine("-----------------------");
            foreach (var movie in movies)
            {
                // Write the results
                 Console.WriteLine(
                    $"{movie.Title.PadRight(22)} " +
                    $"{Convert.ToString(movie.Released).PadRight(5)}" +
                    $"{movie.TagLine}"
                    );
            }

            #endregion

            #region Second Query Actor <Name, Born>
            
            var persons = client.Cypher
                       .Match("(a:Person)")
                       .Return(a => a.As<Person>())
                       .Limit(4)
                       .Results;
            Console.WriteLine("\nActor Query (Limit = 4)");
            Console.WriteLine("-------------------------");
            foreach (var person in persons)
            {
                // Write the results
                Console.WriteLine(
                    $"{person.Name.PadRight(20)} " +
                    $"{Convert.ToString(person.Born)}"
                    );
            }
            client.Dispose(); // ensure the client is closed

            #endregion

            #region Third and Fourth Query (Producer Joel Silver) and (Acted in and Directed)

            using (var driver = GraphDatabase.Driver("bolt://localhost", AuthTokens.Basic(dbuser, dbpasswd)))
            using (var session = driver.Session())
            {
                var result1 = session.Run("MATCH (a:Person)-[:PRODUCED]->(m:Movie) WHERE a.name = 'Joel Silver' RETURN m");

                Console.WriteLine("\nProducer (Joel Silver)");
                Console.WriteLine("-------------------------");
                foreach (var node in result1)
                {
                    var iNode = node["m"].As<INode>();
                    Console.WriteLine($"{iNode.Properties["title"].As<String>()}");
                    //Console.WriteLine($"Released: {iNode.Properties["released"].As<String>()}\n\n");
                }

                // Could probably do a UNION or second foreach to get Movie "title" also
                var result2 = session.Run("MATCH (a)-[:ACTED_IN]->(m)<-[:DIRECTED]-(a) RETURN a");
                Console.WriteLine("\nWho Acted & Directed");
                Console.WriteLine("------------------------------");
                foreach (var node in result2)
                {
                    var iNode = node["a"].As<INode>();
                    Console.WriteLine($"{iNode.Properties["name"].As<String>()}" +
                        $", Born in {iNode.Properties["born"].As<String>()}");
                }
            }

            #endregion

            Environment.Exit(0);
        }
    } // END - class Main

    #endregion

    #region Person

    public class Person
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "born")]
        public int Born { get; set; }
    }

    #endregion

    #region class Movie
    
    public class Movie
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "released")]
        public int Released { get; set; }

        [JsonProperty(PropertyName = "tagline")]
        public string TagLine { get; set; }
    } // END - class Move

    # endregion 

} // END - namespace Beam.Example.WslNeo4j