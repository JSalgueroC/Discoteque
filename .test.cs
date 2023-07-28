List<string> bannedWords = new List<string>{"respeto", "guerra", "poder", "amor"};
        var wordsInName = album.Name.ToLower().Split(' ').ToList();
        bool bannedWordsFound = wordsInName.Intersect(bannedWords).Any();

        if (bannedWordsFound == true){
            throw new Exception("lnvalid album name.");
        } 