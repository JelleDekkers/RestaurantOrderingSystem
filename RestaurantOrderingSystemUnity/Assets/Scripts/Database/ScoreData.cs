[System.Serializable]
public struct ScoreData {
    public int ID;
    public int User_ID;
    public int Game_ID;
    public int Score;

    public ScoreData(int id, int userID, int gameID, int score) {
        ID = id;
        User_ID = userID;
        Game_ID = gameID;
        Score = score;
    }
}

