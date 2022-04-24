using System.Diagnostics;

namespace CarClass
{
    public class CarList
    {
        public List<Car> Cars = new();
        Stopwatch stopWatch = new Stopwatch();

        public void FillList(int amount = 100000)
        {
            for (int i = 0; i < amount; i++)
            {
                Cars.Add(new Car(i, $"Car #{i}"));
            }
        }

        public long ForeachMethod()
        {
            stopWatch.Reset();
            stopWatch.Start();

            foreach (var car in Cars)
            {
                car.Age = (343 * 34 * DateTime.Now.Millisecond * 77 * (DateTime.Now.Minute + 5)) / DateTime.Now.Minute;
            }

            stopWatch.Stop();

            return stopWatch.ElapsedMilliseconds;
        }

        public long ForMethod()
        {
            stopWatch.Reset();
            stopWatch.Start();

            for (int i = 0; i < Cars.Count; i++)
            {
                Cars[i].Age = (343 * 34 * DateTime.Now.Millisecond * 77 * (DateTime.Now.Minute + 5)) / DateTime.Now.Minute;
            }

            stopWatch.Stop();

            return stopWatch.ElapsedMilliseconds;
        }

        public long ParalelForeachMethod()
        {
            stopWatch.Reset();
            stopWatch.Start();

            Parallel.ForEach(Cars, car =>
            {
                car.Age = (343 * 34 * DateTime.Now.Millisecond * 77 * (DateTime.Now.Minute + 5)) / DateTime.Now.Minute;
            });

            stopWatch.Stop();

            return stopWatch.ElapsedMilliseconds;
        }

        public long ParalelForMethod()
        {
            stopWatch.Reset();
            stopWatch.Start();

            Parallel.For(0, Cars.Count, i =>
            {
                Cars[i].Age = (343 * 34 * DateTime.Now.Millisecond * 77 * (DateTime.Now.Minute + 5)) / DateTime.Now.Minute;
            });

            stopWatch.Stop();

            return stopWatch.ElapsedMilliseconds;
        }
    }

    public class Car
    {
        public int Age;
        public string Name;

        public Car(int age, string name)
        {
            Age = age;
            Name = name;
        }
    }
}