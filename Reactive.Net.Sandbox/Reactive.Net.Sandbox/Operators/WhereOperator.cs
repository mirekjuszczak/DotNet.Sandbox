using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Reactive.Net.Sandbox.ConsoleObserver;

namespace Reactive.Net.Sandbox.Operators
{
    public class WhereOperator
    {
        public static void RunSample()
        {
            PersonObservable
                .Where(person => person is Student)
                .Select(s => s as Student)
                .Subscribe(p => Console.WriteLine($"{p.StudentPresenting}"));
        }
        
        private static IObservable<IPerson> PersonObservable =>
        Observable.Create<IPerson>(observer =>
        {
            observer.OnNext(new Student("John"));
            observer.OnNext(new Teacher("Mathew"));
            observer.OnNext(new Student("Anna"));
            observer.OnNext(new Teacher("Kate"));
            observer.OnNext(new Student("Raul"));

            observer.OnCompleted();
            return Disposable.Empty;
        });

        #region Person interface and classes

        public interface IPerson
        {
            string Name { get; }
        }

        public class Student : IPerson
        {
            public Student(string name)
            {
                Name = name;
            }

            public string Name { get; }
            public string StudentPresenting => $" Hello, I'm a student named {Name}...";
        }

        public class Teacher : IPerson
        {
            public Teacher(string name)
            {
                Name = name;
            }

            public string Name { get; }
            public string TeacherPresenting => $" Hello, I'm a teacher named {Name}...";
        }

        #endregion Person interface and classes
    }
}