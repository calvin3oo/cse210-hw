class WritingAssignment: Assignment{
    protected string _title;

    public string GetWritingInformation(){
        return $"{_title}.";
    }

    // Make the getters and setters.
    public string Title
    {
        get { return _title; }
        set { _title = value; }
    }
}