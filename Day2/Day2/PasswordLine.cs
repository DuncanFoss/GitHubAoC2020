namespace Day2
{
    class PasswordLine
    {
        public int NumberOne{ get; set; }
        public int NumberTwo { get; set; }
        public char RequiredChar { get; set; }
        public string Password { get; set; }

        public PasswordLine(int minimum, int maximum, char requiredChar, string password)
        {
            this.NumberOne = minimum;
            this.NumberTwo = maximum;
            this.RequiredChar = requiredChar;
            this.Password = password;
        }
    }
}
