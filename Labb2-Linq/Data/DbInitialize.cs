using Labb2_Linq.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb2_Linq.Data
{
public class DbInitialize(ApplicationDbContext _context)
{
    private static readonly Random _random = new();
    public async Task Initialize()
    {
        await _context.Database.EnsureCreatedAsync();

        if (_context.Students.Any())
        {
            return;
        }


// -- Create and Initialize the jointable TeacherCourses and add then to the DB -- //
        await InitTeachers();
        await InitClasses();
        await InitCourses();
        await InitStudents();
        await InitStudentCourses();
        await InitTeacherCourses();
    }

    private async Task InitTeacherCourses()
    {
        var teacherCourses = new List<TeacherCourse>
        {
            new() { FkTeacherId = 1, FkCourseId = 1 },   // Engelska 5
            new() { FkTeacherId = 1, FkCourseId = 11 },  // Svenska 2
            new() { FkTeacherId = 1, FkCourseId = 12 },  // Svenska 3
            new() { FkTeacherId = 2, FkCourseId = 15 },  // Kemi 1
            new() { FkTeacherId = 2, FkCourseId = 26 },  // Teknik 1
            new() { FkTeacherId = 1, FkCourseId = 10 },  // Svenska 1
            new() { FkTeacherId = 1, FkCourseId = 2 },   // Engelska 6
            new() { FkTeacherId = 3, FkCourseId = 23 },  //Psykolgi 1
            new() { FkTeacherId = 3, FkCourseId = 27 },  //Filosofi 1
            new() { FkTeacherId = 4, FkCourseId = 20 },  //Företagsekonomi 1
            new() { FkTeacherId = 4, FkCourseId = 21 },  //Privatjurudik 1
            new() { FkTeacherId = 5, FkCourseId = 4 },   //Idrott och hälsa 1
            new() { FkTeacherId = 5, FkCourseId = 22 },  //Moderna språk
            new() { FkTeacherId = 6, FkCourseId = 3 },   //Histroia 1b
            new() { FkTeacherId = 6, FkCourseId = 24 },  //Histroeia 1a1
            new() { FkTeacherId = 7, FkCourseId = 14 },  //Fysik 1
            new() { FkTeacherId = 7, FkCourseId = 25 },  //Fyik 1a1
            new() { FkTeacherId = 8, FkCourseId = 5 },   // Matematik 1c
            new() { FkTeacherId = 8, FkCourseId = 6 },   // Matematik 2c
            new() { FkTeacherId = 8, FkCourseId = 7 },   // Matematik 3c
            new() { FkTeacherId = 8, FkCourseId = 16 },  //Mateatik 1b
            new() { FkTeacherId = 8, FkCourseId = 17 },  //Matematik 2b
            new() { FkTeacherId = 9, FkCourseId = 13 },  //Biolodi 1
            new() { FkTeacherId = 8, FkCourseId = 18 },  //Naturkundskap 1b
            new() { FkTeacherId = 10, FkCourseId = 8 },  //Relegionskundskap 1
            new() { FkTeacherId = 10, FkCourseId = 9 },  //Samhällskundskapp 1b
            new() { FkTeacherId = 10, FkCourseId = 19 }, //Samhällskundskap 2

        };

        foreach (var teacherCourse in teacherCourses)
        {
            await _context.AddAsync(teacherCourse);
        }

        await _context.SaveChangesAsync();
    }

    private async Task InitStudentCourses()
    {
        var studentCourses = new List<StudentCourse>();

        var studentsInNa23 = _context.Students
    .Include(s => s.Class)
    .Where(c => c.Class.ClassName == "Na23").ToList();
        foreach (var student in studentsInNa23)
        {
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 1 });   // Engelska 5
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 2 });   // Engelska 6
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 3 });  // Historia 1b
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 4 });   // Idrott och hälsa 1
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 5 });   // Matematik 1c
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 6 });   // Matematik 2c
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 7 });  // Matematik 3c
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 8 });   // Religionskunskap 1
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 9 });   // Samhällskunskap 1b
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 10 });   // Svenska 1
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 11 });   // Svenska 2
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 12 });  // Svenska 3
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 13 });  // Biologi 1
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 14 });  // Fysik 1
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 15 });  // Kemi 1
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 22 });  // Moderna språk
        }
        var studentsInSa23 = _context.Students
            .Include(s => s.Class)
            .Where(c => c.Class.ClassName == "Sa23").ToList();

        foreach (var student in studentsInSa23)
        {
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 1 });   // Engelska 5
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 2 });   // Engelska 6
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 3 });  // Historia 1b
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 4 });   // Idrott och hälsa 1
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 16 });  // Matematik 1b
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 17 });  // Matematik 2b
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 18 });  // Naturkunskap 1b
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 8 });   // Religionskunskap 1
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 9 });   // Samhällskunskap 1b
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 10 });   // Svenska 1
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 11 });   // Svenska 2
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 12 });  // Svenska 3
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 27 });  // Filosofi 1
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 22 });  // Moderna språk
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 23 });  // Psykologi 1
        }
        var studentsInEk23 = _context.Students
    .Include(s => s.Class)
    .Where(c => c.Class.ClassName == "Ek23").ToList();
        foreach (var student in studentsInEk23)
        {
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 1 });   // Engelska 5
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 2 });   // Engelska 6
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 3 });  // Historia 1b
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 4 });   // Idrott och hälsa 1
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 16 });  // Matematik 1b
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 17 });  // Matematik 2b
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 18 });  // Naturkunskap 1b
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 8 });   // Religionskunskap 1
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 9 });   // Samhällskunskap 1b
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 19 });  // Samhällskunskap 2
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 10 });   // Svenska 1
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 11 });   // Svenska 2
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 12 });  // Svenska 3
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 20 });  // Företagsekonomi 1
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 21 });  // Privatjuridik
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 12 });  // Moderna språk
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 23 });  // Psykologi 1
        }
        var studentsInTe23 = _context.Students
    .Include(s => s.Class)
    .Where(c => c.Class.ClassName == "Te23").ToList();
        foreach (var student in studentsInTe23)
        {
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 1 });    // Engelska 5
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 2 });    // Engelska 6
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 24 });   // Historia 1a1
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 4 });    // Idrott och hälsa 1
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 5 });   // Matematik 1c
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 6 });   // Matematik 2c
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 7 });   // Matematik 3c
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 8 });    // Religionskunskap 1
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 9 });    // Samhällskunskap 1b
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 10 });    // Svenska 1
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 11 });    // Svenska 2
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 12 });   // Svenska 3 / Svenska som andraspråk 3
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 25 });   // Fysik 1a
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 15 });   // Kemi 1
            studentCourses.Add(new() { FkStudentId = student.StudentId, FkCourseId = 26 });   // Teknik 1
        }


        foreach (var studentCourse in studentCourses)
        {
            await _context.AddAsync(studentCourse);
        }

        await _context.SaveChangesAsync();
    }



    private async Task InitCourses()
    {
        var courses = new List<Course>
        {
             new() { CourseName = "Engelska 5" },        //1
             new() { CourseName = "Engelska 6" },        //2
             new() { CourseName = "Historia 1b" },       //3
             new() { CourseName = "Idrott och hälsa 1" },//4
             new() { CourseName = "Matematik 1c" },      //5
             new() { CourseName = "Matematik 2c" },      //6
             new() { CourseName = "Matematik 3c" },      //7
             new() { CourseName = "Religionskunskap 1" },//8
             new() { CourseName = "Samhällskunskap 1b" },//9
             new() { CourseName = "Svenska 1" },         //10
             new() { CourseName = "Svenska 2" },         //11
             new() { CourseName = "Svenska 3" },         //12
             new() { CourseName = "Biologi 1" },         //13
             new() { CourseName = "Fysik 1" },           //14
             new() { CourseName = "Kemi 1" },            //15
             new() { CourseName = "Matematik 1b" },      //16
             new() { CourseName = "Matematik 2b" },      //17
             new() { CourseName = "Naturkunskap 1b" },   //18
             new() { CourseName = "Samhällskunskap 2" }, //19
             new() { CourseName = "Företagsekonomi 1" }, //20
             new() { CourseName = "Privatjuridik" },     //21
             new() { CourseName = "Moderna språk" },     //22
             new() { CourseName = "Psykologi 1" },       //23
             new() { CourseName = "Historia 1a1" },      //24
             new() { CourseName = "Fysik 1a" },          //25
             new() { CourseName = "Teknik 1" },          //26
             new() { CourseName = "Filosofi 1" }         //27
        };

        foreach (var course in courses)
        {
            await _context.AddAsync(course);
        }
        await _context.SaveChangesAsync();
    }

    private async Task InitClasses()
    {
        var classes = new List<Class>
        {
            new() { ClassName = "Na23" },
            new() { ClassName = "Sa23" },
            new() { ClassName = "Ek23" },
            new() { ClassName = "Te23" }
        };

        foreach (var c in classes)
        {
            await _context.AddAsync(c);
        }

        await _context.SaveChangesAsync();
    }

    private async Task InitStudents()
    {
        var students = new List<Student>
        {
            new () { StudentFirstName = "Alice", StudentLastName = "Andersson", FkClassId = 1 },
            new () { StudentFirstName = "Bob", StudentLastName = "Berg", FkClassId = 1 },
            new () { StudentFirstName = "Cecilia", StudentLastName = "Carlsson", FkClassId = 1 },
            new () { StudentFirstName = "David", StudentLastName = "Dahl", FkClassId = 1 },
            new () { StudentFirstName = "Eva", StudentLastName = "Eriksson", FkClassId = 1 },
            new () { StudentFirstName = "Fredrik", StudentLastName = "Fransson", FkClassId = 1 },
            new () { StudentFirstName = "Greta", StudentLastName = "Gustavsson", FkClassId = 1 },
            new () { StudentFirstName = "Hans", StudentLastName = "Holm", FkClassId = 1 },
            new () { StudentFirstName = "Ida", StudentLastName = "Isaksson", FkClassId = 1 },
            new () { StudentFirstName = "Johan", StudentLastName = "Johansson", FkClassId = 1 },
            new () { StudentFirstName = "Karin", StudentLastName = "Karlsson", FkClassId = 1 },
            new () { StudentFirstName = "Lars", StudentLastName = "Lind", FkClassId = 1 },
            new () { StudentFirstName = "Mona", StudentLastName = "Magnusson", FkClassId = 1 },
            new () { StudentFirstName = "Nils", StudentLastName = "Norén", FkClassId = 1 },
            new () { StudentFirstName = "Olivia", StudentLastName = "Olofsson", FkClassId = 2 },
            new () { StudentFirstName = "Per", StudentLastName = "Persson", FkClassId = 2 },
            new () { StudentFirstName = "Quentin", StudentLastName = "Qvist", FkClassId = 2 },
            new () { StudentFirstName = "Rita", StudentLastName = "Rydén", FkClassId = 2 },
            new () { StudentFirstName = "Stefan", StudentLastName = "Sundström", FkClassId = 2 },
            new () { StudentFirstName = "Therese", StudentLastName = "Thor", FkClassId = 2 },
            new () { StudentFirstName = "Ulf", StudentLastName = "Ulander", FkClassId = 2 },
            new () { StudentFirstName = "Vera", StudentLastName = "Viklund", FkClassId = 2 },
            new () { StudentFirstName = "William", StudentLastName = "Westerlund", FkClassId = 2 },
            new () { StudentFirstName = "Xander", StudentLastName = "Xenon", FkClassId = 2 },
            new () { StudentFirstName = "Ylva", StudentLastName = "Yngvesson", FkClassId = 2 },
            new () { StudentFirstName = "Zacharias", StudentLastName = "Zetterlund", FkClassId = 2 },
            new () { StudentFirstName = "Anna", StudentLastName = "Alm", FkClassId = 3 },
            new () { StudentFirstName = "Bengt", StudentLastName = "Björk", FkClassId = 3 },
            new () { StudentFirstName = "Clara", StudentLastName = "Claesson", FkClassId = 3 },
            new () { StudentFirstName = "Daniel", StudentLastName = "Duvander", FkClassId = 3 },
            new () { StudentFirstName = "Elin", StudentLastName = "Eklund", FkClassId = 3 },
            new () { StudentFirstName = "Filip", StudentLastName = "Falk", FkClassId = 3 },
            new () { StudentFirstName = "Gabriella", StudentLastName = "Gran", FkClassId = 3 },
            new () { StudentFirstName = "Henry", StudentLastName = "Hansson", FkClassId = 3 },
            new () { StudentFirstName = "Ingrid", StudentLastName = "Ingman", FkClassId = 3 },
            new () { StudentFirstName = "Jakob", StudentLastName = "Jansson", FkClassId = 3 },
            new () { StudentFirstName = "Katarina", StudentLastName = "Kullberg", FkClassId = 3 },
            new () { StudentFirstName = "Leif", StudentLastName = "Lund", FkClassId = 3 },
            new () { StudentFirstName = "Maria", StudentLastName = "Månsson", FkClassId = 3 },
            new () { StudentFirstName = "Nina", StudentLastName = "Nilsson", FkClassId = 4 },
            new () { StudentFirstName = "Oskar", StudentLastName = "Olsson", FkClassId = 4 },
            new () { StudentFirstName = "Petra", StudentLastName = "Palm", FkClassId = 4 },
            new () { StudentFirstName = "Qasim", StudentLastName = "Quist", FkClassId = 4 },
            new () { StudentFirstName = "Rebecca", StudentLastName = "Rask", FkClassId = 4 },
            new () { StudentFirstName = "Simon", StudentLastName = "Sjöberg", FkClassId = 4 },
            new () { StudentFirstName = "Tina", StudentLastName = "Törnqvist", FkClassId = 4 },
            new () { StudentFirstName = "Ursula", StudentLastName = "Udd", FkClassId = 4 },
            new () { StudentFirstName = "Victor", StudentLastName = "Vikström", FkClassId = 4 },
            new () { StudentFirstName = "Wilma", StudentLastName = "Wahl", FkClassId = 4 },
            new () { StudentFirstName = "Xenia", StudentLastName = "Xandersson", FkClassId = 4 }

        };

        foreach (var student in students)
        {
            await _context.AddAsync(student);
        }

        await _context.SaveChangesAsync();
    }

    private async Task InitTeachers()
    {
        var teachers = new List<Teacher>
        {
                    new() { TeacherFirstName = "Emma", TeacherLastName = "Andersson" },
                    new() { TeacherFirstName = "Johan", TeacherLastName = "Berg" },
                    new() { TeacherFirstName = "Sofia", TeacherLastName = "Carlsson" },
                    new() { TeacherFirstName = "Daniel", TeacherLastName = "Dahl" },
                    new() { TeacherFirstName = "Elin", TeacherLastName = "Eriksson" },
                    new() { TeacherFirstName = "Oscar", TeacherLastName = "Fredriksson" },
                    new() { TeacherFirstName = "Lina", TeacherLastName = "Gustavsson" },
                    new() { TeacherFirstName = "Nils", TeacherLastName = "Hansen" },
                    new() { TeacherFirstName = "Karin", TeacherLastName = "Isaksson" },
                    new() { TeacherFirstName = "Peter", TeacherLastName = "Johansson" }
       };

        foreach (var teacher in teachers)
        {
            await _context.AddAsync(teacher);
        }

        await _context.SaveChangesAsync();
    }
}
}
