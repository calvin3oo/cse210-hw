static class ScripturePicker{
    private static Random random = new Random();
    private static Dictionary<string, string>[] scriptures = {
        new Dictionary<string, string>(){
            { "address", "John 3:16" },
            { "verse", "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life." }
        },
        new Dictionary<string, string>(){
            { "address", "Genesis 2:7"},
            { "verse", "And the Lord God formed man of the dust of the ground, and breathed into his nostrils the breath of life; and man became a living soul." }
        },
        new Dictionary<string, string>(){
            { "address", "Matthew 5:5"},
            { "verse", "Blessed are the meek: for they shall inherit the earth." }
        },
        new Dictionary<string, string>(){
            { "address", "John 1:1"},
            { "verse", "In the beginning was the Word, and the Word was with God, and the Word was God." }
        },
        new Dictionary<string, string>(){
            { "address", "Jeremiah 29:11"},
            { "verse", "For I know the thoughts that I think toward you, saith the Lord, thoughts of peace, and not of evil, to give you an expected end." }
        },
        new Dictionary<string, string>(){
            { "address", "Matthew 22:37"},
            { "verse", "Thou shalt love the Lord thy God with all thy heart, and with all thy soul, and with all thy mind." }
        },
        new Dictionary<string, string>(){
            { "address", "John 14:1"},
            { "verse", "Let not your heart be troubled: ye believe in God, believe also in me." }
        },
        new Dictionary<string, string>(){
            { "address", "Romans 6:23"},
            { "verse", "For the wages of sin is death; but the gift of God is eternal life through Jesus Christ our Lord." }
        },
        new Dictionary<string, string>(){
            { "address", "Romans 3:23"},
            { "verse", "For all have sinned, and come short of the glory of God." }
        },
        new Dictionary<string, string>(){
            { "address", "John 3:36"},
            { "verse", "He that believeth on the Son hath everlasting life: and he that believeth not the Son shall not see life; but the wrath of God abideth on him." }
        },
    };

    /**
    * Get a random verse from the dictionary
    * @return The verse as a key value pair. The key "address" is the address of the verse. The key "verse" is a string of the verse.
    */
    public static Dictionary<string, string> getRandomVerse(){
        // Get a random number between 0 and the number of verses
        int randomIndex = random.Next(0, scriptures.Length);
        
        // Return the verse at the random index
        return scriptures[randomIndex];
    }
}