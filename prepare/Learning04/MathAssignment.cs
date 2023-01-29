class MathAssignment: Assignment{
    protected string _textbookSection;
    protected string _problems;

    public string GetHomeworkList(){
        return $"{_problems}.";
    }

    // Make the getters and setters.
    public string TextbookSection
    {
        get { return _textbookSection; }
        set { _textbookSection = value; }
    }

    public string Problems
    {
        get { return _problems; }
        set { _problems = value; }
    }
}