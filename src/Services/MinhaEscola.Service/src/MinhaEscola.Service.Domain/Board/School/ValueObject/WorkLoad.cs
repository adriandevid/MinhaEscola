using System.Text.Json.Serialization;

namespace MinhaEscola.Service.Domain.Board.School.ValueObject
{
    public struct WorkLoad
    {
        [JsonConstructor]
        public WorkLoad(long weeklyClass, long annualClass, long weekHours)
        {
            WeekHours= weekHours;
            WeeklyClass= weeklyClass;
            AnnualClass= annualClass;

            if (weeklyClass == 0)
                throw new InvalidOperationException("WeeklyClass parameter is required!");
            if (weekHours == 0)
                throw new InvalidOperationException("WeekHours parameter is required!");
            if (annualClass == 0)
                throw new InvalidOperationException("annualClass parameter is required!");
        }

        public long WeeklyClass { get; set; }
        public long AnnualClass { get; set; }
        public long WeekHours { get; set; }

        public static WorkLoad Parse(long weeklyClass, long annualClass, long weekHours)
        {
            return new WorkLoad(weeklyClass, annualClass, weekHours); 
        }
    }
}
