using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video(
            "Learn C# in 10 Minutes",
            "CodeMaster",
            600);

        video1.AddComment(new Comment("John", "Great tutorial!"));
        video1.AddComment(new Comment("Sarah", "Very easy to follow."));
        video1.AddComment(new Comment("David", "Thanks for sharing."));

        videos.Add(video1);

        // Video 2
        Video video2 = new Video(
            "Understanding OOP",
            "Programming Hub",
            850);

        video2.AddComment(new Comment("Mike", "Excellent explanation."));
        video2.AddComment(new Comment("Grace", "This helped me a lot."));
        video2.AddComment(new Comment("Emma", "Can you make more videos?"));

        videos.Add(video2);

        // Video 3
        Video video3 = new Video(
            "How to Build a Game",
            "GameDev Studio",
            1200);

        video3.AddComment(new Comment("Alex", "Awesome content."));
        video3.AddComment(new Comment("James", "Loved the examples."));
        video3.AddComment(new Comment("Sophia", "Very informative."));

        videos.Add(video3);

        // Video 4
        Video video4 = new Video(
            "Data Structures Explained",
            "Tech Academy",
            950);

        video4.AddComment(new Comment("Daniel", "Best explanation ever."));
        video4.AddComment(new Comment("Olivia", "This was helpful."));
        video4.AddComment(new Comment("Lucas", "Thank you!"));

        videos.Add(video4);

        // Display all videos
        foreach (Video video in videos)
        {
            video.DisplayVideo();
        }
    }
}