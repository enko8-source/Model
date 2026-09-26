using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class Logic
    {
        private List<Student> _students = new List<Student>();
        private int _nextId = 1;

        public void AddStudent(string name, string speciality, string group)
        {
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(speciality) ||
                string.IsNullOrWhiteSpace(group))
                throw new ArgumentException("Все поля должны быть заполнены");

            _students.Add(new Student(_nextId++, name, speciality, group));
        }

        public void DeleteStudent(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);

            if (student == null)
                throw new InvalidOperationException("Студент не найден");

            _students.Remove(student);
        }

        public List<string[]> GetStudentsForView()
        {
            return _students
                .Select(s => new[] { s.Id.ToString(), s.Name, s.Speciality, s.Group })
                .ToList();
        }

        public Dictionary<string, int> GetDistributionBySpeciality()
        {
            return _students
                .GroupBy(s => s.Speciality)
                .ToDictionary(g => g.Key, g => g.Count());
        }
    }
}