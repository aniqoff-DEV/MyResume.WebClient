using CSharpFunctionalExtensions;

namespace MyResume.WebClient.Enums
{
    public class Schedule : ValueObject
    {
        public static readonly Schedule FullDay = new ("Полный день");
        public static readonly Schedule ShiftWork = new ("Сменный график");
        public static readonly Schedule ShiftMethod = new ("Вахтовый метод");
        public static readonly Schedule FlexibleSchedule = new ("Гибкий график");
        public static readonly Schedule DistantWork = new ("Удаленная работа");

        public static readonly Schedule[] All = [
            FullDay,
            ShiftWork,
            ShiftMethod,
            FlexibleSchedule, 
            DistantWork
            ];

        public string Value { get; }

        private Schedule(string value)
        {
            Value = value;
        }

        public static Result<Schedule> Create(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return Result.Failure<Schedule>("The line must not be empty");

            var schedule = input.ToLower();

            if (All.Any(e => e.Value.ToLower() == schedule) == false)
                return Result.Failure<Schedule>("The value is not valid");

            return new Schedule(schedule);
        }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
