using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vp_himineu
{
    abstract class Important
    {
        string my_music_salsa = "https://www.youtube.com/watch?v=ra6tWq9Qa3g";
        string my_wifes_music = "https://www.youtube.com/watch?v=51dZn7UFADI";
        string fisica_o_quimica_song = "https://www.youtube.com/watch?v=6ikznQPMSv0";
        
        //Some variables I found in internet
        short circuit;
        double trouble;

        /* enjoy ;) */ string[] someOfTheExamAuthorFavouriteSongs = 
        {
            "https://www.youtube.com/watch?v=opU1urLhw50",
            "https://www.youtube.com/watch?v=OYjZK_6i37M",
            "https://www.youtube.com/watch?v=PvF9PAxe5Ng",
            "https://www.youtube.com/watch?v=94bGzWyHbu0",
            "https://www.youtube.com/watch?v=ME3Ahe8z16k",
            "https://www.youtube.com/watch?v=rxujAPhxlo0",
            "https://www.youtube.com/watch?v=CSvFpBOe8eY",
            "https://www.youtube.com/watch?v=Nba3Tr_GLZU"
        };

        string[] softerSongs = 
        {
            "https://www.youtube.com/watch?v=KLVq0IAzh1A", // Furious 7 :')
            "https://www.youtube.com/watch?v=RgKAFK5djSk",
            "https://www.youtube.com/watch?v=VYpd-2buQc0",
            "https://www.youtube.com/watch?v=W9_nXlvY6Io",
            "https://www.youtube.com/watch?v=Y0Ys4r_RmGQ"
        };

        void RemoveWarnings() 
        {
            circuit = 0;trouble = 0;Console.WriteLine(my_music_salsa, my_wifes_music, fisica_o_quimica_song, circuit, trouble);
        }
    }
}