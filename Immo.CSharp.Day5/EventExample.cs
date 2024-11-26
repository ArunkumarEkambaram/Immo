using System;

namespace Immo.CSharp.Day5
{
    public delegate void Notify();
    //Publisher
    public class Me
    {
        public event Notify OnNotification;

        public static int TotalLikes { get; set; }

        public void GetNotification()
        {
            OnNotification?.Invoke();
        }
    }

    //Subscriber
    public class MyFriend 
    {
        public void Like()
        {          
            Console.WriteLine("I liked your video");
            Me.TotalLikes++;
        }
    }
}
