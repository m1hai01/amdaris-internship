using System;
using System.Collections.Generic;

//base class
public abstract class Entity
{
    public int Id { get; set; }
}

public class Course : Entity
{
    public string Title { get; set; }

    public string Description { get; set; }

    public string Category { get; set; }

    public string Level { get; set; }

    public decimal Price { get; set; }
}

public class Student : Entity
{
    public string Name { get; set; }

    public string Email { get; set; }

    public decimal Balance { get; set; }
}

public interface IRepository<T> where T : Entity
{
    T? GetByID(int id);

    IList<T> FindAll();

    void Add(T entity);

    void Delete(T entity);

    void Update(T entity);
}

public class CourseRepository : IRepository<Course>
{
    private readonly List<Course> _courses = new List<Course>();

    public void Add(Course entity)
    {
        _courses.Add(entity);
    }

    public void Delete(Course entity)
    {
        _courses.Remove(entity);
    }

    public IList<Course> FindAll()
    {
        return _courses;
    }

    public Course GetByID(int id)
    {
        return _courses.Find(course => course.Id == id);
    }

    public void Update(Course entity)
    {
        int index = _courses.FindIndex(c => c.Id == entity.Id);
        if (index != -1)
        {
            _courses[index] = entity;
        }
        else
        {
            throw new ArgumentException("Course not found");
        }
    }
}

public class StudentRepository : IRepository<Student>
{
    private List<Student> _students = new List<Student>();

    public void Add(Student entity)
    {
        _students.Add(entity);
    }

    public void Delete(Student entity)
    {
        _students.Remove(entity);
    }

    public IList<Student> FindAll()
    {
        return _students;
    }

    public Student? GetByID(int id)
    {
        return _students.Find(student => student.Id == id);
    }

    public void Update(Student entity)
    {
        int index = _students.FindIndex(s => s.Id == entity.Id);
        if (index != -1)
        {
            _students[index] = entity;
        }
        else
        {
            throw new ArgumentException("Student not found");
        }
    }
}

public class CoursesApp
{
    private readonly IRepository<Course> _courseRepository;
    private readonly IRepository<Student> _studentRepository;

    public CoursesApp(IRepository<Course> courseRepository, IRepository<Student> studentRepository)
    {
        _courseRepository = courseRepository;
        _studentRepository = studentRepository;
    }

    public bool BuyCourse(int studentId, int courseId)
    {
        Student student = _studentRepository.GetByID(studentId);

        if (student == null)
        {
            Console.WriteLine($"Student with id:{studentId} is missing");
            return false;
        }

        Course course = _courseRepository.GetByID(courseId);

        if (course == null)
        {
            Console.WriteLine($"Course with id:{studentId} is missing");
            return false;
        }

        if (student.Balance < course.Price)
        {
            Console.Write($"No money, no honey {course.Title}");
            return false;
        }

        student.Balance = student.Balance - course.Price;

        _courseRepository.Update(course);
        _studentRepository.Update(student);

        Console.WriteLine($"You buy the course : {course.Title}");
        Console.WriteLine($"Some details about the course: {course.Description}");

        return true;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        IRepository<Course> courseRepository = new CourseRepository();
        IRepository<Student> studentRepository = new StudentRepository();

        courseRepository.Add(new Course { Id = 1, Title = "Programming Basics", Description = "Introduction to programming concepts", Category = "Programming", Level = "Beginner", Price = 49.99m });
        courseRepository.Add(new Course { Id = 2, Title = "Data Structures and Algorithms", Description = "Fundamental data structures and algorithms", Category = "Programming", Level = "Intermediate", Price = 79.99m });

        // Add some students
        studentRepository.Add(new Student { Id = 1, Name = "Mihai", Email = "mihai@gmail.com", Balance = 100.00m });
        studentRepository.Add(new Student { Id = 2, Name = "Ion", Email = "ion@gmail.com", Balance = 50.00m });

        // Create CoursesApp instance
        CoursesApp coursesApp = new CoursesApp(courseRepository, studentRepository);

        // Example of buying a course
        coursesApp.BuyCourse(1, 1); // Alice buys Programming Basics

        Console.ReadLine(); // Prevent console from closing immediately
    }
}