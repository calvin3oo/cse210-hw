class Assignment
{
    protected string _studentName;
    protected string _topic;

    // Make the getters and setters.
    public string StudentName
    {
        get { return _studentName; }
        set { _studentName = value; }
    }

    public string Topic
    {
        get { return _topic; }
        set { _topic = value; }
    }

    public string GetSummary(){
        return $"{_studentName} - {_topic}.";
    }
}