[System.Serializable]
public struct ProductData {
    public int id;
    public string name;
    public string type;

    public ProductData(int id, string name, string type) {
        this.id = id;
        this.name = name;
        this.type = type;
    }
}

