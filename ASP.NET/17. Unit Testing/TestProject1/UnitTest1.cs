using System;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void BuyCourse_WithValidStudentAndCourse_ShouldReturnTrue()
        {
            // Arrange
            var courseRepository = new CourseRepository();
            var studentRepository = new StudentRepository();

            var course = new Course { Id = 1, Title = "Programming Basics", Description = "Introduction to programming concepts", Category = "Programming", Level = "Beginner", Price = 49.99m };
            var student = new Student { Id = 1, Name = "Mihai", Email = "mihai@gmail.com", Balance = 100.00m };

            courseRepository.Add(course);
            studentRepository.Add(student);

            var coursesApp = new CoursesApp(courseRepository, studentRepository);

            // Act
            var result = coursesApp.BuyCourse(1, 1);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void BuyCourse_WithInvalidStudent_ShouldReturnFalse()
        {
            // Arrange
            var courseRepository = new CourseRepository();
            var studentRepository = new StudentRepository();

            var course = new Course { Id = 1, Title = "Programming Basics", Description = "Introduction to programming concepts", Category = "Programming", Level = "Beginner", Price = 49.99m };

            courseRepository.Add(course);

            var coursesApp = new CoursesApp(courseRepository, studentRepository);

            // Act
            var result = coursesApp.BuyCourse(1, 1); // Invalid student ID

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void BuyCourse_WithInvalidCourse_ShouldReturnFalse()
        {
            // Arrange
            var courseRepository = new CourseRepository();
            var studentRepository = new StudentRepository();

            var student = new Student { Id = 1, Name = "Mihai", Email = "mihai@gmail.com", Balance = 100.00m };

            studentRepository.Add(student);

            var coursesApp = new CoursesApp(courseRepository, studentRepository);

            // Act
            var result = coursesApp.BuyCourse(1, 1); // Invalid course ID

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void BuyCourse_WithInsufficientBalance_ShouldReturnFalse()
        {
            // Arrange
            var courseRepository = new CourseRepository();
            var studentRepository = new StudentRepository();

            var course = new Course { Id = 1, Title = "Programming Basics", Description = "Introduction to programming concepts", Category = "Programming", Level = "Beginner", Price = 150.00m };
            var student = new Student { Id = 1, Name = "Mihai", Email = "mihai@gmail.com", Balance = 100.00m };

            courseRepository.Add(course);
            studentRepository.Add(student);

            var coursesApp = new CoursesApp(courseRepository, studentRepository);

            // Act
            var result = coursesApp.BuyCourse(1, 1); // Insufficient balance

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void BuyCourse_WithSufficientBalance_ShouldDeductCoursePriceFromStudentBalance()
        {
            // Arrange
            var courseRepository = new CourseRepository();
            var studentRepository = new StudentRepository();

            var course = new Course { Id = 1, Title = "Programming Basics", Description = "Introduction to programming concepts", Category = "Programming", Level = "Beginner", Price = 49.99m };
            var student = new Student { Id = 1, Name = "Mihai", Email = "mihai@gmail.com", Balance = 100.00m };

            courseRepository.Add(course);
            studentRepository.Add(student);

            var coursesApp = new CoursesApp(courseRepository, studentRepository);

            // Act
            coursesApp.BuyCourse(1, 1); // Purchase the course

            // Assert
            var updatedStudent = studentRepository.GetByID(1);
            Assert.Equal(50.11m, updatedStudent.Balance); // Expecting balance to be 100.00m - 49.99m = 50.01m
        }
    }
}