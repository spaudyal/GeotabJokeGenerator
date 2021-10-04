namespace Geotab.Model
{
    public class JokeSubject
    {
        public string FirstName { get; set; } = "Chuck";
        public string LastName { get; set; } = "Norris";

        public override string ToString()
        {
            return $"FirstName: {FirstName}, LastName: {LastName}";
        }
    }
}
