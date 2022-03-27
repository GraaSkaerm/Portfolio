using Network;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameServer
{
    static class App
    {
        public static Listener Listener { get; set; }

        public static Dictionary<string, User> Users { get; set; }


        public static bool IsGameRunning { get; set; }
        private static object _lock = new object();

        public static int Round { get; private set; }


        public static string Answer { get; private set; }


        private static List<string> _questions = new List<string>()
        {
            "What is something that always goes but never move?",
            "What is round red or green and sits on a tree?",
            "What is it our voices make?",
            "What rimes with pain, and falls from the sky?",
            "What is a media that is commenly read?"
        };

        private static List<string> _gameQuestions = new List<string>()
        {
            "What is something that always goes but never move?",
            "What is round red or green and sits on a tree?",
            "What is it our voices make?",
            "What rimes with pain, and falls from the sky?",
            "What is a media that is commenly read?"
        };

        private static List<string> _gameAnswers = new List<string>()
        {
            "time",
            "apple",
            "sound",
            "rain",
            "books",
        };



        private static List<string> _answers = new List<string>()
        {
            "time",
            "apple",
            "sound",
            "rain",
            "books",
        };


        private static string GetQuestion()
        {
            int rand = new Random().Next(0, _questions.Count);

            string question = _questions[rand];

            _questions.Remove(question);


            Answer = _answers[rand];

            _answers.Remove(Answer);

            return question;
        }

        public static void UpdateLeaderBoard()
        {
            foreach (Client client in Listener.Clients.Values)
            {
                client.Write("a0010" + GetLeaderBoard());
            }
        }

        public static void RunGameLoop()
        {

            lock (_lock)
            {
                _questions = new List<string>(_gameQuestions);
                _answers = new List<string>(_gameAnswers);

                if (IsGameRunning)
                {
                    

                    foreach (User user in Users.Values)
                    {
                        user.Score = 0;
                    }


                    UpdateLeaderBoard();
                }

                while (IsGameRunning)
                {
                    

                    Round++;

                    if (Round == 6)
                    {

                        foreach (Client client in Listener.Clients.Values)
                        {
                            client.Write("a0013");
                        }

                        IsGameRunning = false;

                        return;
                    }

                    string question = GetQuestion();

                    foreach (Client client in  Listener.Clients.Values)
                    {
                        client.Write("a0008" + question);
                    }


                    Thread.Sleep(100);

                    new Thread(SendTime).Start();

                    Thread.Sleep(10000);


                }
            }
        }

        private static void SendTime()
        {
            int count = 0;
            while (count < 10)
            {
                foreach (Client client in Listener.Clients.Values)
                {
                    client.Write("a0009" + (10 - (count + 1)));
                }

                count++;

                Thread.Sleep(1000);
            }

        }


        private static string GetLeaderBoard()
        {
            List<int> scores = new List<int>();
            List<User> leaderBoard = new List<User>();


            foreach (User user in Users.Values)
            {
                scores.Add(user.Score);
            }

            int[] arr = scores.ToArray();

            QucikSort(ref arr, 0, arr.Length - 1);

            arr.Reverse();

            string s = null;



            for (int i = 0; i < arr.Length; i++)
            {
                foreach (User user in Users.Values)
                {
                    if (leaderBoard.Contains(user) == false && arr[i] == user.Score)
                    {
                        s += $"{user.Name}: {user.Score}\n";
                        leaderBoard.Add(user);
                    }
                }
            }



            return s;
        }



        public static void QucikSort(ref int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(ref arr, right, left);
                QucikSort(ref arr, left, pivotIndex - 1);
                QucikSort(ref arr, pivotIndex + 1, right);
            }
        }

        private static int Partition(ref int[] arr, int right, int left)
        {
            int pivot = arr[right];
            int leftWall = left;

            for (int i = left; i < right; i++)
            {
                if (arr[i] < pivot)
                {
                    Swap(ref arr[leftWall], ref arr[i]);
                    leftWall++;
                }
            }

            Swap(ref arr[leftWall], ref arr[right]);
            return leftWall;
        }

        private static void Swap(ref int a, ref int b)
        {
            if (a == b) return;
            int temp = a;
            a = b;
            b = temp;
        }




    }
}
